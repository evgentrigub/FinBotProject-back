using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet]
        //public IEnumerable<ITradingBotViewModel> GetUserRobots(int id)
        //{
        //    try
        //    {
        //        var tradingsBots = _context.Tra.Where(r => r.User.Id == id).Select(r =>  new TradingBotViewModel 
        //        { 
        //            Name = r.TradingBot.Name,
        //            Type = r.TradingBot.Type,
        //            FinancialInstrument = r.TradingBot.FinancialInstrument,
        //            TimeFrame = r.TradingBot.TimeFrame,
        //            Strategy_name = r.TradingBot.Strategy.Name,
        //            Profit = r.TradingBot.Profit,
        //            WorkedTime =(DateTime.Now - r.CreatedDate).Days,
        //        }).ToList();

        //        return tradingsBots;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
