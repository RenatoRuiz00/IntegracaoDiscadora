using System;

namespace Operacao.Shared.Models
{
    public class Mes
    {
        public int Id { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public int QtdDiasUteis { get; set; }
        public int NumMes { get; set; }
        public int NumAno { get; set; }
        public double Carteira { get; set; }
        public string MesExtenso { get; set; }
    }
}
