using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Operacao.Server.Data;
using Operacao.Server.Interfaces;
using Operacao.Shared.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Operacao.Server.Services
{
    public class ContratoService : IContrato
    {
        private readonly AppDbContext _context;

        public ContratoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Inserir(Contrato contrato)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "insert into tbl_contratos (matricula,lngNumContrato,dtLigacao,dtContrato,bytMeses," +
                "curValor,bytParcelas,id_operadora) values (@IdContribuinte,@IdContrato,Date(Now()),Date(Now()),1," +
                "@Valor,@BytParcelas,@IdFuncionario)";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@IdContribuinte", contrato.ContribuinteId));
            command.Parameters.Add(new MySqlParameter("@IdContrato", contrato.Id));
            command.Parameters.Add(new MySqlParameter("@Valor", contrato.Valor));
            command.Parameters.Add(new MySqlParameter("@BytParcelas", contrato.BytParcelas));
            command.Parameters.Add(new MySqlParameter("@IdFuncionario", contrato.FuncionarioId));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task<int> UltimoId()
        {
            int id = 0;

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select max(lngNumContrato) id from tbl_contratos";
            command.CommandType = CommandType.Text;

            var result = command.ExecuteReader();

            while (result.Read())
            {
                id = Convert.ToInt32(result["id"]);
            }

            command.Connection.Close();
            return id;
        }
    }
}
