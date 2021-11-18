using Microsoft.AspNetCore.Mvc;
using Operacao.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Operacao.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        // GET: api/<EnderecoController>
        [HttpGet("ruas/")]
        public async Task<IEnumerable<string>> BuscarEnderecos()
        {
            return await _service.BuscarEnderecos();
        }

        [HttpGet("ruaspornome/{nome}")]
        public async Task<IEnumerable<string>> BuscarEnderecos(string nome)
        {
            return await _service.BuscarEnderecosPorNome(nome);
        }

        [HttpGet("bairros/")]
        public async Task<IEnumerable<string>> BuscarBairros()
        {
            return await _service.BuscarBairros();
        }

        [HttpGet("cidades/")]
        public async Task<IEnumerable<string>> BuscarCidades()
        {
            return await _service.BuscarCidades();
        }


    }
}
