using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace ZDomoweWF
{
    public class DownloadClass
    {
        // Sprawdza czy jest połączenie z stroną nbp.pl.
        public bool NetTest()
        {
            try
            {
                WebClient wC = new WebClient();
                var dS = wC.OpenRead("http://www.nbp.pl");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Pobiera pełną listę nazw tabel - zwraca listę
        public List<string> NamesOfT()
        {
            try
            {
                WebClient wC = new WebClient();
                var dS = wC.OpenRead("http://www.nbp.pl/kursy/xml/dir.txt");
                var sR = new StreamReader(dS);
                string line = sR.ReadLine();
                List<string> tT = new List<string>();
                while ((line = sR.ReadLine()) != null)
                {
                    if (line == null)
                    {
                        break;
                    }
                    tT.Add(line);

                }
                return tT;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Sprawdź połączenie z internetem. " + ex.Message);
                return null;
            }

        }
        //Modyfikuje listę tabel na Literę i Datę - zwraca listę
        public List<TableColectionClass> TypeAndDateOfT()
        {

            DownloadClass dC = new DownloadClass();
            List<TableColectionClass> allTables = new List<TableColectionClass>();
            foreach (var item in dC.NamesOfT())
            {
                allTables.Add(new TableColectionClass { tType = item.Substring(0, 1), tDatePub = DateTime.ParseExact(item.Substring(5, 6), "yyMMdd", null) });
            }

            return allTables;
        }
        //Wybiera Tabele po literze i zakresie dat - zwraca listę
        public List<TableColectionClass> TypedOfT(string t, DateTime fr, DateTime to)
        {
            var typedTables = (from p in TypeAndDateOfT()
                               where p.tType == t && p.tDatePub >= fr && p.tDatePub <= to
                               select p
                   ).ToList();
            return typedTables;
        }
        //Sprawdza czy jst opublikowana tabela.
        public bool TablePublished(string t)
        {
            try
            {
                var ifPubd = (from p in NamesOfT()
                              where p.StartsWith(t) && p.Contains("z" + DateTime.Now.ToString("yyMMdd"))
                              select p
                              ).FirstOrDefault().ToString();
                if (ifPubd != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        //Tworzy string do tabeli XML.
        public string tUri(string t, DateTime d)
        {

            var u = (from p in NamesOfT()
                     where p.StartsWith(t) && p.Contains("z" + d.ToString("yyMMdd"))
                     select p
                     ).FirstOrDefault();
            StringBuilder sB1 = new StringBuilder();
            string webA = (sB1.Append("http://www.nbp.pl/kursy/xml/").Append(u).Append(".xml")).ToString();
            return webA;
        }
        //Pobiera elementy z pliku XML - zwraca listę
        public List<TableXMLAB> CurrentTableAB(string webA)
        {
            XElement tableXML = XElement.Load(webA);
            List<TableXMLAB> tableAB = new List<TableXMLAB>();
            var allItems = (from p in tableXML.Elements("pozycja")
                            select p).ToList();
            foreach (var item in allItems)
            {
                tableAB.Add(new TableXMLAB { nazwa_waluty = item.Element("nazwa_waluty").Value, kod_waluty = item.Element("kod_waluty").Value, kurs_sredni = item.Element("kurs_sredni").Value, przelicznik = item.Element("przelicznik").Value });
            }
            return tableAB;
        }
        //Pobiera elementy z pliku XML - zwraca listę
        public List<TableXMLC> CurrentTableC(string webA)
        {
            XElement tableXML = XElement.Load(webA);
            List<TableXMLC> tableC = new List<TableXMLC>();
            var allItems = (from p in tableXML.Elements("pozycja")
                            select p).ToList();
            foreach (var item in allItems)
            {
                tableC.Add(new TableXMLC { nazwa_waluty = item.Element("nazwa_waluty").Value, kod_waluty = item.Element("kod_waluty").Value, przelicznik = item.Element("przelicznik").Value, kurs_kupna = item.Element("kurs_kupna").Value, kurs_sprzedazy = item.Element("kurs_sprzedazy").Value });
            }

            return tableC;
        }
        //Pobiera dane do oliczenia maksymalnego kursu.
        public List<MaxRateClass> AllTablesRates(string webB)
        {
            string typeT = webB.Substring(28, 1);
            DateTime dateT = DateTime.ParseExact(webB.Substring(33, 6), "yyMMdd", null);
            List<MaxRateClass> tableR = new List<MaxRateClass>();
            if (typeT == "a" || typeT == "b")
            {
                var allItems = (from p in CurrentTableAB(webB)
                                select p).ToList();
                foreach (var item in allItems)
                {
                    tableR.Add(new MaxRateClass { tDatePub = dateT, tType = typeT, aK = 0, aKn = "kurs sredni", eN = item.nazwa_waluty, eK = item.kod_waluty, eV = Convert.ToDecimal(item.kurs_sredni) });
                }
            }
            if (typeT == "c")
            {
                var allItems = (from p in CurrentTableC(webB)
                                select p).ToList();
                foreach (var item in allItems)
                {
                    tableR.Add(new MaxRateClass { tDatePub = dateT, tType = typeT, aK = 1, aKn = "kurs kupna", eN = item.nazwa_waluty, eK = item.kod_waluty, eV = Convert.ToDecimal(item.kurs_kupna) });
                    tableR.Add(new MaxRateClass { tDatePub = dateT, tType = typeT, aK = 2, aKn = "kurs sprzedazy", eN = item.nazwa_waluty, eK = item.kod_waluty, eV = Convert.ToDecimal(item.kurs_sprzedazy) });
                }
            }

            return tableR;
        }

        //Pobiera typ tabeli z pliku XML.
        public string FileTableType(string filename)
        {

            XElement tableType = XElement.Load(filename);
            var typ = (from p in tableType.Attributes("typ")
                       select p).FirstOrDefault();

            return typ.ToString().Substring(5, 1).ToLower();
        }

    }
}




