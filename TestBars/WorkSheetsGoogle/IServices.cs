using Google.Apis.Drive.v3;
using Google.Apis.Sheets.v4;

namespace TestBars.WorkSheetsGoogle
{
    /// <summary>
    /// Интерфейс объекта, который Отвечает, за получение сервисов, после аутентификации, пользователя.
    /// </summary>
    public interface IServices 
    {
        /// <summary>
        /// Инициализирует сервис, для работы с google таблицами.
        /// </summary>
        /// <returns>Возвращает сервис для google таблиц.</returns>
        SheetsService GetSheetsService();
        // <summary>
        /// Инициализирует сервис, для работы с google disk.
        /// </summary>
        /// <returns>Возвращает сервис для google disk.</returns>
        DriveService GetDriveService();   
    }
}
