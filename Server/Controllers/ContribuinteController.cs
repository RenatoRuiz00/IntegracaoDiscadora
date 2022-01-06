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
    public class ContribuinteController : ControllerBase
    {
        private readonly ContribuinteService _contribuinteService;

        public ContribuinteController(ContribuinteService contribuinteService)
        {
            _contribuinteService = contribuinteService;
        }

        // GET: api/<ContribuinteController>
        [HttpGet("{id}")]
        public async Task<Contribuinte> Get(int id)
        {
            return await _contribuinteService.BuscarPorId(id);
        }

        // GET api/<ContribuinteController>/5
        [HttpGet("buscarUltimoId/")]
        public async Task<int> BuscarUltimoId()
        {
            return await _contribuinteService.UltimoId();
        }

        // POST api/<ContribuinteController>
        [HttpPost]
        public async Task Post([FromBody] Contribuinte contribuinte)
        {
            await _contribuinteService.Inserir(contribuinte);
        }

        // PUT api/<ContribuinteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contribuinte contribuinte)
        {

        }

        [HttpGet("atualizaRetorno/{id}/{dt}")]
        public async Task AtualizaRetorno(int id, DateTime dt)
        {
            await _contribuinteService.AtualizaRetorno(id,dt);
        }

        // DELETE api/<ContribuinteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
