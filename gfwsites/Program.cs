using System.Text;

namespace gfwsites
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(System.Environment.CurrentDirectory);
            foreach(var x in args)
            {
                Console.WriteLine(x);
            }
            var config_file = args[0];
            var config = Configs.LoadConfiguration(config_file);
            var datapath = args[1];
            var savepath = Directory.CreateDirectory("save");
            foreach(var a in config)
            {
                var filename =Path.Combine(savepath.FullName, a.Key);
                var c  = new StringBuilder();
                foreach (var b in a.Value)
                {
                    var datafile = Path.Combine(datapath, b);
                    Console.WriteLine(datafile);
                    var sr = GetData(datafile);
                    if(!string.IsNullOrEmpty(sr) )
                    {
                        c.Append(sr);
                    }
                }
                
                File.WriteAllText(filename, c.ToString().Trim());
            }
        }
        static string GetData(string filename)
        {
            var a = File.ReadAllLines(filename);
            var sb = new StringBuilder();
            foreach (var b in a)
            {
                var c = GetDomain(b);
                if (!string.IsNullOrEmpty(c))
                {
                    sb.AppendLine(c);
                }
            }
            return sb.ToString();
        }
        static string GetDomain(string line)
        {
            if (string.IsNullOrEmpty(line))
                return null;
            var a = line.Trim();
            if (string.IsNullOrEmpty(a))
                return null;
            else if (a.StartsWith("#"))
                return null;
            else if (a.Contains("."))
            {
                if (a.StartsWith("regexp:")|| a.StartsWith("regexp:"))
                {
                    return null;
                }
                if (a.StartsWith("full:"))
                {
                    a = a.Remove(0, 5);
                }
                if (a.Contains("@"))
                {
                    var b = a.Split('@');
                    if (b[1] == "cn")
                        return null;
                    a = b[0].Trim();
                }
                if (a.Contains("#"))
                {
                    var b = a.Split('#');
                    a = b[0].Trim();
                }
                return a;
            }
            else
            {
                return null;
            }



        }

    }
}
