using Operacao.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface ICategoria
    {
        public Task<List<Categoria>> Buscar();
    }
}
