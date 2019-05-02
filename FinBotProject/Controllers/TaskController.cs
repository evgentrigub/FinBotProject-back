using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private IUserService _userService;
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
                var questions = _context.Questions.Select(r => new Questions { Answers = r.Answers, ObjContent = r.ObjContent })
                    .ToList();
                foreach (Questions quest in questions)
                {
                    quest.Answers = quest.Answers.OrderBy(r => r.AnswerRate).ToList();
                }
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
                    case int n when ( n <= 71 ):
                        type = RiskType.Guaranteed;
                        break;
                    case int n when ( n > 71 && n <= 106):
                        type = RiskType.Conservative;
                        break;
                    case int n when (n > 106 && n <= 142):
                        type = RiskType.Moderate;
                        break;
                    case int n when (n > 142 && n <= 182):
                        type = RiskType.Growth;
                        break;
                    case int n when (n > 182 && n <= 221):
                        type = RiskType.AggressiveGrowth;
                        break;
                    case int n when (n >221):
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

        //private IActionResult _UpdateData()
        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
