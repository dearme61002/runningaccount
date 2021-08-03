using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modols
{
   public  class UserInfo
    {
        public string id { get; set; }
        public string account { get; set; }
        public string pwd { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int userlevel { get; set; }
        public DateTime createdate { get; set; }
    }
}
