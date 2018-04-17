using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDomoweWF
{
    public class MaxRateClass:ITableColectionable
    {
        public DateTime tDatePub { get; set; }
        public string tType { get; set; }
        public short aK { get; set; }
        public string aKn { get; set; }
        public string eN { get; set; }
        public string eK { get; set; }
        public decimal eV { get; set; }
      
    }
}
