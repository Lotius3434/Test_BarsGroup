using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.UpdateWorkServersPostgreSql
{
    class DbObj : IDbObj
    {
        private readonly string Name;
        private readonly string Size;
        private readonly string UpdateDate;
        public DbObj(string Name, string Size, string UpdateDate)
        {
            if (Name != null && Size != null && UpdateDate != null)
            {
                this.Name = Name;
                this.Size = Size;
                this.UpdateDate = UpdateDate;
            }

        }
        public string name
        {
            get
            {
                return Name;
            }
        }
        public string size
        {
            get
            {
                return Size;
            }
        }
        public string updateDate
        {
            get
            {
                return UpdateDate;
            }
        }


    }
}
