using System;

namespace Operacao.Shared.Models
{
    public class Parcela
    {
        public int Id { get; set; }
        public int ContribuinteId { get; set; }
        public int ContratoId { get; set; }
        public int FuncionarioId { get; set; }
        public int BytParcela { get; set; }
        public double Valor { get; set; }
        public DateTime DtVencimento { get; set; }
        public DateTime DtLigacao { get; set; }
        public bool? Cancelado { get; set; }
        public DateTime? DtCancelamento { get; set; }
        public bool? Impresso { get; set; }
        public DateTime? DtImpressao { get; set; }
        public int QtdCupons { get; set; }
        public bool? Boleto { get; set; }
    }
}
