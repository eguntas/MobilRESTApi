using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Models
{
    public class BolumTbl
    {
        public BolumTbl()
        {
            KullaniciTbl = new HashSet<KullaniciTbl>();
        }

        public int BolumId { get; set; }
        public string BolumAdi { get; set; }

        public ICollection<KullaniciTbl> KullaniciTbl { get; set; }
    }
}
