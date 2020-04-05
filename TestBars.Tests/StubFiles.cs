using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.Tests
{
    class StubFiles
    {
        public string GetResulSortString()
        {
            string resul = "|LocalServer         |DbTest              |0,00741             |02.04.2020          |\n+--------------------+--------------------+--------------------+--------------------+\n";
            
            return resul;
        }
        public string GetCreatestring()
        {
            string resulDB = "|Сервер              |База данных         |Размер в ГБ         |Дата обновления     |\n+--------------------+--------------------+--------------------+--------------------+\n|LocalServer         |DbTest              |0,00741             |02.04.2020          |\n+--------------------+--------------------+--------------------+--------------------+\n";
            string resulDrives = "|C:\\                 |Свободно            |62,69174            |05.04.2020          |\n+--------------------+--------------------+--------------------+--------------------+\n";
            string resul = resulDB + resulDrives;
            return resul;
        }
    }
}
