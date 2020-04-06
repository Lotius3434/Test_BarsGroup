using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars
{
    /// <summary>
    /// Интерфейс объекта, который отвечает за запись данных в txt файл.
    /// </summary>
    public interface IWorkFiles
    {
        /// <summary>
        /// Запись данных в txt файл.
        /// </summary>
        /// <param name="servers">Передает список серверов с данными.</param>
        void WriteFileTxt(IList<IServerObj> servers);
    }
}
