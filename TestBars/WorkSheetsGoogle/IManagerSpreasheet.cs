using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle
{
    /// <summary>
    /// Интерфейс менеджера управляющего всеми объектами, которые взаимодействуют с goole table и google disk.
    /// </summary>
    interface IManagerSpreasheet
    {
        /// <summary>
        /// Инициализации все компонентов и начало их работы.
        /// </summary>
        /// <param name="servers">Передает список серверов с данными.</param>
        void StartWorkSpreasheet(IList<IServerObj> servers);
    }
}
