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
        public async Task PutAsync(int id, [FromBody] Contribuinte contribuinte)
        {
            await _contribuinteService.Update(contribuinte);
        }

        [HttpGet("atualizaRetorno/{id}/{dt}")]
        public async Task AtualizaRetorno(int id, DateTime dt)
        {
            await _contribuinteService.AtualizaRetorno(id, dt);
        }

        [HttpGet("nc/{id}/{motivo}/{idOperadora}")]
        public async Task AtualizaRetorno(int id, string motivo, int idOperadora)
        {
            await _contribuinteService.NC(id, motivo, idOperadora);
        }

        [HttpGet("limparAgenda/{id}")]
        public async Task LimparAgenda(int id)
        {
            await _contribuinteService.LimparAgenda(id);
        }

        [HttpGet("agendar/{id}/{dt}")]
        public async Task Agendar(int id, DateTime dt)
        {
            await _contribuinteService.Agendar(id, dt);
        }

        [HttpGet("cancelar/{id}/{motivo}")]
        public async Task Cancelar(int id, string motivo)
        {
            await _contribuinteService.Cancelar(id, motivo);
        }

        // DELETE api/<ContribuinteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
