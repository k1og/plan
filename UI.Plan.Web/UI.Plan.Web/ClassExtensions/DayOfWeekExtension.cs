using System;

namespace UI.Plan.Web.ClassExtensions
{
    public static class DayOfWeekExtension
    {
        /// <summary>
        /// Возвращает числовой код дня от 1 до 7
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static int ToRusInt(this DayOfWeek dayOfWeek)
        {
            return (int)dayOfWeek == 0 ? 7 : (int)dayOfWeek;
        }
    }
}