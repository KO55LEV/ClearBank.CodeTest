using ClearBank.CodeTest.Domain.Models;

namespace ClearBank.CodeTest.Application.Interfaces
{
    public interface IDataStore
    {
        Account GetAccount(string accountNumber);

        void UpdateAccount(Account account);
    }
}
