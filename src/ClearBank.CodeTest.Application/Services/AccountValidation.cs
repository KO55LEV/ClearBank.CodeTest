using ClearBank.CodeTest.Application.Interfaces;
using ClearBank.CodeTest.Domain.Enums;
using ClearBank.CodeTest.Domain.Models;

namespace ClearBank.CodeTest.Application.Services
{
    public class AccountValidation : IAccountValidation
    {
        public bool ValidateAccount(Account account, PaymentScheme paymentScheme, decimal amount)
        {
            // please note in provided logic success always flase; 

            bool response = true; 

            switch (paymentScheme)
            {
                case PaymentScheme.Bacs:
                    if (account == null)
                    {
                        response = false;
                    }
                    else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
                    {
                        response = false;
                    }
                    break;

                case PaymentScheme.FasterPayments:
                    if (account == null)
                    {
                        response = false;
                    }
                    else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
                    {
                        response = false;
                    }
                    else if (account.Balance < amount)
                    {
                        response = false;
                    }
                    break;

                case PaymentScheme.Chaps:

                    if (account == null)
                    {
                        response = false;
                    }
                    else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
                    {
                        response = false;
                    }
                    else if (account.Status != AccountStatus.Live)
                    {
                        response = false;
                    }
                    break;
            }

            return response;
        }
    }
}
