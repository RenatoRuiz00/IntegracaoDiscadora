using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Operacao.Server.Data;
using Operacao.Server.Interfaces;
using Operacao.Shared.Models;
using Operacao.Shared.Utils;
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

        public async Task Agendar(int id, DateTime dt)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "UPDATE clientes SET dataAgenda=@Dt,horarioAgenda=@Hora " +
                "WHERE matricula=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Dt", dt.Date));
            command.Parameters.Add(new MySqlParameter("@Hora", dt.TimeOfDay));
            command.Parameters.Add(new MySqlParameter("@Id", id));

            command.ExecuteNonQuery();
            command.Connection.Close();
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

        public async Task<Contribuinte> BuscarPorId(int id)
        {
            Contribuinte contribuinte = new Contribuinte();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select matricula,strTelefone,nome,setor,dtNascimento," +
                "strEndereco,numero,complemento,strBairro,strCidade,Ponto_Ref,strCategoria," +
                "celular1,celular2,cpf,data_retorno,email,ObsOperadoras,obs_mensageiro," +
                "ObsCoordenacao,lgpd from clientes where matricula= @Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Id", id));

            var result = command.ExecuteReader();

            while (result.Read())
            {
                contribuinte.Id = Convert.ToInt32(result["matricula"]);
                contribuinte.Telefone = result["strTelefone"].ToString();
                contribuinte.Nome = result["nome"].ToString();
                contribuinte.Setor = result["setor"].ToString();
                contribuinte.DtNascimento = Converter.ToDateTime(result["dtNascimento"]);
                contribuinte.Endereco = result["strEndereco"].ToString();
                contribuinte.Numero = result["numero"].ToString();
                contribuinte.Complemento = result["complemento"].ToString();
                contribuinte.Bairro = result["strBairro"].ToString();
                contribuinte.Cidade = result["strCidade"].ToString();
                contribuinte.PontoReferencia = result["Ponto_Ref"].ToString();
                contribuinte.Categoria = result["strCategoria"].ToString();
                contribuinte.Celular1 = result["celular1"].ToString();
                contribuinte.Celular2 = result["celular2"].ToString();
                contribuinte.Cpf = result["cpf"].ToString();
                contribuinte.DtRetorno = Convert.ToDateTime(result["data_retorno"]);
                contribuinte.Email = result["email"].ToString();
                contribuinte.ObsCoordenacao = result["ObsCoordenacao"].ToString();
                contribuinte.ObsOperacao = result["ObsOperadoras"].ToString();
                contribuinte.ObsMensageiros = result["obs_mensageiro"].ToString();
                contribuinte.Lgpd = result["lgpd"].ToString();
            }

            command.Connection.Close();
            return contribuinte;
        }

        public async Task Cancelar(int id, string motivo)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "update clientes set cancelado ='I'," +
                "motivo_canc=@Motivo,dt_canc=Date(Now()) WHERE matricula=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Id", id));
            command.Parameters.Add(new MySqlParameter("@Motivo", motivo));

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

        public async Task LimparAgenda(int id)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "update clientes set DataAgenda=null,HorarioAgenda=null " +
                "where matricula=@Id ";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Id", id));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task NC(int id, string motivo, int idFuncionario)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "insert into tbl_nc (matricula,data,id_operadora,motivo,hora) values " +
                "(@Id,Date(Now()),@IdOperadora,@Motivo,Time(Now()))";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Id", id));
            command.Parameters.Add(new MySqlParameter("@IdOperadora", idFuncionario));
            command.Parameters.Add(new MySqlParameter("@Motivo", motivo));

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

        public async Task Update(Contribuinte contribuinte)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "update clientes set strTelefone=@Telefone," +
                "nome=@Nome,dtNascimento=@DtNasc,strEndereco=@Endereco,numero=@Numero," +
                "complemento=@Complemento,strBairro=@Bairro,strCidade=@Cidade," +
                "Ponto_Ref=@PontoRef,strCategoria=@Categoria,celular1=@Celular1,celular2=@Celular2," +
                "cpf=@Cpf,data_retorno=@DtRetorno,email=@Email,ObsOperadoras=@ObsOper," +
                "obs_mensageiro=@ObsMensageiro where matricula=@Id";
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new MySqlParameter("@Id", contribuinte.Id));
            command.Parameters.Add(new MySqlParameter("@Telefone", contribuinte.Telefone));
            command.Parameters.Add(new MySqlParameter("@Nome", contribuinte.Nome));
            command.Parameters.Add(new MySqlParameter("@DtNasc", contribuinte.DtNascimento));
            command.Parameters.Add(new MySqlParameter("@Endereco", contribuinte.DtNascimento));
            command.Parameters.Add(new MySqlParameter("@Numero", contribuinte.DtNascimento));
            command.Parameters.Add(new MySqlParameter("@Complemento", contribuinte.DtNascimento));
            command.Parameters.Add(new MySqlParameter("@Bairro", contribuinte.Bairro));
            command.Parameters.Add(new MySqlParameter("@Cidade", contribuinte.Cidade));
            command.Parameters.Add(new MySqlParameter("@PontoRef", contribuinte.PontoReferencia));
            command.Parameters.Add(new MySqlParameter("@Categoria", contribuinte.Categoria));
            command.Parameters.Add(new MySqlParameter("@Celular1", contribuinte.Celular1));
            command.Parameters.Add(new MySqlParameter("@Celular2", contribuinte.Celular2));
            command.Parameters.Add(new MySqlParameter("@Cpf", contribuinte.Cpf));
            command.Parameters.Add(new MySqlParameter("@ObsOper", contribuinte.ObsOperacao));
            command.Parameters.Add(new MySqlParameter("@ObsMensageiro", contribuinte.ObsMensageiros));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
