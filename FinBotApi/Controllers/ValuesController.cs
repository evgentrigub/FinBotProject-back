using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinBotApi.Controllers
{
    //[Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //ПРРОВЕРКА НА ВХОД ПО JWS-TOKEN

        //[Authorize]
        //[Route("getlogin")]
        //public IActionResult GetLogin()
        //{
        //    return Ok($"Ваш логин: {User.Identity.Name}");
        //}

        //[Authorize(Roles = "admin")]
        //[Route("getrole")]
        //public IActionResult GetRole()
        //{
        //    return Ok("Ваша роль: администратор");
        //}
    }
}
