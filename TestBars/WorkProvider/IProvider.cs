using Npgsql;
using System.Collections.Generic;

namespace TestBars.WorkProvider
{
    public interface IProvider 
    {
        void Createconnection(string Configurations);
        void OpenConnection();
        IList<List<string>> GetDataReader();
        void CloseConnection();
    }
}
