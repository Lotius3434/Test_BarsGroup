using Npgsql;


namespace TestBars.WorkProvider
{
    public class ProviderNpgsql : IProvider
    {
        
        NpgsqlConnection connection;
        NpgsqlCommand NpgsqlCommand;
        NpgsqlDataReader DataReader;
        string sqlquery = @"select datname,  pg_database_size(datname)
                     from pg_database;";
        public void Createconnection(string Configurations)
        {
            connection = new NpgsqlConnection(Configurations);
            NpgsqlCommand = new NpgsqlCommand(sqlquery, connection);
        }
        public void OpenConnection()
        {
            connection.Open();
        }
        public NpgsqlDataReader GetDataReader()
        {
            //DataReader = NpgsqlCommand.ExecuteReader();
            return NpgsqlCommand.ExecuteReader();
        }
        public void CloseConnection()
        {
            connection.Close();
        }
    }

    
}
