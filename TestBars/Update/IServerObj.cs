﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.Update
{
    interface IServerObj
    {
        string NameServer { get; }
        string ConnectionParams { get; }
        IList<IDbObj> DataBases { get; }
    }
}
