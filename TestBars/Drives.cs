using System;
using System.Collections.Generic;
using System.IO;

namespace TestBars
{
    public class Drives : IDrives// Класс для работы с жесткими дисками
    {
        public IList<IList<Object>> GetDriveFreeSize()//Метод получает все жесткие диски и свободное место в памяти на них
        {
            IList<IList<Object>> drivesInfo = new List<IList<Object>>() { };
            IList<Object> drives = new List<Object>();

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo MyDriveInfo in allDrives)
            {

                //Fixed
                if (MyDriveInfo.DriveType.ToString() == "Fixed")
                {
                    drives = new List<Object>();
                    drives.Add(MyDriveInfo.Name.ToString());
                    drives.Add("Свободно");
                    drives.Add(Converter.CalculateBytetoGB(MyDriveInfo.TotalFreeSpace));
                    drives.Add(DateTime.Now.ToString("dd.MM.yyyy"));
                    drivesInfo.Add(drives);
                }
                    
                

            }
            return drivesInfo;
        }
    }
}
