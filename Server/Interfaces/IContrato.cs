using Operacao.Shared.Models;
using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface IContrato
    {
        public Task<int> UltimoId();
        public Task Inserir(Contrato contrato);
    }
}
