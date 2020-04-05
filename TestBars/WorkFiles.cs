using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using TestBars.WorkServersPostgreSql;

namespace TestBars
{
    public class WorkFiles : IWorkFiles
    {
        IDrives drives;
        public WorkFiles(IDrives drives)
        {
            this.drives = drives;
        }
        public string SortString(IList<string> liststring )
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < liststring.Count; i++)
            {


                int sizestring = 0;



                stringBuilder.Append("|");
                stringBuilder.Append(liststring[i]);
                sizestring = 20 - liststring[i].Length;
                stringBuilder.Append(' ', sizestring);

                if (i == liststring.Count - 1)
                {
                    stringBuilder.Append("|");
                    stringBuilder.Append("\n");
                    for (int a = 0; a < 4; a++)
                    {
                        stringBuilder.Append("+");
                        stringBuilder.Append('-', 20);
                        if (a == 3)
                        {
                            stringBuilder.Append("+");
                            stringBuilder.Append("\n");
                        }
                    }


                }
            }
            string resul = stringBuilder.ToString();
            return resul;
        }
        public string Createstring(IList<IServerObj> servers)
        {
            StringBuilder stringBuilder = new StringBuilder();
            IList<string> FirstLineNames = new List<string>()
            {
                    "Сервер",
                    "База данных",
                    "Размер в ГБ",
                    "Дата обновления"
            };

            stringBuilder.Append(SortString(FirstLineNames));

            foreach (var _server in servers)
            {
                foreach (var db in _server.DataBases)
                {
                    IList<string> listdb = new List<string>()
                    {

                    };

                    listdb.Add(_server.NameServer);
                    listdb.Add(db.name);
                    listdb.Add(db.size);
                    listdb.Add(db.updateDate);

                    stringBuilder.Append(SortString(listdb));


                }

                IList<IList<Object>> DriveFreeSize = drives.GetDriveFreeSize();
                IList<string> listDrive = new List<string>();
                foreach (var _DriveFreeSize in DriveFreeSize)
                {
                    foreach (var _collection in _DriveFreeSize)
                    {
                        listDrive.Add(_collection.ToString());  
                    }
                    
                }

                stringBuilder.Append(SortString(listDrive));
            }
            string resul = stringBuilder.ToString();
            return resul;


        }
        public void WriteFileTxt(IList<IServerObj> servers)
        {
            string ResulString = Createstring(servers);
            var file = new FileInfo(ConfigurationManager.AppSettings["PathFileTxt"]);
            using (FileStream fileStream = file.Open(FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter Writer = new StreamWriter(fileStream);
                Writer.WriteLine(ResulString);
                Writer.Close();
            }
        }
    }
}
