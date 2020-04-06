using System;
using System.Collections.Generic;
using TestBars.WorkProvider;

namespace TestBars.WorkServersPostgreSql
{
    /// <summary>
    /// Класс управляющий всеми объектами, которые отвечают за получение данных из серверов.
    /// </summary>
    /// <remarks>
    /// 
    /// <para>Для управления всеми компонентами в классе должны быть иньекции через конструктор.</para>
    /// </remarks>
    /// <inheritdoc/>
    public class ManagerConnectionDb : IManagerConnectionDb
    {
        IParseConfiguration parseConfiguration;
        IWriterServers writerServers;
        IProvider provider;
        IList<IServerObj> ListServerObjs = new List<IServerObj>();
        IDictionary<string, string> Configurations;
        IList<List<string>> DataList;
        /// <summary>
        /// Конструктор через который просходят иньекции объектов.
        /// </summary>
        /// <param name="parseConfiguration">Отвечает за парсинг конфигураций серверов.</param>
        /// <param name="writerServers">Отвечает сортировку данных,полученных из DB, по объектам для хранения.</param>
        /// <param name="provider">Отвечает за соединение, возврат данных из Db.</param>
        public ManagerConnectionDb(IParseConfiguration parseConfiguration, IWriterServers writerServers, IProvider provider)
        {
            if (parseConfiguration != null)
            {
                this.parseConfiguration = parseConfiguration;
                this.writerServers = writerServers;
                this.provider = provider;
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
                        provider.Createconnection(_Configurations.Value);
                        provider.OpenConnection();
                        DataList = provider.GetDataReader();
                        writerServers.CreateServerObj(_Configurations.Key);
                        foreach (var _DataList in DataList)
                        {
                            string nameDb = _DataList[0];
                            string sizeDb = _DataList[1];
                            string updateDateDb = _DataList[2];

                            writerServers.WriteServerObjs(nameDb, sizeDb, updateDateDb);
                        }

                        ListServerObjs.Add(writerServers.GetServerObj());

                        provider.CloseConnection();   
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
