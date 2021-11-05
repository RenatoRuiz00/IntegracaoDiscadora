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
    public class ContribuinteService : IContribuinte
    {
        private readonly AppDbContext _context;

        public ContribuinteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AtualizaRetorno(int id, DateTime dt)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "update clientes set data_retorno=@DtRetorno where matricula=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@DtRetorno", dt));
            command.Parameters.Add(new MySqlParameter("@Id", id));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task Inserir(Contribuinte contribuinte)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "insert into clientes (nome, dtnascimento, numero, strTelefone, " +
                "obsOperadoras, obs_Mensageiro, obsCoordenacao,sexo, complemento, ponto_ref, " +
                "data_retorno, email, na, celular1, celular2, dta_cad, strEndereco, strBairro," +
                "strCidade, strCategoria, id_operadora, cancelado, cpf, origem) values (@Nome,@DtNascimento,@Numero," +
                "@Telefone,@ObsOperadora,@ObsMensageiros,@ObsCoordenacao,@Sexo,@Complemento,@PontoRef,@DtRetorno," +
                "@Email,0,@Celular1,@Celular2,Date(Now()),@Endereco,@Bairro,@Cidade,@Categoria,@IdFuncionario,'A'," +
                "@CPF,@Origem)";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Nome", contribuinte.Nome));
            command.Parameters.Add(new MySqlParameter("@DtNascimento", contribuinte.DtNascimento));
            command.Parameters.Add(new MySqlParameter("@Numero", contribuinte.Numero));
            command.Parameters.Add(new MySqlParameter("@Telefone", contribuinte.Telefone));
            command.Parameters.Add(new MySqlParameter("@ObsOperadora", contribuinte.ObsOperacao));
            command.Parameters.Add(new MySqlParameter("@ObsMensageiros", contribuinte.ObsMensageiros));
            command.Parameters.Add(new MySqlParameter("@ObsCoordenacao", contribuinte.ObsCoordenacao));
            command.Parameters.Add(new MySqlParameter("@Sexo", contribuinte.Sexo));
            command.Parameters.Add(new MySqlParameter("@Complemento", contribuinte.Complemento));
            command.Parameters.Add(new MySqlParameter("@PontoRef", contribuinte.PontoReferencia));
            command.Parameters.Add(new MySqlParameter("@DtRetorno", contribuinte.DtRetorno));
            command.Parameters.Add(new MySqlParameter("@Email", contribuinte.Email));
            command.Parameters.Add(new MySqlParameter("@Celular1", contribuinte.Celular1));
            command.Parameters.Add(new MySqlParameter("@Celular2", contribuinte.Celular2));
            command.Parameters.Add(new MySqlParameter("@Endereco", contribuinte.Endereco));
            command.Parameters.Add(new MySqlParameter("@Bairro", contribuinte.Bairro));
            command.Parameters.Add(new MySqlParameter("@Cidade", contribuinte.Cidade));
            command.Parameters.Add(new MySqlParameter("@Categoria", contribuinte.Categoria));
            command.Parameters.Add(new MySqlParameter("@IdFuncionario", contribuinte.FuncionarioId));
            command.Parameters.Add(new MySqlParameter("@CPF", contribuinte.Cpf));
            command.Parameters.Add(new MySqlParameter("@Origem", contribuinte.Origem));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task<int> UltimoId()
        {
            int id = 0;

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select max(matricula) id from clientes";
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
