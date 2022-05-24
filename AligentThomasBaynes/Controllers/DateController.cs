using AligentThomasBaynes.Enums;
using AligentThomasBaynes.Models;
using AligentThomasBaynes.Services;
using System;
using System.Web.Http;

namespace AligentThomasBaynes.Controllers
{
    public class DateController : ApiController
    {
        private DateRepository dateRepository;

        public DateController()
        {
            this.dateRepository = new DateRepository();
        }

        public DateResult DaysBetween(DateTimeOffset dateOne, DateTimeOffset dateTwo, DateType? convertTo = null)
        {
            if (convertTo.HasValue)
            {
                return dateRepository.DaysBetween(dateOne, dateTwo, convertTo.Value);
            }
            return dateRepository.DaysBetween(dateOne, dateTwo);
        }

        public DateResult WorkingDaysBetween(DateTimeOffset dateOne, DateTimeOffset dateTwo, DateType? convertTo = null)
        {
            if (convertTo.HasValue)
            {
                return dateRepository.WorkingDaysBetween(dateOne, dateTwo, convertTo.Value);
            }
            return dateRepository.WorkingDaysBetween(dateOne, dateTwo);
        }

        public DateResult CompleteWeeksBetween(DateTimeOffset dateOne, DateTimeOffset dateTwo, DateType? convertTo = null)
        {
            if (convertTo.HasValue)
            {
                return dateRepository.CompleteWeeksBetween(dateOne, dateTwo, convertTo.Value);
            }
            return dateRepository.CompleteWeeksBetween(dateOne, dateTwo);
        }
    }
}
