using ClearBank.CodeTest.Application.Models.Requests;
using ClearBank.CodeTest.Application.Models.Responses;

namespace ClearBank.CodeTest.Application.Interfaces
{
    public interface IPaymentService
    {
        MakePaymentResult MakePayment(MakePaymentRequest request);
    }
}


