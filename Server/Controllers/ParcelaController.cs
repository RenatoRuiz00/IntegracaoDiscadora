using Microsoft.AspNetCore.Mvc;
using Operacao.Server.Services;
using Operacao.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Operacao.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelaController : ControllerBase
    {
        private readonly ParcelaService _parcelaService;

        public ParcelaController(ParcelaService parcelaService)
        {
            _parcelaService = parcelaService;
        }

        // GET: api/<ParcelaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ParcelaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("buscarHoje/{id}")]
        public async Task<List<Parcela>> BuscarHoje(int id)
        {
            return await _parcelaService.BuscarHoje(id);
        }

        // POST api/<ParcelaController>
        [HttpPost]
        public async Task Post([FromBody] Parcela parcela)
        {
            await _parcelaService.Inserir(parcela);
        }

        // PUT api/<ParcelaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ParcelaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
