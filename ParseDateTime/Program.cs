using System;
using System.Globalization;

namespace ParseDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateString;  
            DateTimeOffset result;

            // Parse date and time and convert to UTC.
            dateString = "Fri, 15 Jun 2018 00:30:49 GMT"; 
           
            if (DateTimeOffset.TryParseExact(dateString, "r", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out result))
                Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
            else
                Console.WriteLine("'{0}' is not in the correct format.", dateString);

            // Get current date/time in RFC1123 format
            DateTime now = DateTime.Now;
            Console.WriteLine("Current datetime now: " +  now.ToString("R"));
            Console.WriteLine("Current datetime after 7 days: " + now.AddDays(7).ToString("R"));

           // Explore more: http://zetcode.com/articles/csharpdatetime/
        }
    }
}
