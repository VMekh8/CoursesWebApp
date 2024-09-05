namespace CoursesWebApp.Application.Models
{
    public class PaymentResultModel
    {
        public bool Success { get; set; }
        public string PaymentID { get; set; }
        public string ErrorMessage { get; set; }
    }
}
