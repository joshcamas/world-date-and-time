using System;

namespace Ardenfall
{
    public class WorldTime
    {
        private static readonly int secondsInMinute = 60;
        private static readonly int minutesInHour = 60;
        private static readonly int hoursInDay = 24;

        public int hours;
        public int minutes;
        public int seconds;

        public WorldTime()
        {
            this.hours = 0;
            this.minutes = 0;
            this.seconds = 0;
        }

        public WorldTime(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        //Convert to float, where 1 is a single day
        public static explicit operator float(WorldTime time)
        {
            float h = (float)time.hours / hoursInDay;
            float m = (float)time.minutes / (minutesInHour * hoursInDay);
            float s = (float)time.seconds / (minutesInHour * hoursInDay * secondsInMinute);

            return h + m + s;
        }

        //Cast float to Time
        public static explicit operator WorldTime(float a)
        {
            int totalSeconds = Mathf.FloorToInt(hoursInDay * minutesInHour * secondsInMinute * a);
            int hours = totalSeconds / (minutesInHour * secondsInMinute);
            int minutes = (totalSeconds % (minutesInHour * secondsInMinute)) / minutesInHour;
            int seconds = totalSeconds - (hours * minutesInHour * secondsInMinute + minutes * secondsInMinute);

            return new WorldTime(hours, minutes, seconds);
        }

        //Convert to double, where 1 is a single day
        public static explicit operator double(WorldTime time)
        {
            double h = (double)time.hours / hoursInDay;
            double m = (double)time.minutes / (minutesInHour * hoursInDay);
            double s = (double)time.seconds / (minutesInHour * hoursInDay * secondsInMinute);

            return h + m + s;
        }

        //Cast double to Time
        public static explicit operator WorldTime(double a)
        {
            int totalSeconds = (int)Math.Floor(hoursInDay * minutesInHour * secondsInMinute * a);
            int hours = totalSeconds / (minutesInHour * secondsInMinute);
            int minutes = (totalSeconds % (minutesInHour * secondsInMinute)) / minutesInHour;
            int seconds = totalSeconds - (hours * minutesInHour * secondsInMinute + minutes * secondsInMinute);

            return new WorldTime(hours, minutes, seconds);
        }

    }


}
