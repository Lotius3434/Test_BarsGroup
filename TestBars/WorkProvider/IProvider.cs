using Npgsql;

namespace TestBars.WorkProvider
{
    public interface IProvider 
    {
        void Createconnection(string Configurations);
        void OpenConnection();
        NpgsqlDataReader GetDataReader();
        void CloseConnection();
    }
}
