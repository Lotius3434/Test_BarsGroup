using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.Update
{
    class DbObj : IDbObj
    {
        private readonly string Name;
        private readonly int Size;
        private readonly string UpdateDate;
        public DbObj(string Name, int Size, string UpdateDate)
        {
            if (Name != null)
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
        public int size
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
