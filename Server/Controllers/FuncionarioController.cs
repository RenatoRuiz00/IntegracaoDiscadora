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
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionarioController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }


        // GET: api/<FuncionarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FuncionarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("login/{usuario}/{senha}")]
        public async Task<Funcionario> Login(string usuario,string senha)
        {
            return await _funcionarioService.Login(usuario,senha);
        }

        // POST api/<FuncionarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FuncionarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FuncionarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
