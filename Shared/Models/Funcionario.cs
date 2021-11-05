using System;

namespace Operacao.Shared.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtAdmissao { get; set; }
        public DateTime? DtDemissao { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public DateTime? DtNascimento { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int CentralId { get; set; }
        public int? FuncaoId { get; set; }
        public int? CidadeId { get; set; }
        public int TurnoId { get; set; }
        public bool? Antecipar { get; set; }
        public string DDD { get; set; }
    }
}
