using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Entities.ModelViews;
using WebApi.Helpers;
using WebApi.Interfaces;
using WebApi.Interfaces.IViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        /// <summary>
        /// //внедрение зависимостей для внедрения контекста бд
        /// </summary>
        private readonly DataContext _context;

        public RobotsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ITradibgBot> GetAllRobots()
        {
            try
            {
                var tradingsBots = _context.TradingBots.ToList();
                return tradingsBots;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /** Метод отображения роботов текущего пользователя */
        [HttpGet]
        public IEnumerable<ITradingBotViewModel> GetUserRobots(int id)
        {
            try
            {
                var user = _context.Users.Where(r => r.Id == id).Include(a => a.TradingBots).SingleOrDefault();
                var tradingBots = user.TradingBots.Select(r => new TradingBotViewModel
                {
                    Name = r.Name,
                    Type = r.Type,
                    FinancialInstrument = r.FinancialInstrument,
                    TimeFrame = r.TimeFrame,
                    Strategy = r.Strategy?.Name,
                    Profit = r.Profit,
                    WorkedTime = (DateTime.Now - r.CreatedDate).Days,
                });
                return tradingBots;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /** Метод редактирования роботов пользователем */
        [HttpPost]
        public void UpdateBot (TradingBot bot)
        {
            var oldBot = _context.TradingBots.Where(r => r.IsActive && r.Id == bot.Id).SingleOrDefault();
            if (oldBot == null)
            {
                throw new Exception("Bot not found");
            };
            oldBot.Name = bot.Name;
            _context.TradingBots.Update(oldBot);
            _context.SaveChanges();
        }
    }
}
