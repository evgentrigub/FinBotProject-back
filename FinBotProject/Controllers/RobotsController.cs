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
                var user = _context.Users.Where(r => r.Id == id)
                    .Include(a => a.TradingBots)
                    .ThenInclude(tb => tb.Strategy)
                    .SingleOrDefault();
                var tradingBots = user.TradingBots.Select(r => new TradingBotViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Type = r.Type,
                    FinancialInstrument = r.FinancialInstrument,
                    TimeFrame = r.TimeFrame,
                    Strategy = r.Strategy?.Name,
                    Profit = r.Profit,
                    WorkedTime = (DateTime.Now - r.CreatedDate).Days,
                }).ToList();
                return tradingBots;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /** Метод создания торгового робота */
        [HttpPost]
        public IResponse CreateBot (TradingBot bot, int id)
        {
            try
            {
                var user = _context.Users.Where(r => r.Id == id).SingleOrDefault();
                if (user == null)
                {
                    return new Response { IsSuccess = false, Message = "Пользователь не найден"};
                };
                if (bot == null)
                {
                    return new Response { IsSuccess = false, Message = "Объект робота пуст" };
                };
                var newTradingBot = new TradingBot
                {
                    Id = new Guid(),
                    User = user,
                    Name = bot.Name,
                    //Type = bot.Type,
                    Sum = bot.Sum,
                    Profit = 0,
                    Strategy = bot.Strategy,
                    //Assets = bot.Assets,
                    //TimeFrame = bot.TimeFrame,
                    FinancialInstrument = bot.FinancialInstrument,
                    CreatedDate = DateTime.Now,
                    ESValue = bot?.ESValue != 0 ? bot.ESValue : 10
                };
                _context.TradingBots.Add(newTradingBot);
                _context.SaveChanges();
                return new Response { IsSuccess = true };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /** Метод редактирования роботов пользователем */
        [HttpPost]
        public IActionResult UpdateBot (TradingBot bot)
        {
            try
            {
                var oldBot = _context.TradingBots.Where(r => r.IsActive && r.Id == bot.Id).SingleOrDefault();
                if (oldBot == null)
                {
                    throw new Exception("Bot not found");
                };
                oldBot.Name = bot.Name;
                _context.TradingBots.Update(oldBot);
                _context.SaveChanges();
                return Ok(bot);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
