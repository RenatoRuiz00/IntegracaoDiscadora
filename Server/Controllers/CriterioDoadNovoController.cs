using Microsoft.AspNetCore.Mvc;
using Operacao.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Operacao.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriterioDoadNovoController : ControllerBase
    {
        private readonly CriterioDoadNovoService _service;

        public CriterioDoadNovoController(CriterioDoadNovoService service)
        {
            _service = service;
        }

        // GET: api/<CriterioDoadNovoController>
        [HttpGet("{acao}")]
        public async Task<int> Get(string acao)
        {
            return await _service.Buscar(acao);
        }

        // POST api/<CriterioDoadNovoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CriterioDoadNovoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CriterioDoadNovoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
