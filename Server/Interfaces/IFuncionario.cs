using Operacao.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Operacao.Server.Interfaces
{
    interface IFuncionario
    {
        public Task<Funcionario> Login(string usuario,string senha);
    }
}
