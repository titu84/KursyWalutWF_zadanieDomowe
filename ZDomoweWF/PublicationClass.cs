using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDomoweWF
{
    public static class PublicationClass
    {
        //DateTime dNow = new DateTime(2015,12,31);
        private static DateTime dNow = DateTime.Today;
        private static string datePub;

        public static string TableACpublication(string tPub)
        {
            DownloadClass dC = new DownloadClass();
            datePub = null;
            //Nie ma tabeli, nie ma swięta, wcześniej niż 12:45.
            if (!dC.TablePublished(tPub) && !dNow.IsHoliday() && DateTime.Now < dNow.AddHours(12).AddMinutes(45))
            {
                datePub = "Dzisiaj do godziny 12:45";
                return datePub;
            }
            // Jest później niż 12:45, lub jest świeto, lub jest przed 12:45 i jest tabela
            else if (DateTime.Now > (dNow.AddHours(12).AddMinutes(45)) || dNow.IsHoliday() || DateTime.Now <= (dNow.AddHours(12).AddMinutes(45)) && dC.TablePublished(tPub))
            {
                int i = 0;
                do
                {
                    if (i == 10)
                    {
                        break;
                    }
                    else
                    {
                        i++;
                        datePub = dNow.AddDays(i).ToShortDateString();

                    }

                } while (dNow.AddDays(i).IsHoliday());

                return datePub;
            }
            return datePub;
        }

        public static string TableBpublication()
        {
            datePub = null;
            DownloadClass dC = new DownloadClass();
            // Nie ma tabeli, jest środa, nie ma święta, jest przed 12:45.
            if (!dC.TablePublished("b") && dNow.DayOfWeek == DayOfWeek.Wednesday && !dNow.IsHoliday() && DateTime.Now < (dNow.AddHours(12).AddMinutes(45)))
            {
                datePub = "dzisiaj do godziny 12:45";
                return datePub;
            }
            //Jest tabela, dziś środa
            else if (dC.TablePublished("b") && dNow.DayOfWeek == DayOfWeek.Wednesday)
            {
                int x = 7;
                if (!dNow.AddDays(x).IsHoliday())
                {
                    datePub = dNow.AddDays(x).ToShortDateString();
                    return datePub;
                }
                else if (!dNow.AddDays(x + 7).IsHoliday())
                {
                    datePub = dNow.AddDays(x + 7).ToShortDateString();
                    return datePub;
                }
                else
                {
                    datePub = dNow.AddDays(x + 14).ToShortDateString();
                    return datePub;
                }

            }
            // Nie jest środa, lub jest święto
            else if (dNow.DayOfWeek != DayOfWeek.Wednesday || dNow.IsHoliday())
            {
                DateTime nextWedn = dNow.AddDays(((int)DayOfWeek.Wednesday - (int)dNow.DayOfWeek));
                TimeSpan r = nextWedn - dNow;
                //datePub = r.ToString();

                int x = int.Parse(r.TotalDays.ToString());
                if (x <= 0)
                {
                    x = x + 7;
                }

                if (!dNow.AddDays(x).IsHoliday())
                {
                    datePub = dNow.AddDays(x).ToShortDateString();
                    return datePub;
                }
                else if (!dNow.AddDays(x + 7).IsHoliday())
                {
                    datePub = dNow.AddDays(x + 7).ToShortDateString();
                    return datePub;
                }
                else
                {
                    datePub = dNow.AddDays(x + 14).ToShortDateString();
                    return datePub;
                }

            }
            return datePub;
        }
    }
}
