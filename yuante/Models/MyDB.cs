using MoreNote.Logic.Entity;

using System.IO;
using System.Text.Json;

namespace yuante
{
    public class MyDB
    {
       public AppInfo[] AppInfos { get;set;}
        


        public static MyDB ReadJsonFile()
        {
            string json=File.ReadAllText("db.json");
            var app = JsonSerializer.Deserialize<MyDB>(json);
            return app;
               
        }


    }
}
