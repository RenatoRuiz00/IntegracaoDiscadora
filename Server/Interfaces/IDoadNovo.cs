using Operacao.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface IDoadNovo
    {
        public Task<DoadNovo> BuscarPorId(int id);
        public Task<DoadNovo> BuscarPorId2(int id);
        public Task Update(DoadNovo doadNovo);
        public Task Update2(DoadNovo doadNovo);
        public Task Desativar(DoadNovo doadNovo);
        public Task Deletar(int id);
        public Task Agendar(int id, DateTime dtAgenda, int funcionarioId);
        public Task<int> BuscarOperadorTurno(int turnoId);
        public Task Contribuiu(DoadNovo doadNovo);
        public Task InserirResultado(Parcela parcela);
    }
}
