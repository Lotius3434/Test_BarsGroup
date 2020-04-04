using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.Tests
{
    class StubFiles
    {
        public StringBuilder GetBuildeResulSortString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("|LocalServer         |DbTest              |0,00741             |02.04.2020          |\n+--------------------+--------------------+--------------------+--------------------+\n");
            return stringBuilder;
        }
    }
}
