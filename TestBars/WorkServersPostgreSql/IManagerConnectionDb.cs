using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    /// <summary>
    /// Интерфейс менеджера управляющего всеми объектами, которые отвечают за получение данных из серверов.
    /// </summary>
    public interface IManagerConnectionDb
    {
        /// <summary>
        /// Метод для возвращения  списока серверов и с списками DB.
        /// </summary>
        /// <returns>Списки серверов с списками DB.Список</returns>
        IList<IServerObj> GetServers();
    }
}
