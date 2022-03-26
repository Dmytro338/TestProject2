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
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet("GetContact/{id}")]
        public async Task<IActionResult> GetContactAsync(int id)
        {
            var result = await contactService.GetAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ContactModel>>> GetAllAsync()
        {
            return Ok(await contactService.GetAll());
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContactAsync(ContactModel contactModel)
        {
            int id = await contactService.AddAsync(contactModel);
            contactModel.Id = id;
            return CreatedAtAction(nameof(GetContactAsync), new { id = id }, contactModel);
        }

        [HttpDelete("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            await contactService.DeleteAsync(id);
            return Ok();
        }
    }
}
