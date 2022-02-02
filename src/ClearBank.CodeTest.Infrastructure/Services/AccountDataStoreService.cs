using ClearBank.CodeTest.Domain.Models;
using ClearBank.CodeTest.Infrastructure.Interfaces;

namespace ClearBank.CodeTest.Infrastructure.Services
{
    public class AccountDataStoreService : IAccountDataStoreService
    {
        public Account GetAccount(string accountNumber)
        {
            // Access to database logic goes here 

            return new Account();
        }

        public void UpdateAccount(Account account)
        {
            // Update account id database logic goes here 
        }
    }
}
