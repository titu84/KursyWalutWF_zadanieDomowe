using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDomoweWF
{
   public class TableXMLC : ITableXMLable
    {
        public string kod_waluty { get; set; }
        public string kurs_kupna { get; set; }
        public string kurs_sprzedazy { get; set; }
        public string nazwa_waluty { get; set; }
        public string przelicznik { get; set; }

    }
}



