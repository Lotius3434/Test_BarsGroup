namespace TestBars.WorkServersPostgreSql
{
    public interface IDbObj
    {
        string name { get; set; }
        string size { get; set; }
        string updateDate { get; set; }
    }
}
