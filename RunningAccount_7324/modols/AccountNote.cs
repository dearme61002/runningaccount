using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modols
{
    /// <summary>
    /// 這裡是實體從這是AccountNote的物件
    /// </summary>
    public class AccountNote
    {
        public int id { get; set; }
        public string userid{get;set;}

       public  string caption { get; set; }
        public int amount { get; set; }
        public string acttype { get; set; }
        public DateTime createdate { get; set; }
         
        public string body { get; set; }
    }
}
