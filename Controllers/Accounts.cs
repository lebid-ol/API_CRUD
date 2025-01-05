using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using Scalar.AspNetCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Accounts : ControllerBase
    {
         static BankAccounts account1 = new BankAccounts { Id = 1, Name = "Aлександр", Balance = 1000 };
         static BankAccounts account2 = new BankAccounts { Id = 2, Name = "Oлег", Balance = 2000 };
       
        public  static List<BankAccounts> allAccounts = new List<BankAccounts>();

        static Accounts()
        {
            AddAccountsToList();
        }

        public static void AddAccountsToList()
        {
            allAccounts.Add(account1);
            allAccounts.Add(account2);
        }


        // GET: api/<Accounts>
        [HttpGet]
        public List<BankAccounts> GetAllAccounts()
        {
            return allAccounts;
        }

        // GET api/<Accounts>/1
        [HttpGet("{id}")]
        public ActionResult<BankAccounts> GetAccountId([FromRoute] int id)
        {
            var account = allAccounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound($"Account with ID {id} not found");
            }

            return Ok(account1);
        }

        // POST api/<Accounts>
        [HttpPost]
        public ActionResult <BankAccounts> Post([FromBody] BankAccounts newAccount)
        {
            allAccounts.Add(newAccount);
            return Ok(newAccount);
        }

        // PUT api/<Accounts>/2
        [HttpPut("{id}")]
        public ActionResult<BankAccounts> Put([FromRoute] int id, [FromBody] BankAccounts updatedAccount)
        {
            var account = allAccounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound($"Account with ID {id} not found");
            }

            account.Name = updatedAccount.Name;
            account.Balance = updatedAccount.Balance;

            return Ok(account);
        }

        // DELETE api/<Accounts>/номер id
        [HttpDelete("{id}")]
        public ActionResult<BankAccounts> DeleteAccount([FromRoute] int id)
        {
            var account = allAccounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound($"Account with ID {id} not found");
            }

            allAccounts.Remove(account);
            return Ok($"Account with ID {id} was deleted");

        }
    }
}

