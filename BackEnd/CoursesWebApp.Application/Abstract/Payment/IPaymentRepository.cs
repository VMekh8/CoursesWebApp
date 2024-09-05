using CoursesWebApp.Application.Models;

namespace CoursesWebApp.Application.Abstract.Payment
{
    public interface IPaymentRepository
    {
        Task<PaymentResultModel> CreatePaymentIntentAsync(decimal price);
    }
}
