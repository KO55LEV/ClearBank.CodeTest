using ClearBank.CodeTest.Domain.Enums;
using ClearBank.CodeTest.Domain.Models;

namespace ClearBank.CodeTest.Application.Interfaces
{
    public interface IAccountValidation
    {
        bool ValidateAccount(Account account, PaymentScheme paymentScheme, decimal amount);
    }
}
