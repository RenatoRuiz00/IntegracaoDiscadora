using Operacao.Shared.Models;
using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface IAcaoDoadNovo
    {
        public Task Inserir(AcaoDoadNovo acao);
    }
}
