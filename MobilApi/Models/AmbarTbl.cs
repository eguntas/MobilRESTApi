using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Models
{
    public class AmbarTbl
    {
        public AmbarTbl()
        {
            HareketTbl = new HashSet<HareketTbl>();
        }

        public int AmbarId { get; set; }
        public string AmbarAdi { get; set; }

        public ICollection<HareketTbl> HareketTbl { get; set; }
    }
}
