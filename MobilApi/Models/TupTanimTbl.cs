using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Models
{
    public class TupTanimTbl
    {
        public TupTanimTbl()
        {
            KayitTbl = new HashSet<KayitTbl>();
        }
        public int TupId { get; set; }
        public int? TupSeriNo { get; set; }
        public string TupTipi { get; set; }
        public string TupDurum { get; set; }
        public DateTime? UretimTarih { get; set; }
        public DateTime? SonKullanimTarih { get; set; }
        

      
        public ICollection<KayitTbl> KayitTbl { get; set; }
    }
}
