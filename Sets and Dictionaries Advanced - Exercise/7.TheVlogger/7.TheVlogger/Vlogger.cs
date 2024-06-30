using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.TheVlogger
{
    public class Vlogger
    {
        public Vlogger(string name)
        {
            Name = name;
            followers = new SortedSet<string>();
        }
        public string Name { get; set; }
        public SortedSet<string> followers { get; set; }
        public int followingCount { get; set; }
    }
}
