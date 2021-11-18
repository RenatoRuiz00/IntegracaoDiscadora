using Microsoft.EntityFrameworkCore;
using Operacao.Server.Data;
using Operacao.Server.Interfaces;
using Operacao.Shared.Models.PagSeguro;
using System.Data;
using System.Threading.Tasks;

namespace Operacao.Server.Services
{
    public class BoletoService : IBoleto
    {
        private readonly AppDbContext _context;

        public BoletoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Credencial> BuscarCredencial()
        {
            Credencial credencial = new Credencial();
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select * from pagseguro";
            command.CommandType = CommandType.Text;

            var result = command.ExecuteReader();

            while (result.Read())
            {
                credencial.Email = result["email"].ToString();
                credencial.Token = result["token"].ToString();
                credencial.DDD = result["ddd"].ToString();
                credencial.UF = result["uf"].ToString();
            }

            command.Connection.Close();
            return credencial;
        }
    }
}
