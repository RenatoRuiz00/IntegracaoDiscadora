using System;

namespace Operacao.Shared.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DtRetorno { get; set; }
        public int FuncionarioId { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }
        public string Cep { get; set; }
        public string Sexo { get; set; }
        public DateTime? DtNascimento { get; set; }
        public string ObsCoordenacao { get; set; }
        public string ObsOperacao { get; set; }
        public string ObsMensageiros { get; set; }
        public string Email { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Cpf { get; set; }
        public string Origem { get; set; }
    }
}
