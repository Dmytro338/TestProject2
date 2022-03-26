using BLL.Models;
using Core.BLL.ViewModels;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            this.incidentService = incidentService;
        }
       
        [HttpGet("GetIncident/{name}")]
        public async Task<IActionResult> GetIncidentAsync(string name)
        {
            var result = await incidentService.GetByNameAsync(name);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<IncidentModel>>> GetAllAsync()
        {
            return Ok(await incidentService.GetAll());
        }
        
        [HttpPost("CreateIncident")]
        public async Task<IActionResult> CreateIncidentAsync(IncidentModel incident)
        {
            string name = await incidentService.AddAsync(incident);
            incident.Name = name;
            return CreatedAtAction(nameof(GetIncidentAsync), new { name = name }, incident);
        }

        [HttpPost("ExampleRequestAsync")]
        public async Task<IActionResult> ExampleRequestAsync(IncidentViewModel incident)
        {
            string name = await incidentService.ExampleRequestAsync(incident);
            incident.AccountName = name;
            return CreatedAtAction(nameof(GetIncidentAsync), new { name = name }, incident);
        }

        [HttpDelete("DeleteIncident/{name}")]
        public async Task<IActionResult> DeleteIncidentAsync(string name)
        {
            await incidentService.DeleteByNameAsync(name);
            return Ok();
        }
    }
}
