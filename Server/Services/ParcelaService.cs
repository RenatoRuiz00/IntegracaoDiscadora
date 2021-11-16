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
    public class ParcelaService : IParcela
    {
        private readonly AppDbContext _context;

        public ParcelaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Parcela>> BuscarHoje(int id)
        {
            List<Parcela> parcelas = new List<Parcela>();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select id,matricula,curValor,dtVencimento from " +
                "tbl_parcelas where matricula=@IdContribuinte and Date(dtLigacao)=Date(Now())";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@IdContribuinte", id));

            var result = command.ExecuteReader();

            while (result.Read())
            {
                parcelas.Add(new Parcela
                {
                    Id = Convert.ToInt32(result["id"]),
                    ContribuinteId = Convert.ToInt32(result["matricula"]),
                    Valor = Convert.ToDouble(result["curValor"]),
                    DtVencimento = Convert.ToDateTime(result["dtVencimento"])
                });
            }

            command.Connection.Close();
            return parcelas;
        }

        public async Task Edit(Parcela parcela)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "update tbl_parcelas set curValor=@Valor,dtVencimento=Date(@DtVcto) " +
                "where id=@Id";
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new MySqlParameter("@Valor", parcela.Valor));
            command.Parameters.Add(new MySqlParameter("@DtVcto", parcela.DtVencimento));
            command.Parameters.Add(new MySqlParameter("@Id", parcela.Id));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task Inserir(Parcela parcela)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "insert into tbl_parcelas (matricula,bytParcela,dtLigacao,dtVencimento," +
                "curValor,id_operadora,lngNumContrato,qtd_cupons_venda,boleto,reciboImpresso,dt_impressao) values " +
                "(@IdContribuinte,@BytParcela,Date(Now()),@DtVcto,@Valor,@IdFuncionario,@IdContrato,@QtdCupons,@Boleto," +
                "@Impresso,@DtImpressao)";
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new MySqlParameter("@IdContribuinte", parcela.ContribuinteId));
            command.Parameters.Add(new MySqlParameter("@BytParcela", parcela.BytParcela));
            command.Parameters.Add(new MySqlParameter("@DtVcto", parcela.DtVencimento));
            command.Parameters.Add(new MySqlParameter("@Valor", parcela.Valor));
            command.Parameters.Add(new MySqlParameter("@IdFuncionario", parcela.FuncionarioId));
            command.Parameters.Add(new MySqlParameter("@IdContrato", parcela.ContratoId));
            command.Parameters.Add(new MySqlParameter("@QtdCupons", parcela.QtdCupons));
            command.Parameters.Add(new MySqlParameter("@Boleto", parcela.Boleto));
            command.Parameters.Add(new MySqlParameter("@Impresso", parcela.Impresso));
            command.Parameters.Add(new MySqlParameter("@DtImpressao", parcela.DtImpressao));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
