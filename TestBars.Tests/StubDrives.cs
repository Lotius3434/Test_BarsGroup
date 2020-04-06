using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.Tests
{
    class StubDrives : IDrives
    {
        public IList<IList<Object>> GetDriveFreeSize()//Метод получает все жесткие диски и свободное место в памяти на них
        {
            IList<IList<Object>> drivesInfo = new List<IList<Object>>() { };
            IList<Object> drives = new List<Object>();

            drives = new List<Object>();
            drives.Add(@"C:\");
            drives.Add("Свободно");
            drives.Add("62,69174");
            drives.Add("05.04.2020");
            drivesInfo.Add(drives);

            return drivesInfo;
        }
    }
}
