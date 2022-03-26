using BLL.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet("GetAccount/{id}")]
        public async Task<IActionResult> GetAccountAsync(int id)
        {
            var result = await accountService.GetAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<AccountModel>>> GetAllAsync()
        {
            return Ok(await accountService.GetAll());
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccountAsync(AccountModel accountModel)
        {
            int id = await accountService.AddAsync(accountModel);
            accountModel.Id = id;
            return CreatedAtAction(nameof(GetAccountAsync), new { id = id }, accountModel);
        }

        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> DeleteAccountAsync(int id)
        {
            await accountService.DeleteAsync(id);
            return Ok();
        }
    }
}
