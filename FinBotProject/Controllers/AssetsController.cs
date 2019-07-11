using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Interfaces.Enums;
using WebApi.Services;

// Контроллер для работы с бумагами

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly DataContext _context;
        private IUserService _userService;

        public AssetsController(
            DataContext context,
            IUserService userService)
        {
            _userService = userService;
            _context = context;
        }

        public IEnumerable<Asset> GetAssets()
        {
            try
            {
                var assets = _context.Assets.Where(r => r.IsActive).ToList();
                return assets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Получение бумаги по индустрии
        public IEnumerable<Asset> GetAssetsByIndustry(Industry industry)
        {
            try
            {
                var assets = _context.Assets.Where(r => r.IsActive && r.Industry == industry).ToList();
                return assets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}