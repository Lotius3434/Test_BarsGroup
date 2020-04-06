using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    /// <summary>
    /// Интерфейс взаимодействия с объектом, который хранит в себе данные сервера и список DB.
    /// </summary>
    public interface IServerObj
    {
        /// <value>Содержит название сервера.</value>
        string NameServer { get; set; }
        /// <value>Содержит список Db.</value>
        IList<IDbObj> DataBases { get; set; }
    }
}
