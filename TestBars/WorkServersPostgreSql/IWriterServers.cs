using Npgsql;
using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    /// <summary>
    /// Интерфейс объекта, который сортирует данные полученные из DB, по объектам для хранения.
    /// </summary>
    public interface IWriterServers
    {
        /// <summary>
        /// Создает объект сервера <see cref="IServerObj"/> для дальнейшего его заполнения.
        /// </summary>
        /// <param name="ServerName">Передает название сервера </param>
        void CreateServerObj(string ServerName);
        /// <summary>
        /// Создает и заполняет за одну итерацию, один объект <see cref="IDbObj"/>, добавляет все объекты в список.
        /// </summary>
        /// <param name="nameDb">Передает название Db</param>
        /// <param name="sizeDb">Передает размер Db</param>
        /// <param name="updateDateDb">Передает дату получения данных из DB</param>
        void WriteServerObjs(string nameDb, string sizeDb, string updateDateDb);
        /// <summary>
        /// Возвращает объект <see cref="IServerObj"/>, заполненный данными.
        /// </summary>
        /// <returns>Возвращает заполненный объект.</returns>
        IServerObj GetServerObj();
    }
}
