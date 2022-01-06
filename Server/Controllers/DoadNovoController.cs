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
    public class DoadNovoController : ControllerBase
    {
        private readonly DoadNovoService _doadNovoService;

        public DoadNovoController(DoadNovoService doadNovoService)
        {
            _doadNovoService = doadNovoService;
        }

        // GET: api/<DoadNovoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DoadNovoController>/5
        [HttpGet("{id}")]
        public async Task<DoadNovo> GetAsync(int id)
        {
            return await _doadNovoService.BuscarPorId2(id);
        }

        [HttpGet("buscarporid2/{id}")]
        public async Task<DoadNovo> BuscarPorId2(int id)
        {
            return await _doadNovoService.BuscarPorId2(id);
        }

        // POST api/<DoadNovoController>
        [HttpPost("inserirResultado/")]
        public async Task InserirResultado([FromBody] Parcela parcela)
        {
          await _doadNovoService.InserirResultado(parcela);
        }

        // PUT api/<DoadNovoController>/5
        [HttpPut("update1/{id}")]
        public async Task Put(int id, [FromBody] DoadNovo doadNovo)
        {
           await _doadNovoService.Update(doadNovo);
        }

        [HttpPut("update2/{id}")]
        public async Task Update2(int id, [FromBody] DoadNovo doadNovo)
        {
            await _doadNovoService.Update2(doadNovo);
        }

        [HttpPut("contribuiu/{id}")]
        public async Task Contribuiu(int id, [FromBody] DoadNovo doadNovo)
        {
            await _doadNovoService.Contribuiu(doadNovo);
        }

        [HttpPut("desativar/{id}")]
        public async Task Desativar(int id, [FromBody] DoadNovo doadNovo)
        {
            await _doadNovoService.Desativar(doadNovo);
        }

        [HttpGet("agendar/{id}/{dtAgenda}/{idFuncionario}")]
        public async Task Put(int id,DateTime dtAgenda,int idFuncionario)
        {
            await _doadNovoService.Agendar(id,dtAgenda,idFuncionario);
        }

        [HttpGet("operadorturno/{idTurno}")]
        public async Task<int> OperadorTurno(int idTurno)
        {
            return await _doadNovoService.BuscarOperadorTurno(idTurno);
        }

        // DELETE api/<DoadNovoController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _doadNovoService.Deletar(id);
        }
    }
}
