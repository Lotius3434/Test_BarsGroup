using Npgsql;


namespace TestBars.WorkProvider
{
    public class ProviderNpgsql : IProvider
    {
        
        NpgsqlConnection connection;
        NpgsqlCommand NpgsqlCommand;
        NpgsqlDataReader DataReader;
        public void Createconnection(string Configurations)
        {
            connection = new NpgsqlConnection(Configurations);
            NpgsqlCommand = new NpgsqlCommand(SqlConfig.sqlquery, connection);
        }
        public void OpenConnection()
        {
            connection.Open();
        }
        public NpgsqlDataReader GetDataReader()
        {
            DataReader = NpgsqlCommand.ExecuteReader();
            return DataReader;
        }
        public void CloseConnection()
        {
            connection.Close();
        }
    }

    
}
