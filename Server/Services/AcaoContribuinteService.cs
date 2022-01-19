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
    public class AcaoContribuinteService : IAcaoContribuinte
    {
        private readonly AppDbContext _context;

        public AcaoContribuinteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Insert(AcaoContribuinte acao)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "insert into resultados_op_hora (id_operadora,vlr_doacao," +
                "identif,acao,dt_fech,hora,matricula) values (@IdOperadora,@Vlr,@Identif,@Acao," +
                "@Dt,@Hora,@Matricula)";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@IdOperadora", acao.FuncionarioId));
            command.Parameters.Add(new MySqlParameter("@Vlr", acao.Valor));
            command.Parameters.Add(new MySqlParameter("@Identif", acao.Identificacao));
            command.Parameters.Add(new MySqlParameter("@Acao", acao.Descricao));
            command.Parameters.Add(new MySqlParameter("@Dt", acao.Dt));
            command.Parameters.Add(new MySqlParameter("@Hora", acao.Hora));
            command.Parameters.Add(new MySqlParameter("@Matricula", acao.PessoaId));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
