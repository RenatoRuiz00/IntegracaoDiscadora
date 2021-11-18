using Microsoft.AspNetCore.Mvc;
using Operacao.Server.Services;
using Operacao.Shared.Models.PagSeguro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Operacao.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly BoletoService _service;

        public BoletoController(BoletoService service)
        {
            _service = service;
        }

        // GET: api/<BoletoController>
        [HttpGet]
        public async Task<Credencial> Get()
        {
            return await _service.BuscarCredencial();
        }

        // GET api/<BoletoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BoletoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BoletoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BoletoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
