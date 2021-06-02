using System;

namespace DateModifier
{
    public class DateModifier
    {
        private DateTime firstDate;
        private DateTime secondDate;

        public DateModifier(DateTime firstDate, DateTime secondDate)
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
        }
        public DateTime FirstDate
        {
            get { return this.firstDate; }
            set { this.firstDate = value; }
        }
        public DateTime SecondDate
        {
            get { return this.secondDate; }
            set { this.secondDate = value; }
        }

        public int GetDayDifference(DateTime start, DateTime end)
        {
            var result = (end.Date - start.Date).Days;
            return Math.Abs(result);
        }
    }
}