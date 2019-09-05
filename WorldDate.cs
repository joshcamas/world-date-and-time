using System;

namespace Ardenfall
{
    public class WorldDate
    {
        private static readonly int daysInMonth = 30;
        private static readonly int monthsInYear = 12;

        public int day;
        public int month;
        public int year;
        public WorldTime time;

        public WorldDate(int day, int month, int year, WorldTime time)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            this.time = time;
        }

        public WorldDate(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            this.time = new WorldTime();
        }

        //Cast float to Date
        public static explicit operator WorldDate(float a)
        {
            int ia = Mathf.FloorToInt(a);

            int year = Mathf.FloorToInt((float)ia / (float)monthsInYear / (float)daysInMonth);
            int month = Mathf.FloorToInt((float)ia / (float)daysInMonth - year * (float)monthsInYear);
            int day = ia - (year * monthsInYear * daysInMonth + daysInMonth * month);

            WorldTime time = (WorldTime)(a % 1);

            return new WorldDate(day, month, year, time);
        }

        //Cast double to Date
        public static explicit operator WorldDate(double a)
        {
            int ia = (int)Math.Floor(a);

            int year = (int)Math.Floor((double)ia / (double)monthsInYear / (double)daysInMonth);
            int month = (int)Math.Floor((double)ia / (double)daysInMonth - year * (double)monthsInYear);
            int day = ia - (year * monthsInYear * daysInMonth + daysInMonth * month);

            WorldTime time = (WorldTime)(a % 1);

            return new WorldDate(day, month, year, time);
        }

        //Cast Date to float
        public static explicit operator float(WorldDate date)
        {
            if (date == null)
                return 0;

            float d = (float)date.year * monthsInYear * daysInMonth + daysInMonth * date.month + date.day + (float)date.time;

            return d;
        }

        //Cast Date to double
        public static explicit operator double(WorldDate date)
        {
            double d = (double)date.year * monthsInYear * daysInMonth + daysInMonth * date.month + date.day + (double)date.time;

            return d;
        }

        public static bool operator <(WorldDate date1, WorldDate date2)
        {
            return (double)date1 < (double)date2;
        }

        public static bool operator >(WorldDate date1, WorldDate date2)
        {
            return (double)date1 > (double)date2;
        }

        public static bool operator <=(WorldDate date1, WorldDate date2)
        {
            return (double)date1 <= (double)date2;
        }

        public static bool operator >=(WorldDate date1, WorldDate date2)
        {
            return (double)date1 >= (double)date2;
        }

        public static WorldDate operator +(WorldDate date1, WorldDate date2)
        {
            return (WorldDate)((double)date1 + (double)date2);
        }

        public static WorldDate operator -(WorldDate date1, WorldDate date2)
        {
            return (WorldDate)((double)date1 - (double)date2);
        }
    }

}
