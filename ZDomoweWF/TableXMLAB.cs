using System;

namespace ZDomoweWF
{
    public class TableXMLAB : ITableXMLable
    {
        public string nazwa_waluty { get; set; }
        public string przelicznik { get; set; }
        public string kod_waluty { get; set; }
        public string kurs_sredni { get; set; }
        
    }
}
