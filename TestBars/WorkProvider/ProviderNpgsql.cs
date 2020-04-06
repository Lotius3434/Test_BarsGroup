using Npgsql;
using System;
using System.Collections.Generic;

namespace TestBars.WorkProvider
{
    /// <summary>
    /// Класс для взаимодействия c провайдером Npgsql.
    /// </summary>
    /// <inheritdoc/>
    public class ProviderNpgsql : IProvider
    {
        
        NpgsqlConnection connection;
        NpgsqlCommand NpgsqlCommand;
        NpgsqlDataReader DataReader;
        IList<List<string>> DataList = new List<List<string>>();
        
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
        public IList<List<string>> GetDataReader()
        { 
            while (DataReader.Read())
            {
                List<string> DataReaderResul = new List<string>();

                DataReaderResul.Add(DataReader.GetString(0));
                DataReaderResul.Add(Converter.CalculateBytetoGB(DataReader.GetInt64(1)));
                DataReaderResul.Add(DateTime.Now.ToString("dd.MM.yyyy"));

                DataList.Add(DataReaderResul);
            }
            return DataList;
        }
        public void CloseConnection()
        {
            connection.Close();
        }
    }

    
}
