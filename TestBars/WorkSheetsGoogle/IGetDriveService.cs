﻿using Google.Apis.Drive.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.WorkSheetsGoogle
{
    interface IGetDriveService
    {
        DriveService GetDriveService();
    }
}
