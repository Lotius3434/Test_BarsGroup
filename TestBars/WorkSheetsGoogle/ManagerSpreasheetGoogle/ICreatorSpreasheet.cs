using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    /// <summary>
    /// Интерфейс объекта, который создает google таблицу.
    /// </summary>
    interface ICreatorSpreasheet
    {
        /// <summary>
        /// Создает google таблицу.
        /// </summary>
        /// <param name="servers">Передает список с данными серверов</param>
        /// <param name="sheetService">Передает сервис для взаимодействия с таблицами google.</param>
        /// <remarks>
        /// После выполнения метода, вызывает метод объекта: <see cref="IWriterSheets"/> для записи в google лист
        /// <para>Если не удалось соединиться с google api высывается метод объекта <see cref="IWorkFiles"/>.</para>
        /// </remarks>
        void CreateSpreasheet(IList<IServerObj> servers, SheetsService sheetService);
    }
}
