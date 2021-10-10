using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Models
{
    public class KayitTbl
    {
        public KayitTbl()
        {
            HareketTbls = new List<HareketTbl>();
        }


        public int KayitId { get; set; }
        public int TupIds { get; set; }
        public int? TupSeriNos { get; set; }
        public int UserIds { get; set; }
        public DateTime? GirisTarih { get; set; }
        public DateTime? CikisTarih { get; set; }
        public int? IrsaliyeGirisNo { get; set; }
        public int? IrsaliyeCikisNo { get; set; }
        public string CikisYapanKisi { get; set; }
        public int? TupDurums { get; set; }
        public int FirmaIds { get; set; }

        public FirmaTbl FirmaIdsNavigation { get; set; }
        public TupTanimTbl TupIdsNavigation { get; set; }
        public List<HareketTbl> HareketTbls { get; set; }
        public KullaniciTbl UserIdsNavigation { get; set; }
    }
}
