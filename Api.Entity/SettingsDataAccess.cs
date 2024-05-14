using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Api.Entity
{
    public class SettingsDataAccess
    {
        public string name { get; set; }
        public List<SettingsConnection> connections { get; set; }
    }
    public class SettingsConnection
    {
        public string name { get; set; }
        public string server { get; set; }
        public string dataBase { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
    }
}
