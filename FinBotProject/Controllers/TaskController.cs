using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Interfaces.Enums;
using WebApi.Services;

///<summary> Контроллер для работы с тестом для определения типа трейдера </summary>

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;

        public TaskController(
            DataContext context,
            IUserService userService)
        {
            _userService = userService;
            _context = context;
        }


        public IEnumerable<Questions> GetQuestions()
        {
            try
            {
                var questions = _context.Questions
                    .Select(r => new Questions {Answers = r.Answers, ObjContent = r.ObjContent})
                    .ToList();
                foreach (var quest in questions) quest.Answers = quest.Answers.OrderBy(r => r.AnswerRate).ToList();
                return questions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Метод принимает в себя объект пользователя и количество баллов за тест, которые нужно конвертировать в тип инвестора. После этого обновляет БД
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetInvestorType(JObject stuff)
        {
            try
            {
                var obj = stuff["user"].ToObject<User>();
                var balls = stuff["balls"].ToObject<int>();
                var type = RiskType.Moderate;
                switch (balls)
                {
                    case int n when n <= 71:
                        type = RiskType.Guaranteed;
                        break;
                    case int n when n > 71 && n <= 106:
                        type = RiskType.Conservative;
                        break;
                    case int n when n > 106 && n <= 142:
                        type = RiskType.Moderate;
                        break;
                    case int n when n > 142 && n <= 182:
                        type = RiskType.Growth;
                        break;
                    case int n when n > 182 && n <= 221:
                        type = RiskType.AggressiveGrowth;
                        break;
                    case int n when n > 221:
                        type = RiskType.MaximumGrowth;
                        break;
                }

                obj.RiskType = type;
                _userService.UpdateInvestorType(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}