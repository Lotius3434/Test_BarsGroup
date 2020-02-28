using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.WorkSheetsGoogle
{
    abstract class AbstractSpreadsheet : ISpreasheet
    {
        public virtual void CreateSheets(string SpreadsheetId, List<string> ListServer, List<IList<IList<object>>> ListInfo)
        {
            
        }

        public virtual string CreateSpreasheet(List<string> ServersName)
        {
            string SpreadsheetId = null;
            return SpreadsheetId;
        }

        public virtual void ScanSheets(string ListId, List<string> ListServer, List<IList<IList<object>>> ListInfo)
        {
          
        }

        public virtual void WriteSheet(string spreadsheet, List<IList<IList<object>>> ListInfo)
        {
            
        }
    }
}
