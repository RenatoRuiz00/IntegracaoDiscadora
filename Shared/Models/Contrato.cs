using System;

namespace Operacao.Shared.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public int ContribuinteId { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DtLigacao { get; set; }
        public DateTime DtContrato { get; set; }
        public int BytMeses { get; set; }
        public double Valor { get; set; }
        public int BytParcelas { get; set; }
    }
}
