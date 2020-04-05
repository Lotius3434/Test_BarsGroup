using System.Collections.Generic;
using TestBars.WorkProvider;

namespace TestBars.Tests
{
    class MockProviderNpgsql : IProvider
    {
        IList<List<string>> DataReader = new List<List<string>>();
        List<string> getdb = new List<string>();
        public void Createconnection(string Configurations)
        {
        
        }
        public void OpenConnection()
        {
            
        }
        public IList<List<string>> GetDataReader()
        {
            getdb.Add("DbTest");
            getdb.Add("0,00741");
            getdb.Add("02.04.2020");
            DataReader.Add(getdb);
            return DataReader;
        }
        public void CloseConnection()
        {
            
        }
    }
}
