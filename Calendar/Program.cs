using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class Program
    {

         public static void Main()
        {
             DateTime start = new DateTime(2022, 01, 01);
            DateTime end = new DateTime(2022, 01, 31);

            TimeSpan difference = end - start;

            Console.WriteLine("Difference between: " + difference.Days);

            Console.WriteLine("Enter a date: ");
            DateTime userDateTime;

            if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
            {
                Console.WriteLine("The day of the week is: " + userDateTime.DayOfWeek);

            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }
            Console.ReadLine();


            DateTime thisTime = DateTime.Now;
            Console.WriteLine("Time in {0} zone: {1}", TimeZoneInfo.Local.IsDaylightSavingTime(thisTime) ?
                              TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName, thisTime);
            Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(thisTime, TimeZoneInfo.Local));
            // Get Tokyo Standard Time zone
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);
            Console.WriteLine("Time in {0} zone: {1}", tst.IsDaylightSavingTime(tstTime) ?
                              tst.DaylightName : tst.StandardName, tstTime);
            Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(tstTime, tst));
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

            if (years < 0 || years > 120)
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
