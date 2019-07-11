using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebApi.Entities;
using WebApi.Entities.ModelViews;
using WebApi.Helpers;
using WebApi.Interfaces;
using WebApi.Interfaces.Enums;
using WebApi.Interfaces.IViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        /// <summary>
        ///     //внедрение зависимостей для внедрения контекста бд
        /// </summary>
        private readonly DataContext _context;

        public RobotsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ITradingBot> GetAllRobots()
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
                    //FinancialInstrument = r.FinancialInstrument,
                    TimeFrame = r.TimeFrame,
                    Strategy = r.Strategy,
                    Profit = r.Profit,
                    IsActive = r.IsActive,
                    WorkedTime = (DateTime.Now - r.CreatedDate).Days
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
        public IResponse CreateBot(JObject stuff)
        {
            try
            {
                var bot = stuff["bot"].ToObject<TradingBot>();
                var id = stuff["id"].ToObject<int>();
                var user = _context.Users.Where(r => r.Id == id).SingleOrDefault();
                if (user == null) return new Response {IsSuccess = false, Message = "Пользователь не найден"};
                ;
                if (bot == null) return new Response {IsSuccess = false, Message = "Объект робота пуст"};
                ;
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
                    //FinancialInstrument = bot.FinancialInstrument,
                    CreatedDate = DateTime.Now,
                    ESValue = bot?.ESValue != 0 ? bot.ESValue : 10
                };
                _context.TradingBots.Add(newTradingBot);
                _context.SaveChanges();
                return new Response {IsSuccess = true};
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /** Метод редактирования роботов пользователем */
        [HttpPost]
        public IActionResult UpdateBot(TradingBot bot)
        {
            try
            {
                var oldBot = _context.TradingBots.Where(r => r.Id == bot.Id).SingleOrDefault();
                if (oldBot == null) throw new Exception("Bot not found");
                ;
                oldBot.Name = bot.Name;
                oldBot.IsActive = bot.IsActive;
                _context.TradingBots.Update(oldBot);
                _context.SaveChanges();
                return Ok(bot);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /** Метод удаления роботов пользователем */
        [HttpPost]
        public IActionResult DeleteBot(TradingBot bot)
        {
            try
            {
                var botForDelete = _context.TradingBots.Where(r => r.Id == bot.Id).SingleOrDefault();
                if (botForDelete == null) throw new Exception("Bot not found");
                ;
                _context.TradingBots.Remove(botForDelete);
                _context.SaveChanges();
                return Ok(bot);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /** Метод отображения активов для выбора в создании робота */
        [HttpGet]
        public IEnumerable<Asset> GetAssetsByFinancialInstrumentAndIndustry(FinancialInstrument fi, Industry ind)
        {
            try
            {
                var assets = _context.Assets.Where(r => r.FinancialInstrument == fi && r.Industry == ind).ToList();
                return assets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public Asset GetDescription(string bot_id)
        {
            try
            {
                var description = _context.BotsAssets.Where(r => r.TradingBot.Id.ToString() == bot_id)
                    .Include(r => r.Asset).SingleOrDefault();
                return description.Asset;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}