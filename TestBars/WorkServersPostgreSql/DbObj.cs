namespace TestBars.WorkServersPostgreSql
{
    /// <summary>
    /// Класс для хранения данных из DB.
    /// </summary>
    /// <inheritdoc/>
    public class DbObj : IDbObj
    {
        
        private string Name;      
        private string Size;        
        private string UpdateDate;
        /// <value>Содержит название DB.</value>
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
        /// <value>Содержит размер DB, в гигабайтах.</value>
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
        /// <value>Содержит дату получения данных из DB.</value>
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
