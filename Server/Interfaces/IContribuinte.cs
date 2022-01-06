using Operacao.Shared.Models;
using System;
using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface IContribuinte
    {
        public Task Inserir(Contribuinte contribuinte);
        public Task<int> UltimoId();
        public Task AtualizaRetorno(int id,DateTime dt);
        public Task<Contribuinte> BuscarPorId(int id);
    }
}
