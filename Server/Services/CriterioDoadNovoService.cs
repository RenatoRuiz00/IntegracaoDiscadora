using Microsoft.EntityFrameworkCore;
using Operacao.Server.Data;
using Operacao.Server.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Operacao.Server.Services
{
    public class CriterioDoadNovoService : ICriterioDoadNovo
    {
        private readonly AppDbContext _context;

        public CriterioDoadNovoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Buscar(string acao)
        {
            string campo = "";
            switch (acao)
            {
                case "Já  contribui":
                    campo = "JaContribui";
                    break;

                case "Não Atendeu (NA)":
                    campo = "NaoAtendeu";
                    break;

                case "Não contribuiu (NC)":
                    campo = "NaoContribuiu";
                    break;
                case "Não Ligar mais":
                    campo = "NaoLigarMais";
                    break;
                case "Número desativado":
                    campo = "NumDesativado";
                    break;
                case "Ocupado":
                    campo = "NumOcupado";
                    break;
                case "Não existe":
                    campo = "NaoExiste";
                    break;
            }

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select " + campo + " tempo from criterios_fn";
            command.CommandType = CommandType.Text;

            var result = command.ExecuteReader();
            int tempo = 0;
            while (result.Read())
            {
                tempo = Convert.ToInt32(result["tempo"]);
            }

            command.Connection.Close();
            return tempo;
        }
    }
}
