using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars
{
    /// <summary>
    /// Интерфейс объекта, который отвечает за получения списка жестких дисков и размер свободного места на них.
    /// </summary>
    public interface IDrives
    {
        /// <summary>
        /// Начинает поиск жестких дисков, заполняет  результат в список.
        /// </summary>
        /// <returns>Список названий жестких дисков, размер свободного места на них, дата заполнения данных.</returns>
        IList<IList<Object>> GetDriveFreeSize();
    }
}
