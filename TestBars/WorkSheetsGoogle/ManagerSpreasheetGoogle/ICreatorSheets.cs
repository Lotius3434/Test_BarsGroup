using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    /// <summary>
    /// Интерфейс объекта, который создает google лист, в существующей google таблице.
    /// </summary>
    interface ICreatorSheets
    {
        /// <summary>
        /// Создает google лист, в google таблице.
        /// </summary>
        /// <remarks>
        /// <para>Метод вызывается объектом <see cref="IScanerSheets"/> если в таблице, не было найдено листа с названием сервера.</para>
        /// <para>После того как метод отработал, он вызывает метод объекта <see cref="IWriterSheets"/> для заполнения листа данными.</para>
        /// </remarks>
        /// <param name="SpreadsheetId">Передает Id google таблицы.</param>
        /// <param name="ListServer">Передает список названий серверов, у который не создан лист в таблице.</param>
        /// <param name="servers">Передает список серверов с данными.</param>
        /// <param name="sheetService">Передает сервис для взаимодействия с таблицами google.</param>
        void CreateSheets(string SpreadsheetId, List<string> ListServer, IList<IServerObj> servers, SheetsService sheetService);
    }
}
