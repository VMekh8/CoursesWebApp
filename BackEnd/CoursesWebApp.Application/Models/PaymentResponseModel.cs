namespace CoursesWebApp.Application.Models
{
    public class PaymentResponseModel
    {
        public string PaymentID { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
