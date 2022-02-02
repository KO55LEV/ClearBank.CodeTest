using System.ComponentModel.DataAnnotations;

namespace ClearBank.CodeTest.Application.Models.Configuration
{
    public class PaymentServiceSettings
    {
        [Required]
        public string DataStoreType { get; set; }
    }
}
