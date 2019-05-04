using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Interfaces;

///<summary> Контроллер для работы со стратегиями </summary>

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StrategyController : ControllerBase
    {
        /// <summary>
        /// //внедрение зависимостей для внедрения контекста бд
        /// </summary>
        private readonly DataContext _context;

        public StrategyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<IStrategy> GetAllStrategies()
        {
            try
            {
                var strategies = _context.Strategy.Select(r => new Strategy 
                {   
                    Id = r.Id,
                    Name = r.Name,
                    CreatedDate = r.CreatedDate,
                    Description = r.Description,
                    IsActive = r.IsActive,
                    StrategyOSEngine = r.StrategyOSEngine
                }).Where(r => r.IsActive).ToList();
                return strategies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IStrategy GetStrategy(string id)
        {
            try
            {
                var strategy = _context.Strategy.Where(r => r.Id.ToString() == id).SingleOrDefault();

                return strategy;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
