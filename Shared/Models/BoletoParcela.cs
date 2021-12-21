namespace Operacao.Shared.Models
{
    public class BoletoParcela
    {
        public int Id { get; set; }
        public int ParcelaId { get; set; }
        public string CodBoleto { get; set; }
        public string Link { get; set; }
    }
}
