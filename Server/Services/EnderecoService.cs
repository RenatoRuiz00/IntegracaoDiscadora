using Microsoft.EntityFrameworkCore;
using Operacao.Server.Data;
using Operacao.Server.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Operacao.Server.Services
{
    public class EnderecoService : IEndereco
    {
        private readonly AppDbContext _context;

        public EnderecoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> BuscarBairros()
        {
            List<string> bairros = new List<string>();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select distinct strBairro bairro from clientes where (cancelado='A' or cancelado is null) order by strBairro";
            command.CommandType = CommandType.Text;

            var result = command.ExecuteReader();

            while (result.Read())
            {
                bairros.Add(result["bairro"].ToString());
            }

            command.Connection.Close();
            return bairros;
        }

        public async Task<List<string>> BuscarCidades()
        {
            List<string> cidades = new List<string>();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select distinct strCidade cidade from clientes where (cancelado='A' or cancelado is null) order by strCidade";
            command.CommandType = CommandType.Text;

            var result = command.ExecuteReader();

            while (result.Read())
            {
                cidades.Add(result["bairro"].ToString());
            }

            command.Connection.Close();
            return cidades;
        }

        public async Task<List<string>> BuscarEnderecos()
        {
            List<string> enderecos = new List<string>();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select distinct strEndereco endereco from clientes where (cancelado='A' or cancelado is null) order by strEndereco";
            command.CommandType = CommandType.Text;

            var result = command.ExecuteReader();

            while (result.Read())
            {
                enderecos.Add(result["endereco"].ToString());
            }

            command.Connection.Close();
            return enderecos;
        }
    }
}
