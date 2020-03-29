using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.Update
{
    interface IDbObj
    {
        string name { get; }
        int size { get; }
        string updateDate { get; }
    }
}
