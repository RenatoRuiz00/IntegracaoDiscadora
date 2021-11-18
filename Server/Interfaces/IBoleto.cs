using Operacao.Shared.Models.PagSeguro;
using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface IBoleto
    {
        public Task<Credencial> BuscarCredencial();
    }
}
