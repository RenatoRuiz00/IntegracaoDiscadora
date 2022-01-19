using Operacao.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface IAcaoContribuinte
    {
        public Task Insert(AcaoContribuinte acao);
    }
}
