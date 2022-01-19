using System;

namespace Operacao.Shared.Models
{
    public class Acao
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int FuncionarioId { get; set; }
        public string Descricao { get; set; }
        public DateTime Dt { get; set; }
    }
}
