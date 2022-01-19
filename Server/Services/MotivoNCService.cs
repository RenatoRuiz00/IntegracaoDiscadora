using Microsoft.EntityFrameworkCore;
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
    public class MotivoNCService : IMotivoNC
    {
        private readonly AppDbContext _context;

        public MotivoNCService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MotivoNC>> Buscar()
        {
            List<MotivoNC> motivos = new List<MotivoNC>();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select id,descricao from motivos_nc order by descricao";
            command.CommandType = CommandType.Text;

            var result = command.ExecuteReader();

            while (result.Read())
            {
                motivos.Add(new MotivoNC
                {
                    Id = Convert.ToInt32(result["id"]),
                    Descricao = result["descricao"].ToString()
                });
            }

            command.Connection.Close();
            return motivos;
        }
    }
}
