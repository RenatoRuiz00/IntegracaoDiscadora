using Microsoft.AspNetCore.Mvc;
using Operacao.Server.Services;
using Operacao.Shared.Models;
using Operacao.Shared.Models.PagSeguro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Operacao.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly BoletoService _service;

        public BoletoController(BoletoService service)
        {
            _service = service;
        }

        // GET: api/<BoletoController>
        [HttpGet]
        public async Task<Credencial> Get()
        {
            return await _service.BuscarCredencial();
        }

        // GET api/<BoletoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BoletoController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Boleto boleto)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:53557/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("https://ws.pagseguro.uol.com.br/recurring-payment/boletos?email=renato@somarterceirosetor.com.br&token=1c61ec64-aea7-4cc9-bee8-8f2a423f564da6f3fd464ec88068c740083bad1da6d3218e-23c6-4227-96ce-7e6f691361cc", boleto);
                Console.WriteLine("Produto cha verde incluído. Tecle algo para atualizar o preço do produto.");
                //Console.ReadKey();

                if (response.IsSuccessStatusCode)
                {
                    return Ok(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    return BadRequest(await response.Content.ReadAsStringAsync());
                }
            }
        }

        [HttpPost("boletoparcela")]
        public async Task InsertBoletoParcela([FromBody] BoletoParcela boleto)
        {
            await _service.Insert(boleto);
        }

        // PUT api/<BoletoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BoletoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
