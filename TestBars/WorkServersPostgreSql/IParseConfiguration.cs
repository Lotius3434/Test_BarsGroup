using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    /// <summary>
    /// Интерфейс объекта, который сканирует и собирает настройки серверов из файла App.config.
    /// </summary>
    public interface IParseConfiguration
    {
        /// <summary>
        /// Сканирует, собирает и возвращает, настройки серверов из файла App.config.
        /// </summary>
        /// <returns>Словарь, ключ: название сервера, значение: конфигурации для соединения с сервером.</returns>
        Dictionary<string, string> GetConfigServers_Npgsql();
    }
}
