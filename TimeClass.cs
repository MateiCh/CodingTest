using System;

namespace TimeClass
{
    class Program
    {
        static void Main()
        {
            Time t = new Time(1, 30, 20);
            Console.WriteLine(t.TimeString() == "01:30:20");
            t.Scale(400);
            Console.WriteLine(t.TimeString() == "01:37:00");

            Time t2 = new Time(1, 100, 0);
            Console.WriteLine(t2.TimeString() == "02:40:00");

            Console.WriteLine("To show the validity of the other methods");
            Console.WriteLine($"TimeString - {t.TimeString()}");
            Console.WriteLine($"TimeStringWithFormatting - {t.TimeStringWithFormatting()}");
            Console.WriteLine($"TimeStringWithConditionalOperator - {t.TimeStringWithConditionalOperator()}");

            //extras
            Console.WriteLine();
            Console.WriteLine();
            var tx = new Time(13, 13, 14);
            Console.WriteLine(tx.TimeStringWithFormatting());
            tx.Scale(60);
            Console.WriteLine(tx.TimeStringWithFormatting());
            tx.Scale(-60);
            Console.WriteLine(tx.TimeStringWithFormatting());
            tx.Scale(1320);
            Console.WriteLine(tx.TimeStringWithFormatting());
            tx.Scale(-3735);
            Console.WriteLine(tx.TimeStringWithFormatting());
        }
    }

    class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public Time(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            NormalizeTime();
        }
        private void NormalizeTime()
        {
            if (hours < 0) hours = 0;
            if (minutes < 0) minutes = 0;
            if (seconds < 0) seconds = 0;

            if (seconds > 59)
            {
                minutes += seconds / 60;
                seconds %= 60;
            }
            if (minutes > 59)
            {
                hours += minutes / 60;
                minutes %= 60;
            }
            if (hours > 23)
                hours %= 24;
        }
        public void Scale(int secondsAdded)
        {
            if (secondsAdded > 0)
                seconds += secondsAdded;
            else
            {
                seconds += secondsAdded % 60;
                if (seconds < 0)
                {
                    minutes += -1 + secondsAdded / 60;
                    seconds += 60;
                }
                if (minutes < 0)
                {
                    hours += -1 + minutes / 60;
                    minutes += 60;
                }
            }
            NormalizeTime();
        }
        public string TimeStringWithFormatting()
        {
            return $"{hours:00}:{minutes:00}:{seconds:00}";
        }
        public string TimeStringWithConditionalOperator()
        {
            string timeString = string.Empty;
            string hourString = hours < 10 ? $"0{hours}" : $"{hours}";
            string minutesString = minutes < 10 ? $"0{minutes}" : $"{minutes}";
            string secondsString = seconds < 10 ? $"0{seconds}" : $"{seconds}";
            timeString = $"{hourString}:{minutesString}:{secondsString}";
            return timeString;
        }
        public string TimeString()
        {
            string timeString = string.Empty;
            if (hours < 10)
                timeString += $"0{hours}:";
            else
                timeString += $"{hours}:";
            if (minutes < 10)
                timeString += $"0{minutes}:";
            else
                timeString += $"{minutes}:";
            if (seconds < 10)
                timeString += $"0{seconds}";
            else
                timeString += $"{seconds}";
            return timeString;
        }
    }
}
