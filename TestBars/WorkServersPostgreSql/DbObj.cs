namespace TestBars.WorkServersPostgreSql
{
    public class DbObj : IDbObj
    {
        private  string Name;
        private  string Size;
        private  string UpdateDate;
        
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
