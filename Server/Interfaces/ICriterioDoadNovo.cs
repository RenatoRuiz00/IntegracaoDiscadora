using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface ICriterioDoadNovo
    {
        public Task<int> Buscar(string acao);
    }
}
