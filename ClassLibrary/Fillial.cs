using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Fillial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pref { get; set; }
        public List<Manager> Managers { get; set; }
    }
}
