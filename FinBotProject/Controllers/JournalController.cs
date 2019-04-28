using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        // GET: api/Journal
        [HttpGet]
        public string Get()
        {
            var curr = Directory.GetCurrentDirectory();
            var path = Path.GetDirectoryName(curr)+"\\OsEngine\\bin\\Debug\\Result\\william_result.txt";
            string readText = System.IO.File.ReadAllText(path);

            return readText;
        }

        // GET: api/Journal/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Journal
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Journal/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
