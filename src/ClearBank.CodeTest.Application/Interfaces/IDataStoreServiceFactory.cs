namespace ClearBank.CodeTest.Application.Interfaces
{
    public interface IDataStoreServiceFactory
    {
        IDataStore GetDataStore(string dataStoreType);
    }
}
