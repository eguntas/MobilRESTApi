using MobilApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Dtos
{
    public class KayitDtos
    {
        public KayitDtos()
        {
            hareketTbls = new List<HareketTbl>();
        }
        public int KayitId { get; set; }
        public int TupId { get; set; }
        public int? TupSeriNo { get; set; }
        public int UserId { get; set; }
        public DateTime? GirisTarih { get; set; }
        public DateTime? CikisTarih { get; set; }
        public int? IrsaliyeGirisNo { get; set; }
        public int? IrsaliyeCikisNo { get; set; }
        public string CikisYapan { get; set; }
        public int? TupDurum { get; set; }
        public int FirmaId { get; set; }
        //public int HareketId { get; set; }
        public List<HareketTbl> hareketTbls { get; set; }
    }
}
