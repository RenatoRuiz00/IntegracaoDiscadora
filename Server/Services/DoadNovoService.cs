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
    public class DoadNovoService : IDoadNovo
    {
        private readonly AppDbContext _context;

        public DoadNovoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Agendar(int id, DateTime dtAgenda, int funcionarioId)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "update lista set lista_retorno=@DtRetorno,lista_data_ligacao=Now(),lista_ultima_acao='Agendou Retorno',lista_id_operadora=@IdFuncionario where lista_id=@Id";
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new MySqlParameter("@IdFuncionario", funcionarioId));
            command.Parameters.Add(new MySqlParameter("@DtRetorno", dtAgenda));
            command.Parameters.Add(new MySqlParameter("@Id", id));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task<int> BuscarOperadorTurno(int turnoId)
        {
            int idOperador = 0;

            DoadNovo doadNovo = new DoadNovo();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select autonum from funcionarios where (id_turno =@IdTurno or id_turno = 3) " +
                "and id_funcao = 2 and dataDemissao is null and autonum != 1  order by rand()";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@idTurno", turnoId));

            var result = command.ExecuteReader();

            while (result.Read())
            {
                idOperador = Convert.ToInt32(result["autonum"]);
            }

            command.Connection.Close();
            return idOperador;
        }

        public async Task<DoadNovo> BuscarPorId(int id)
        {
            DoadNovo doadNovo = new DoadNovo();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select lista_fone_ddd,lista_fone_numero,lista_retorno," +
                "lista_celular1,lista_celular2,lista_bairro,lista_cidade," +
                "lista_obscoordenadora obsCoord,lista_obsoperadora obsOper " +
                "from lista where lista_id=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Id", id));

            var result = command.ExecuteReader();

            while (result.Read())
            {
                doadNovo = new DoadNovo
                {
                    Id = id,
                    DDD = result["lista_fone_ddd"].ToString(),
                    Telefone = result["lista_fone_numero"].ToString(),
                    Bairro = result["lista_bairro"].ToString(),
                    Cidade = result["lista_cidade"].ToString(),
                    Celular1 = result["lista_celular1"].ToString(),
                    Celular2 = result["lista_celular2"].ToString(),
                    DtRetorno = Convert.ToDateTime(result["lista_retorno"]),
                    ObsCoordenacao = result["obsCoord"].ToString(),
                    ObsOperacao = result["obsOper"].ToString(),
                };
            }

            command.Connection.Close();
            return doadNovo;
        }

        public async Task<DoadNovo> BuscarPorId2(int id)
        {
            DoadNovo doadNovo = new DoadNovo();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select lista_nome,lista_nascimento,lista_numero," +
                "lista_fone_numero,lista_obsmensageiro,lista_obsoperadora,lista_obscoordenadora," +
                "lista_sexo,lista_complemento,lista_referencia,lista_retorno," +
                "lista_email,lista_celular1,lista_celular2,lista_endereco,lista_bairro," +
                "lista_cidade,cpf,origem from lista where lista_id=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Id", id));

            var result = command.ExecuteReader();

            while (result.Read())
            {
                doadNovo = new DoadNovo
                {
                    Id = id,
                    Telefone = result["lista_fone_numero"].ToString(),
                    Nome = result["lista_nome"].ToString(),
                    DtNascimento = Converter.ToDateTime(result["lista_nascimento"]),
                    Endereco = result["lista_endereco"].ToString(),
                    Numero = result["lista_numero"].ToString(),
                    Bairro = result["lista_bairro"].ToString(),
                    Cidade = result["lista_cidade"].ToString(),
                    ObsMensageiros = result["lista_obsmensageiro"].ToString(),
                    ObsOperacao = result["lista_obsoperadora"].ToString(),
                    ObsCoordenacao = result["lista_obscoordenadora"].ToString(),
                    Sexo = result["lista_sexo"].ToString(),
                    Complemento = result["lista_complemento"].ToString(),
                    PontoReferencia = result["lista_referencia"].ToString(),
                    DtRetorno = Convert.ToDateTime(result["lista_retorno"]),
                    Email = result["lista_email"].ToString(),
                    Celular1 = result["lista_celular1"].ToString(),
                    Celular2 = result["lista_celular2"].ToString(),
                    Cpf = result["cpf"].ToString(),
                    Origem = result["origem"].ToString()
                };
            }

            command.Connection.Close();
            return doadNovo;
        }

        public async Task Contribuiu(DoadNovo doadNovo)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "update lista set lista_nome=@Nome,lista_nascimento=@DtNasc,lista_sexo=@Sexo," +
                "cpf=@Cpf,lista_endereco=@Endereco,lista_numero=@Numero,lista_bairro=@Bairro,lista_cidade=@Cidade," +
                "lista_referencia=@PontoRef,lista_complemento=@Complemento,lista_celular1=@Celular1," +
                "lista_celular2=@Celular2,lista_email=@Email,lista_obsmensageiro=@ObsMensageiros," +
                "lista_obsoperadora=@ObsOperacao,lista_obscoordenadora=@ObsCoordenacao where lista_id=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Nome", doadNovo.Nome));
            command.Parameters.Add(new MySqlParameter("@DtNasc", doadNovo.DtNascimento));
            command.Parameters.Add(new MySqlParameter("@Sexo", doadNovo.Sexo));
            command.Parameters.Add(new MySqlParameter("@Cpf", doadNovo.Cpf));
            command.Parameters.Add(new MySqlParameter("@Endereco", doadNovo.Endereco));
            command.Parameters.Add(new MySqlParameter("@Numero", doadNovo.Numero));
            command.Parameters.Add(new MySqlParameter("@Bairro", doadNovo.Bairro));
            command.Parameters.Add(new MySqlParameter("@Cidade", doadNovo.Cidade));
            command.Parameters.Add(new MySqlParameter("@PontoRef", doadNovo.PontoReferencia));
            command.Parameters.Add(new MySqlParameter("@Complemento", doadNovo.Complemento));
            command.Parameters.Add(new MySqlParameter("@Celular1", doadNovo.Celular1));
            command.Parameters.Add(new MySqlParameter("@Celular2", doadNovo.Celular2));
            command.Parameters.Add(new MySqlParameter("@Email", doadNovo.Email));
            command.Parameters.Add(new MySqlParameter("@ObsMensageiros", doadNovo.ObsMensageiros));
            command.Parameters.Add(new MySqlParameter("@ObsOperacao", doadNovo.ObsOperacao));
            command.Parameters.Add(new MySqlParameter("@ObsCoordenacao", doadNovo.ObsCoordenacao));
            command.Parameters.Add(new MySqlParameter("@Id", doadNovo.Id));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task Deletar(int id)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "delete from lista where lista_id = @Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Id", id));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task Desativar(DoadNovo doadNovo)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "insert into lista_desativada " +
                "(lista_fone_ddd,lista_fone_numero,lista_cidade,lista_sexo) values " +
                "(@DDD,@Telefone,@Cidade,@Sexo)";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@DDD", doadNovo.DDD));
            command.Parameters.Add(new MySqlParameter("@Telefone", doadNovo.Telefone));
            command.Parameters.Add(new MySqlParameter("@Cidade", doadNovo.Cidade));
            command.Parameters.Add(new MySqlParameter("@Sexo", doadNovo.Sexo));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task InserirResultado(Parcela parcela)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "insert into fichas_novas_resultados " +
                "(matricula,dt_cadastramento,dt_1_doacao,vlr_doacao,id_operadora) " +
                "values (@IdContribuinte,Date(Now()),@DtDoacao,@Valor,@IdOperadora)";

            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@IdContribuinte", parcela.ContribuinteId));
            command.Parameters.Add(new MySqlParameter("@DtDoacao", parcela.DtVencimento));
            command.Parameters.Add(new MySqlParameter("@Valor", parcela.Valor));
            command.Parameters.Add(new MySqlParameter("@IdOperadora", parcela.FuncionarioId));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task Update(DoadNovo doadNovo)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "update lista set lista_bairro=@Bairro,lista_cidade=@Cidade," +
                "lista_celular1=@Celular1,lista_celular2=@Celular2,lista_obsoperadora=@ObsOperacao," +
                "lista_obscoordenadora=@ObsCoordenacao where lista_id=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Bairro", doadNovo.Bairro));
            command.Parameters.Add(new MySqlParameter("@Cidade", doadNovo.Cidade));
            command.Parameters.Add(new MySqlParameter("@Celular1", doadNovo.Celular1));
            command.Parameters.Add(new MySqlParameter("@Celular2", doadNovo.Celular2));
            command.Parameters.Add(new MySqlParameter("@ObsOperacao", doadNovo.ObsOperacao));
            command.Parameters.Add(new MySqlParameter("@ObsCoordenacao", doadNovo.ObsCoordenacao));
            command.Parameters.Add(new MySqlParameter("@Id", doadNovo.Id));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public async Task Update2(DoadNovo doadNovo)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "update lista set lista_retorno=@Retorno,lista_ultima_acao=@Acao," +
                "lista_id_operadora=@IdFuncionario,lista_data_ligacao=Now() where lista_id=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Retorno", doadNovo.DtRetorno));
            command.Parameters.Add(new MySqlParameter("@Acao", doadNovo.UltimaAcao));
            command.Parameters.Add(new MySqlParameter("@IdFuncionario", doadNovo.FuncionarioId));
            command.Parameters.Add(new MySqlParameter("@Id", doadNovo.Id));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
