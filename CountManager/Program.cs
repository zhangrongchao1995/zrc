using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, int> d = new Dictionary<string, int>();
            d.Add("type",1);
            Test t = new Test();
            t.age = 14;
            string data = JsonConvert.SerializeObject(d);
            Console.WriteLine(data);
            Console.ReadKey();

        }

    }
    public class Test {
        public int age;
        
    }
}
