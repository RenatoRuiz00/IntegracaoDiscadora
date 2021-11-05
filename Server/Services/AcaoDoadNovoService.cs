using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Operacao.Server.Data;
using Operacao.Server.Interfaces;
using Operacao.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Operacao.Server.Services
{
    public class AcaoDoadNovoService : IAcaoDoadNovo
    {
        private readonly AppDbContext _context;

        public AcaoDoadNovoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Inserir(AcaoDoadNovo acao)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "insert into lista_historico (listhist_id_lista,listhist_id_operadora,listhist_acao," +
                "listhist_data,fone) values (@IdDoadNovo,@IdFuncionario,@Acao,Now(),@Telefone)";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@IdDoadNovo", acao.PessoaId));
            command.Parameters.Add(new MySqlParameter("@IdFuncionario", acao.FuncionarioId));
            command.Parameters.Add(new MySqlParameter("@Acao", acao.Descricao));
            command.Parameters.Add(new MySqlParameter("@Telefone", acao.Telefone));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
