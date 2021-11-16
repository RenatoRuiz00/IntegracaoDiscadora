using Operacao.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface IParcela
    {
        public Task Inserir(Parcela parcela);
        public Task<List<Parcela>> BuscarHoje(int id);
        public Task Edit(Parcela parcela);
    }
}
