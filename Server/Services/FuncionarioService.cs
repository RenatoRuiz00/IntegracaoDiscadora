using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Operacao.Server.Data;
using Operacao.Server.Interfaces;
using Operacao.Shared.Utils;
using Operacao.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Operacao.Server.Services
{
    public class FuncionarioService : IFuncionario
    {
        private readonly AppDbContext _context;

        public FuncionarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Funcionario> Login(string usuario, string senha)
        {
            Funcionario funcionario = new Funcionario();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select autonum id,nome,cidade,usuario,id_central,id_cidade,antecipar,ddd,id_turno from " +
                "funcionarios where usuario=@Usuario and senha=@Senha";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Usuario", usuario));
            command.Parameters.Add(new MySqlParameter("@Senha", senha));

            var result = command.ExecuteReader();

            while (result.Read())
            {
                funcionario = new Funcionario
                {
                    Id = Convert.ToInt32(result["id"]),
                    Nome = result["nome"].ToString(),
                    CentralId = Convert.ToInt32(result["id_central"]),
                    //CidadeId = Convert.ToInt32(result["id_cidade"]),
                    Antecipar = Converter.ToBool(result["antecipar"]),
                    DDD = result["ddd"].ToString(),
                    TurnoId = Convert.ToInt32(result["id_turno"]),
                };
            }

            command.Connection.Close();
            return funcionario;
        }
    }
}
