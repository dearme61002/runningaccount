using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modols
{/// <summary>
 /// 這裡是實體從這是UserInfo的物件
 /// </summary>
    public class UserInfo
    {
        public string id { get; set; }
        public string account { get; set; }
        public string pwd { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string userlevel { get; set; }
        public DateTime createdate { get; set; }
    }
}
