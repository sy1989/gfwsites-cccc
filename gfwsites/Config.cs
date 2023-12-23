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
        public static Dictionary<string, List<string>> LoadConfiguration(string filename)
        {
            TextReader reader = new StreamReader(filename);
            string json = reader.ReadToEnd();
            reader.Close();
            var config = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
            return config;
        }
        
    }
}
