using System;
using System.Text.Json.Serialization;

namespace Operacao.Shared.Models.PagSeguro
{
    public class ReturnSuccess
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("paymentLink")]
        public string PaymentLink { get; set; }
        [JsonPropertyName("barcode")]
        public string BarCode { get; set; }
        [JsonPropertyName("dueDate")]
        public DateTime DueDate { get; set; }
    }
}
