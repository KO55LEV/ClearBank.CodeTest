using ClearBank.CodeTest.Application.Interfaces;
using ClearBank.CodeTest.Application.Models.Configuration;
using ClearBank.CodeTest.Application.Models.Requests;
using ClearBank.CodeTest.Application.Models.Responses;
using ClearBank.CodeTest.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;

namespace ClearBank.CodeTest.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentServiceSettings _paymentServiceSettings;
        
        private readonly IDataStoreServiceFactory _dataStoreServiceFactory;

        private readonly IAccountValidation _accountValidation;

        private IDataStore _dataStore;

        public PaymentService(IOptions<PaymentServiceSettings> paymentServiceSettings, IDataStoreServiceFactory dataStoreServiceFactory, IAccountValidation accountValidation)
        {
            _paymentServiceSettings = paymentServiceSettings.Value;
            _dataStoreServiceFactory = dataStoreServiceFactory;
            _accountValidation = accountValidation;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            _dataStore = _dataStoreServiceFactory.GetDataStore(_paymentServiceSettings.DataStoreType);

            var account = _dataStore.GetAccount(request.DebtorAccountNumber);

            var accountSuccess = _accountValidation.ValidateAccount(account, request.PaymentScheme, request.Amount);

            if (accountSuccess)
            { 
                account.Balance -= request.Amount;

                _dataStore.UpdateAccount(account);
            }

            return new MakePaymentResult()
            {
                Success = accountSuccess
            };
        }

       
    }
}


