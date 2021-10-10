using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Models
{
    public class FirmaTbl
    {
        public FirmaTbl()
        {
            KayitTbl = new HashSet<KayitTbl>();
        }

        public int FirmaId { get; set; }
        public string FirmaAdi { get; set; }

        public ICollection<KayitTbl> KayitTbl { get; set; }
    }
}
