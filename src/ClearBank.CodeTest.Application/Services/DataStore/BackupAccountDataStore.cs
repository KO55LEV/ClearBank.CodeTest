using ClearBank.CodeTest.Application.Interfaces;
using ClearBank.CodeTest.Domain.Models;
using ClearBank.CodeTest.Infrastructure.Interfaces;

namespace ClearBank.CodeTest.Application.Services.DataStore
{
    internal class BackupAccountDataStore : IDataStore
    {

        private readonly IBackupAccountDataStoreService _backupAccountDataStoreService;

        public BackupAccountDataStore(IBackupAccountDataStoreService backupAccountDataStoreService)
        {
            _backupAccountDataStoreService = backupAccountDataStoreService;
        }

        public Account GetAccount(string accountNumber)
        {
            return _backupAccountDataStoreService.GetAccount(accountNumber);
        }

        public void UpdateAccount(Account account)
        {
            _backupAccountDataStoreService.UpdateAccount(account);
        }
    }
}
