using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Database.Configurations
{
    public class DatabaseLocal
    {
        public static string DatabasePath {get;} = "Database/Hortifrute.db";

        public static string Path {get;} = Directory.GetCurrentDirectory() + "Database/Hortifrute.db";
        //"Data Source="
    }
}