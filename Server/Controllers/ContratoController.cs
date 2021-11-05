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
    public class ContratoController : ControllerBase
    {
        private readonly ContratoService _service;

        public ContratoController(ContratoService service)
        {
            _service = service;
        }

        // GET: api/<ContratoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ContratoController>/5
        [HttpGet("buscarUltimoId/")]
        public async Task<int> BuscarUltimoId()
        {
            return await _service.UltimoId();
        }

        // POST api/<ContratoController>
        [HttpPost]
        public async Task Post([FromBody] Contrato contrato)
        {
            await _service.Inserir(contrato);
        }

        // PUT api/<ContratoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContratoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
