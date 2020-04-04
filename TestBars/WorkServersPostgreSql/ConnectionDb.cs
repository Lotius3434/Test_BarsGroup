using Castle.Windsor;
using Npgsql;
using System;
using System.Collections.Generic;


namespace TestBars.WorkServersPostgreSql
{
    public class ConnectionDb : IConnectionDb
    {
       
        IParseConfiguration parseConfiguration;
        IWriterServers writerServers;
        IList<IServerObj> ListServerObjs = new List<IServerObj>();
        IDictionary<string, string> Configurations;
      
        public ConnectionDb(IParseConfiguration parseConfiguration, IWriterServers writerServers)
        {
            if (parseConfiguration != null)
            {
                this.parseConfiguration = parseConfiguration;
                this.writerServers = writerServers;
            }
            
        }
        public IList<IServerObj> GetServers()
        {
            Configurations = parseConfiguration.GetConfigServers_Npgsql();
            if (Configurations != null)
            {
                
                foreach (var _Configurations in Configurations)
                {
                    
                    try
                    {
                        using (NpgsqlConnection connection = new NpgsqlConnection(_Configurations.Value))
                        {
                            NpgsqlCommand NpgsqlCommand = new NpgsqlCommand(SqlConfig.sqlquery,connection);
                            NpgsqlDataReader DataReader;
                           
                            connection.Open();
                            DataReader = NpgsqlCommand.ExecuteReader();


                            writerServers.CreateServerObj(_Configurations.Key);

                            while (DataReader.Read())
                            { 
                                string nameDb = DataReader.GetString(0);
                                string sizeDb = Converter.CalculateBytetoGB(DataReader.GetInt64(1));
                                string updateDateDb = DateTime.Now.ToString("dd.MM.yyyy");
                                writerServers.WriteServerObjs(nameDb, sizeDb, updateDateDb);
                            }
                           
                            ListServerObjs.Add(writerServers.GetServerObj());

                            connection.Close();
                        }

                    }
                    catch(Exception e)
                    {
                        string[] code = e.Message.Split(':');
                        string ExceptionMessage;
                        switch (code[0])
                        {
                            case "28P01":
                                ExceptionMessage = "Не правильный пароль или User Id, для подключения к серверу";
                                break;
                            
                            default:
                                ExceptionMessage = e.Message;
                                break;
                        }

                        Console.WriteLine("Ошибка: {0}\nНажмите любую кнопку для закрытия программы", e.Message);
                        Console.ReadKey();
                        Environment.Exit(1);
                        
                    }
                    
                }
            }
            return ListServerObjs;
        }
    }
}
