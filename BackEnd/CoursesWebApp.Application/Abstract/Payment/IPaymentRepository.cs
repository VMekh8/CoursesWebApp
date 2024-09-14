using CoursesWebApp.Application.Models;

namespace CoursesWebApp.Application.Abstract.Payment
{
    public interface IPaymentRepository
    {
        Task<PaymentResponseModel> CreatePaymentIntentAsync(decimal price);
    }
}
