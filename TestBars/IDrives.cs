using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars
{
    public interface IDrives
    {
        IList<IList<Object>> GetDriveFreeSize();
    }
}
