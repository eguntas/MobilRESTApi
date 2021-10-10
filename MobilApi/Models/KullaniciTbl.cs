using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Models
{
    public class KullaniciTbl
    {
        public KullaniciTbl()
        {
            KayitTbls = new HashSet<KayitTbl>();
        }
        
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public string Kripto { get; set; }
        public int? BolumIds { get; set; }

        public BolumTbl BolumIdsNavigation { get; set; }
        public ICollection<KayitTbl> KayitTbls { get; set; }
    }
}
