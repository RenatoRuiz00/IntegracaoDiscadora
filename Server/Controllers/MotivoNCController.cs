using Microsoft.AspNetCore.Mvc;
using Operacao.Server.Services;
using Operacao.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Operacao.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotivoNCController : ControllerBase
    {
        private readonly MotivoNCService _service;

        public MotivoNCController(MotivoNCService service)
        {
            _service = service;
        }

        // GET: api/<MotivoNCController>
        [HttpGet]
        public async Task<IEnumerable<MotivoNC>> Get()
        {
            return await _service.Buscar();
        }

        // GET api/<MotivoNCController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MotivoNCController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MotivoNCController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MotivoNCController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
