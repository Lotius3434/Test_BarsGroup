namespace TestBars.WorkServersPostgreSql
{
    /// <summary>
    /// Интерфейс для взаимодействия с обьектом, который хранит в себе данные из Db.
    /// </summary>
    public interface IDbObj
    {
        /// <value>Содержит имя DB.</value>
        string name { get; set; }
        /// <value>Содержит размер DB в гигабайтах.</value>
        string size { get; set; }
        /// <value>Содержит дату получения данных из DB.</value>
        string updateDate { get; set; }
    }
}
