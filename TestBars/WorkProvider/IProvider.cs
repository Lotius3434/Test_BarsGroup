using Npgsql;
using System.Collections.Generic;

namespace TestBars.WorkProvider
{   /// <summary>
    /// Интерфейс для взамодействия с базой данных
    /// </summary>
    public interface IProvider 
    {
        /// <summary>
        /// Создает соединение 
        /// </summary>
        /// <param name="Configurations">Передает конфигурацию для соединение с DB. </param>
        void Createconnection(string Configurations);
        /// <summary>
        /// Открывает соединение 
        /// </summary>
        void OpenConnection();
        /// <summary>
        /// Метод для получения данных из DB, во время получения формирует в себе списки с данными.
        /// </summary>
        /// <returns>Возврашает готовый список с данными.</returns>
        IList<List<string>> GetDataReader();
        /// <summary>
        /// Закрывает соединение.
        /// </summary>
        void CloseConnection();
    }
}
