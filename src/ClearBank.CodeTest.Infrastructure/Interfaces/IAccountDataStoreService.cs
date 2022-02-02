using ClearBank.CodeTest.Domain.Models;

namespace ClearBank.CodeTest.Infrastructure.Interfaces
{
    public interface IAccountDataStoreService
    {
        Account GetAccount(string accountNumber);

        void UpdateAccount(Account account);
    }
}
