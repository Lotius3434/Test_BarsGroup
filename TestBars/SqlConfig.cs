namespace TestBars
{
    /// <summary>
    /// Класс содержит строку с sql запросом.
    /// </summary>
    public static class SqlConfig
    {
        public static readonly string sqlquery = @"select datname,  pg_database_size(datname)
                     from pg_database;";
    }
}
