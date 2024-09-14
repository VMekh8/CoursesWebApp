namespace CoursesWebApp.Application.Models
{
    public class PaymentRequestModel
    {
        public string CustomerEmail { get; set; } = string.Empty;
        public long Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
