using ClearBank.CodeTest.Domain.Models;

namespace ClearBank.CodeTest.Infrastructure.Interfaces
{
    public interface IBackupAccountDataStoreService
    {
        Account GetAccount(string accountNumber);

        void UpdateAccount(Account account);
    }
}
