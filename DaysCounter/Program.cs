using System;

namespace DaysCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            calculatePassedDays();
            calculateBornDate();
           /* DateTime firstDate = new DateTime();
            DateTime secondDate = new DateTime();
            try
            {
                Console.WriteLine("Enter the first date: ");        
                firstDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Correct first date!");

                Console.WriteLine("Enter the second date: ");
                secondDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Correct second date!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong date and time format!");
                return;
            }

            Console.WriteLine("-----Result before timezones-----");
            TimeSpan difference = secondDate - firstDate;

            Console.WriteLine("Difference in days: " + Math.Abs(difference.Days));
            Console.WriteLine("Day for the given date " + secondDate + " is: " + secondDate.DayOfWeek);

            Console.WriteLine("-----Result after timezones-----");
            calculateTimeZone(firstDate, secondDate);*/
        }
        
        public static void calculateTimeZone(DateTime firstDate, DateTime secondDate)
        {
            string firstTimeZone, secondTimeZone;

            TimeZoneInfo tzi1, tzi2;

            TimeSpan dateDifference;
            try
            {
                Console.WriteLine("Enter the first timezone for the first date: ");
                firstTimeZone = Console.ReadLine();

                tzi1 = TimeZoneInfo.FindSystemTimeZoneById(firstTimeZone);
                DateTime firstDateTimeZoneConversion = TimeZoneInfo.ConvertTime(firstDate, tzi1);
                Console.WriteLine("Correct first timezone!");

                Console.WriteLine("Enter the second timezone for the second date: ");
                secondTimeZone = Console.ReadLine();

                tzi2 = TimeZoneInfo.FindSystemTimeZoneById(secondTimeZone);
                DateTime secondDateTimeZoneConversion = TimeZoneInfo.ConvertTime(secondDate, tzi2);
                Console.WriteLine("Correct second timezone!");

                dateDifference = secondDateTimeZoneConversion - firstDateTimeZoneConversion;
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured. Exiting...");
                return;
            }

            Console.WriteLine("Difference in days is: " + dateDifference.Days);
            Console.WriteLine("Difference in time is: " + dateDifference.Hours + ":" + dateDifference.Minutes + ":" + dateDifference.Seconds);
        }

        public static DateTime fillDate()
        {
            int minMonth = 1, maxMonth = 12, minDay = 1, maxDay = 31, minYear = 1, maxYear = 2022;
            bool leapYear = false;
          
            Console.WriteLine("Enter year:");
            int year = Int32.Parse(Console.ReadLine());

            if (year < minYear || year > maxYear)
            {
                Console.WriteLine("Invalid year. Years are in range 1-2022");
                System.Environment.Exit(1);
            }
                

            if ((year % 400) == 0 || (year % 100) != 0 || ((year % 4) == 0))
                leapYear = true;

            Console.WriteLine("Enter month:");
            int month = Int32.Parse(Console.ReadLine());

            if (month < minMonth || month > maxMonth)
            {
                Console.WriteLine("Invalid month. Months are in range 1-12");
                Console.WriteLine("Enter month again: ");
                month = Int32.Parse(Console.ReadLine());
            }
                

            Console.WriteLine("Enter day:");
            int day = Int32.Parse(Console.ReadLine());

            if (month == 4 || month == 6 || month == 9 || month == 11)
                maxDay = 30;

            if (month == 2)
                maxDay = 28;

            if (month == 2 && leapYear)          
                    maxDay = 29;               

            if (day < minDay || day > maxDay)
            {
                Console.WriteLine("Invalid day. Days are in range " + minDay + "-" + maxDay + " range.");
                Console.WriteLine("Enter day again: ");
                day = Int32.Parse(Console.ReadLine());
            }
                
            return new DateTime(year, month, day);
        }

        public static void calculatePassedDays()
        {
            DateTime currentDate = DateTime.Now;
            Console.WriteLine("Today's date is: " + currentDate.ToString("dd.MM.yyyy"));

            Console.WriteLine("Enter date from the past.");
            DateTime pastDate = fillDate();

            Console.WriteLine("Past date is: " + pastDate.ToString("dd.MM.yyyy"));

            Console.WriteLine("Total days are: " + (currentDate - pastDate).Days);
        }

        public static void calculateBornDate()
        {
            int years, months, days;
            Console.WriteLine("Enter the years you are old: ");
            years = Int32.Parse(Console.ReadLine());

            if(years < 0 || years > 120)
            {
                Console.WriteLine("Invalid years. Years are in range 0-120.");
                System.Environment.Exit(1);
            }

            Console.WriteLine("Enter the months you are old: ");
            months = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the days you are old: ");
            days = Int32.Parse(Console.ReadLine());

            DateTime expectedBirthDate = DateTime.Now.AddYears(-years).AddMonths(-months).AddDays(-days);

            Console.WriteLine("Your birthday is: " + expectedBirthDate.ToString("dd.MM.yyyy"));

            Console.WriteLine("Your day of birth is: " + expectedBirthDate.DayOfWeek);
        }
    }
}