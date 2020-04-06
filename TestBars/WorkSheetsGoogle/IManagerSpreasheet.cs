using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle
{
    /// <summary>
    /// Интерфейс объекта управляющего всеми компонентами, которые взаимодействуют с goole table и google disk.
    /// </summary>
    interface IManagerSpreasheet
    {
        /// <summary>
        /// Инициализации всех компонентов и начало их работы.
        /// </summary>
        /// <param name="servers">Передает список серверов с данными.</param>
        void StartWorkSpreasheet(IList<IServerObj> servers);
    }
}
