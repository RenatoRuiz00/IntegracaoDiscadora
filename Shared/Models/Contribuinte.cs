using System;

namespace Operacao.Shared.Models
{
    public class Contribuinte : Pessoa
    {
        public string Categoria { get; set; }
        public string Setor { get; set; }
        public int Na { get; set; }
        public int GrupoId { get; set; }
        public DateTime? DtAgenda { get; set; }
        public TimeSpan? HoraAgenda { get; set; }
        public int? CodDebito { get; set; }
        public int? DocumentoIdentificacao { get; set; }
        public string TitularDebito { get; set; }
        public string Responsavel { get; set; }
        public bool? Op1 { get; set; }
        public bool? Op2 { get; set; }
        public bool? Op3 { get; set; }
        public bool? Op4 { get; set; }
        public bool? Liberado { get; set; }
        public DateTime DtCadastramento { get; set; }
        public string Cancelado { get; set; }
        public string MotivoCancelamento { get; set; }
        public DateTime? DtCancelamento { get; set; }
        public string Lgpd { get; set; }
    }
}
