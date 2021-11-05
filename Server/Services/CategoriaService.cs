using Microsoft.EntityFrameworkCore;
using Operacao.Server.Data;
using Operacao.Server.Interfaces;
using Operacao.Shared.Models;
using Operacao.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Operacao.Server.Services
{
    public class CategoriaService : ICategoria
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> Buscar()
        {
            List<Categoria> categorias = new List<Categoria>();

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select id,descricao,projeto_empresa from categorias order by id";
            command.CommandType = CommandType.Text;

            var result = command.ExecuteReader();

            while (result.Read())
            {
                categorias.Add(new Categoria
                {
                    Id = Convert.ToInt32(result["id"]),
                    Descricao = result["descricao"].ToString(),
                    ProjetoEmpresa = Converter.ToBool(result["projeto_empresa"])
                });
            }

            command.Connection.Close();
            return categorias;
        }
    }
}
