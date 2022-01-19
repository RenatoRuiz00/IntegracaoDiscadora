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
    public class AcaoContribuinteController : ControllerBase
    {
        private readonly AcaoContribuinteService _service;

        public AcaoContribuinteController(AcaoContribuinteService service)
        {
            _service = service;
        }

        // GET: api/<AcaoContribuinteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AcaoContribuinteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AcaoContribuinteController>
        [HttpPost]
        public async Task Post([FromBody] AcaoContribuinte acao)
        {
           await _service.Insert(acao);
        }

        // PUT api/<AcaoContribuinteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AcaoContribuinteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
