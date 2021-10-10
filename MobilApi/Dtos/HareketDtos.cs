using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Dtos
{
    public class HareketDtos
    {
        public int hareketId { get; set; }
        public int kayitId { get; set; }
        public int ambarId { get; set; }
        public string harekettipi { get; set; }
        public int? sicilno { get; set; }
        public int? bolumId { get; set; }
    }
}
