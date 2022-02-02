using ClearBank.CodeTest.Application.Interfaces;
using ClearBank.CodeTest.Application.Services.DataStore;
using ClearBank.CodeTest.Infrastructure.Interfaces;

namespace ClearBank.CodeTest.Application.Factories
{
    public class DataStoreServiceFactory : IDataStoreServiceFactory
    {
        private readonly IAccountDataStoreService _accountDataStoreService;
        private readonly IBackupAccountDataStoreService _backupAccountDataStoreService;

        private const string DataStoreName = "Backup";

        public DataStoreServiceFactory(
            IAccountDataStoreService accountDataStoreService,
            IBackupAccountDataStoreService backupAccountDataStoreService
            )
        {
            _accountDataStoreService = accountDataStoreService;
            _backupAccountDataStoreService = backupAccountDataStoreService;
        }

        public IDataStore GetDataStore(string dataStoreType)
        {
            if (String.Equals(dataStoreType, DataStoreName, StringComparison.OrdinalIgnoreCase))
            {
                return new BackupAccountDataStore(_backupAccountDataStoreService);
            }
            else
            {
                return new AccountDataStore(_accountDataStoreService);
            }
        }
    }
}
