using System;

namespace Operacao.Shared.Models
{
    public class DoadNovo : Pessoa
    {
        public string DDD { get; set; }
        public DateTime? DtLigacao { get; set; }
        public string UltimaAcao { get; set; }
    }
}
