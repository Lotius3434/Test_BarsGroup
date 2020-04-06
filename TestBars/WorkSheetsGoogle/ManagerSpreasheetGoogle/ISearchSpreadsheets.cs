using Google.Apis.Drive.v3;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    /// <summary>
    /// Интерфейс объекта, который ищет таблицы в google disk, по названию.
    /// </summary>
    public interface ISearchSpreadsheets
    {
        /// <summary>
        /// Ищет таблицы в google disk, по названию.
        /// </summary>
        /// <param name="servers">Передает список серверов с данными.</param>
        /// <param name="driveService">Передает сервис для взаимодействия c google disk/</param>
        /// <returns>Возвращает id таблицы, если она нашлась. По умолчанию возвращает: null</returns>
        string Search(IList<IServerObj> servers, DriveService driveService);
    }
}
