using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.WorkServersPostgreSql;

namespace TestBars.Tests
{
    class StubDbObj : IDbObj
    {
        private string Name = "DbTest";
        private string Size = "0,00741";
        private string UpdateDate = "02.04.2020";

        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                if (Name == null)
                    Name = value;
            }
        }
        public string size
        {
            get
            {
                return Size;
            }
            set
            {
                if (Size == null)
                    Size = value;
            }
        }
        public string updateDate
        {
            get
            {
                return UpdateDate;
            }
            set
            {
                if (UpdateDate == null)
                    UpdateDate = value;
            }
        }
    }
}
