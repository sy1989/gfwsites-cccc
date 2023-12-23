using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gfwsites
{
    internal class Configs
    {
        public static Configs LoadConfiguration(string filename)
        {
            TextReader reader = new StreamReader(filename);
            string json = reader.ReadToEnd();
            reader.Close();
            Configs config = JsonConvert.DeserializeObject<Configs>(json);
            return config;
        }
        public Dictionary<string, List<string>> Config { get; set; }
    }
}
