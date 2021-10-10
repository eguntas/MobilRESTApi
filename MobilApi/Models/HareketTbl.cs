using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Models
{
    public class HareketTbl
    {
        public int HareketId { get; set; }
        public int KayitIds { get; set; }
        public int AmbarIds { get; set; }
        public string HareketTipi { get; set; }
        public int? SicilNo { get; set; }
        public int? BolumIds { get; set; }

        public AmbarTbl AmbarIdsNavigation { get; set; }
        public KayitTbl KayitIdsNavigation { get; set; }
    }
}
