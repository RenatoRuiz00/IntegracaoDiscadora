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
    public class AcaoDoadNovoController : ControllerBase
    {
        private readonly AcaoDoadNovoService _acaoService;

        public AcaoDoadNovoController(AcaoDoadNovoService acaoService)
        {
            _acaoService = acaoService;
        }

        // GET: api/<AcaoDoadNovoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AcaoDoadNovoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AcaoDoadNovoController>
        [HttpPost]
        public async Task Post([FromBody] AcaoDoadNovo acao)
        {
            await _acaoService.Inserir(acao);
        }

        // PUT api/<AcaoDoadNovoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AcaoDoadNovoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
