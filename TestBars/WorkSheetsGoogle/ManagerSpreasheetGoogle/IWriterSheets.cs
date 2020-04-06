using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    /// <summary>
    /// Интерфейс объекта, который отвечает за запись данных в google лист.
    /// </summary>
    interface IWriterSheets
    {
        /// <summary>
        /// Записывает данные в google лист.
        /// </summary>
        /// <param name="spreadsheet">Передает Id google таблицы</param>
        /// <param name="servers">Передает список серверов с данными.</param>
        /// <param name="sheetService">Передает сервис для взаимодействия с таблицами google.</param>
        void WriteSheet(string spreadsheet, IList<IServerObj> servers, SheetsService sheetService);
    }
}
