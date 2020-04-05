using Google.Apis.Drive.v3;
using Google.Apis.Sheets.v4;

namespace TestBars.WorkSheetsGoogle
{
    public interface IServices 
    {
        SheetsService GetSheetsService();
        DriveService GetDriveService();   
    }
}
