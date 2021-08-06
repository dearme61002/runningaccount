using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modols
{/// <summary>
 /// 這裡是實體從這是data的物件就是統計好的一開始出現網頁的資料
 /// </summary>
    public class data
    {
      public  DateTime firstuse { get; set; }
        public DateTime lastuse { get; set; }
        public int usecount { get; set; }
        public int userallcount { get; set; }
    }
}
