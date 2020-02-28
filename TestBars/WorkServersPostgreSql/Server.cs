using Npgsql;
using System;
using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    class Server : AbstractServers //Класс который реализует интерфес взаимодействия с серверами и базами.
    {
        private readonly string Name;
        private readonly string ConnectionParams;      
        private string sqlquery = @"select datname,  pg_database_size(datname)
                     from pg_database;"; // Sql запрос на получения списка всех баз, названий и их размеров.
        private NpgsqlConnection connection;
        private NpgsqlCommand NpgsqlCommand;
        private NpgsqlDataReader result;
        public Server(string Name, string ConnectionParams)
        {
            this.Name = Name;
            this.ConnectionParams = ConnectionParams;

            NpgsqlCommand = new NpgsqlCommand(this.sqlquery, this.connection = new NpgsqlConnection(this.ConnectionParams));
            
        }
        public override void OpenConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("Открыто соединение с базами, сервер: {0}", Name);
                result = NpgsqlCommand.ExecuteReader();
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0}\n{1}", ex.Message, ex.InnerException);
            }
            
        }
        public override void CloseConnection()
        {
            this.connection.Close();
            Console.WriteLine("Закрыто соединение с базами, сервер: {0}", Name);
        }
        public override string GetNameServer()
        {
            return Name;
        }
        public override List<IList<Object>> GetBasesandSizes() // Метод получения данный баз и их данных.
        {
            List<IList<Object>> table = new List<IList<Object>>();


                while (this.result.Read())
                {
                    IList<Object> row = new List<Object>();
                    row.Add(this.Name);
                    row.Add(result.GetString(0));
                    row.Add(Converter.CalculateBytetoGB(result.GetInt64(1)));
                    row.Add(DateTime.Now.ToString("dd.MM.yyyy"));
                    table.Add(row);
                }
                Console.WriteLine("Получение данных из баз, сервер: {0}", Name);
                return table;

        }
        
    }
}
