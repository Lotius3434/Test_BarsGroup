using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    /// <summary>
    /// Интерфейс объекта, который управляет всеми компонентами, отвечающими за получение данных из серверов.
    /// </summary>
    public interface IManagerConnectionDb
    {
        /// <summary>
        /// Метод для возвращения  списка серверов и с списками DB.
        /// </summary>
        /// <returns>Списки серверов с списками DB.Список</returns>
        IList<IServerObj> GetServers();
    }
}
