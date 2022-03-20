using CSKH_SSP.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Helpers
{
    public static class Helpers
    {
        //private DataContext _dataContext;

        //public Helpers(DataContext dataContext)
        //{
        //    _dataContext = dataContext;
        //}
        public static double GetCountTime(DateTime startDate, DateTime endDate)
        {
            //startDate = new DateTime(2019, 6, 18, 12, 56, 0);
            //endDate = new DateTime(2019, 6, 18, 13, 56, 0);
            double minute = 0;
            for (DateTime i = startDate; i <= endDate; i = DateTime.ParseExact(i.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).AddDays(1))
            {
                if (i.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (i >= endDate)
                        break;
                    continue;
                }
                bool isR = false;
                //DateTime endTimeTemp = DateTime.ParseExact(i.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).AddTicks(-1).AddDays(1);
                DateTime timeBreak0 = DateTime.ParseExact(i.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).AddHours(7).AddMinutes(30);
                DateTime timeBreak1 = DateTime.ParseExact(i.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).AddHours(12);
                DateTime timeEndBreak1 = DateTime.ParseExact(i.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).AddHours(13);
                DateTime timeBreak2 = DateTime.ParseExact(i.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null).AddHours(16).AddMinutes(30);
                if (i == startDate && i >= timeBreak2)
                    continue;
                if (i == startDate && i > timeBreak1 && i <= timeEndBreak1)
                    isR = true;
                if (timeBreak0 < i && i == startDate && i < timeBreak1)
                    timeBreak0 = i;
                else if (timeEndBreak1 < i && i == startDate && i < timeBreak2)
                    timeEndBreak1 = i;

                if (timeBreak1 > endDate)
                {
                    timeBreak1 = endDate;
                }
                else if (timeBreak2 > endDate)
                {
                    timeBreak2 = endDate;
                }
                if (timeBreak1 > timeBreak0 && timeEndBreak1 != startDate && timeBreak1 < timeEndBreak1 && !isR)
                    minute += (timeBreak1 - timeBreak0).TotalMinutes;
                if (timeBreak1 == endDate)
                    break;
                if (timeBreak2 > timeEndBreak1)
                    minute += (timeBreak2 - timeEndBreak1).TotalMinutes;

            }
            if (minute > 0)
                minute = minute + 1;
            return minute;
        }
    }
}
