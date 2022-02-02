using ClearBank.CodeTest.Application.Interfaces;
using ClearBank.CodeTest.Domain.Models;
using ClearBank.CodeTest.Infrastructure.Interfaces;

namespace ClearBank.CodeTest.Application.Services.DataStore
{
    internal class AccountDataStore : IDataStore
    {

        private readonly IAccountDataStoreService _accountDataStoreService;

        public AccountDataStore(IAccountDataStoreService accountDataStoreService)
        {
            _accountDataStoreService = accountDataStoreService;
        }

        public Account GetAccount(string accountNumber)
        {
            return _accountDataStoreService.GetAccount(accountNumber);
        }

        public void UpdateAccount(Account account)
        {
            _accountDataStoreService.UpdateAccount(account);
        }
    }
}
