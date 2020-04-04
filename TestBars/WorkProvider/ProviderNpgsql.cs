using Npgsql;
using System.Collections.Generic;

namespace TestBars.WorkProvider
{
    public class ProviderNpgsql : IProvider
    {
        
        NpgsqlConnection connection;
        NpgsqlCommand NpgsqlCommand;
        NpgsqlDataReader DataReader;
        List<NpgsqlDataReader> list = new List<NpgsqlDataReader>();
        
        public void Createconnection(string Configurations)
        {
            connection = new NpgsqlConnection(Configurations);
            NpgsqlCommand = new NpgsqlCommand(SqlConfig.sqlquery, connection);
        }
        public void OpenConnection()
        {
            connection.Open();
            DataReader = NpgsqlCommand.ExecuteReader();
        }
        public NpgsqlDataReader GetDataReader()
        {
            return DataReader;
        }
        public void CloseConnection()
        {
            connection.Close();
        }
    }

    
}
