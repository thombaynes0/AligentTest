using AligentThomasBaynes.Enums;
using AligentThomasBaynes.Models;
using System;
using System.Linq;

namespace AligentThomasBaynes.Services
{
    public class DateRepository
    {
        public DateResult DaysBetween(DateTimeOffset dateOne, DateTimeOffset dateTwo, DateType? convertTo = null)
        {
            var daysBetween = Math.Abs(dateOne.ToUniversalTime().Subtract(dateTwo.ToUniversalTime()).TotalDays);

            if (convertTo.HasValue)
            {
                return ConvertTimeTo(daysBetween, DateType.Days, convertTo.Value);
            }

            return new DateResult
            {
                Value = (int)daysBetween,
                CurrentType = DateType.Days,
            };
        }

        public DateResult WorkingDaysBetween(DateTimeOffset dateOne, DateTimeOffset dateTwo, DateType? convertTo = null)
        {
            var dayDifference = (int)Math.Abs(dateOne.ToUniversalTime().Subtract(dateTwo.ToUniversalTime()).TotalDays);
            var workingDaysBetween = Enumerable
                .Range(1, dayDifference)
                .Select(x => dateOne.ToUniversalTime().AddDays(x))
                .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);

            if (convertTo.HasValue)
            {
                return ConvertTimeTo(workingDaysBetween, DateType.Days, convertTo.Value);
            }

            return new DateResult
            {
                Value = workingDaysBetween,
                CurrentType = DateType.Days
            };
        }

        public DateResult CompleteWeeksBetween(DateTimeOffset dateOne, DateTimeOffset dateTwo, DateType? convertTo = null)
        {
            int numberOfWeeks = (int)Math.Abs(Math.Round((dateOne.ToUniversalTime() - dateTwo.ToUniversalTime()).TotalDays / 7));

            if (convertTo.HasValue)
            {
                return ConvertTimeTo(numberOfWeeks, DateType.Weeks, convertTo.Value);
            }

            return new DateResult
            {
                Value = numberOfWeeks,
                CurrentType = DateType.Weeks
            };
        }

        private DateResult ConvertTimeTo(double val, DateType valType, DateType toValType)
        {
            if (valType == DateType.Days)
            {
                switch (toValType)
                {
                    case DateType.Seconds:
                        return new DateResult
                        {
                            Value = Math.Truncate(val * 86400),
                            CurrentType = DateType.Seconds
                        };
                    case DateType.Minutes:
                        return new DateResult {
                            Value = Math.Truncate(val * 1440),
                            CurrentType = DateType.Minutes
                        };
                    case DateType.Hours:
                        return new DateResult
                        {
                            Value = Math.Truncate(val * 24),
                            CurrentType = DateType.Hours
                        };
                    case DateType.Years:
                        return new DateResult
                        {
                            Value = Math.Truncate(val / 365),
                            CurrentType = DateType.Years
                        };
                    default:
                        break;
                }

            } else if (valType == DateType.Weeks)
            {
                switch (toValType)
                {
                    case DateType.Seconds:
                        return new DateResult
                        {
                            Value = Math.Truncate(val * 604800),
                            CurrentType = DateType.Seconds
                        };
                    case DateType.Minutes:
                        return new DateResult
                        {
                            Value = Math.Truncate(val * 10080),
                            CurrentType = DateType.Minutes
                        };
                    case DateType.Hours:
                        return new DateResult
                        {
                            Value = Math.Truncate(val * 168),
                            CurrentType = DateType.Hours
                        };
                    case DateType.Years:
                        return new DateResult
                        {
                            Value = Math.Truncate(52 / val),
                            CurrentType = DateType.Years
                        };
                    default:
                        break;
                }
            }

            // Shouldn't occur, though return data initially passed in.
            return new DateResult
            {
                Value = val,
                CurrentType = valType
            };
        }

    }
}
