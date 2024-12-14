using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Accounts : ControllerBase
    {
        // GET: api/<Accounts>
        [HttpGet]
        public IEnumerable<string> GetAllAccounts()
        {
            return new string[] { "Александр", "Лебедь" };
        }

        // GET api/<Accounts>/5
        [HttpGet("{id}")]
        public string GetAccountId([FromRoute] int id)
        {
            return "Викторович";
        }

        // POST api/<Accounts>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return $"Account {value} created";
        }

        // PUT api/<Accounts>/5
        [HttpPut("{id}")]
        public string Put([FromRoute]int id, [FromBody] string value)
        {
            return $"Account {id} updated to new name {value}";
        }

        // DELETE api/<Accounts>/5
        [HttpDelete("{id}")]
        public string Delete([FromRoute] int id)
        {
            return $"Account with ID {id} was deleted";
        }
    }
}
