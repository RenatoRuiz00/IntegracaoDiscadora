using System.Text.Json.Serialization;

namespace Operacao.Shared.Models.PagSeguro
{
    public class Error
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
