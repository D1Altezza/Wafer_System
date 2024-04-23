using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wafer_System
{
    internal class RecData
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        
        public string Diameter { get; set; }
        public string Diameter_Level { get; set; }
        public string Thickness { get; set; }
        public string Thickness_Level { get; set; }
        public string TTV { get; set; }
        public string TTV_Level { get; set; }
        public string BOW { get; set; }
        public string BOW_Level { get; set; }
        public string WARP { get; set; }
        public string WARP_Level { get; set; }
        public string WaferID { get; set; }
        public string Cassette_Number { get; set; }
        public string Slot { get; set; }
        public string[] LaserRawData { get; set; }
        public bool IsActive { get; set; }
    }

}
