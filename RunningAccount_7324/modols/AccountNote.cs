using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modols
{
    public class AccountNote
    {
        public int id { get; set; }
        public string userid{get;set;}

       public  string caption { get; set; }
        public int amount { get; set; }
        public int acttype { get; set; }
        public DateTime createdate { get; set; }
         
        public string body { get; set; }
    }
}
