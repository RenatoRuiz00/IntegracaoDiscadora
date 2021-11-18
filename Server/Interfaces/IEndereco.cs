using System.Collections.Generic;
using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface IEndereco
    {
        public Task<List<string>> BuscarCidades();
        public Task<List<string>> BuscarBairros();
        public Task<List<string>> BuscarEnderecos();
        public Task<IEnumerable<string>> BuscarEnderecosPorNome(string nome);
    }
}
