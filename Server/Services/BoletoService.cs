using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Operacao.Server.Data;
using Operacao.Server.Interfaces;
using Operacao.Shared.Models;
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

        public async Task Insert(BoletoParcela boleto)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "insert into boletos (id_parcela,cod_boleto,link_boleto) " +
                "values (@Parcela,@CodBoleto,@Link)";
            command.CommandType = CommandType.Text;
            
            command.Parameters.Add(new MySqlParameter("@Parcela", boleto.ParcelaId));
            command.Parameters.Add(new MySqlParameter("@CodBoleto", boleto.CodBoleto));
            command.Parameters.Add(new MySqlParameter("@Link", boleto.Link));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
