using System;

namespace Operacao.Shared.Models
{
    public class AcaoContribuinte : Acao
    {
        public double? Valor { get; set; }
        public int Identificacao { get; set; }
        public DateTime Hora { get; set; }
    }
}
