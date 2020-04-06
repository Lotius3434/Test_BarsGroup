using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    /// <summary>
    /// Интерфейс объекта, который сканирует таблицу, на наличие листов для каждого сервера.
    /// </summary>
    interface IScanerSheets
    {
        /// <summary>
        /// Сканирует листы в существующей таблицы.
        /// <para>Eсли лист не найден, вызывается метод объекта: <see cref="ICreatorSheets"/></para> 
        /// <para>Eсли лист найден, вызывается метод объекта: <see cref="IWriterSheets"/> и данные у листа обновляются.</para> 
        /// </summary>
        /// <param name="ListId">Передает Id google таблицы.</param>
        /// <param name="servers">Передает список серверов с данными.</param>
        /// <param name="sheetService">Передает сервис для взаимодействия с таблицами google.</param>
        void ScanSheets(string ListId, IList<IServerObj> servers, SheetsService sheetService);
    }
}
