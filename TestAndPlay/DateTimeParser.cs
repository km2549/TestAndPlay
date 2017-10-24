using System;
using System.Text.RegularExpressions;

namespace TestAndPlay
{
    class DateTimeParser
    {
        public void parse()
        {
            Regex regex = new Regex(@"\d{2}:\d{2}:\d{2}");
            string text = "05:59:50";

            TimeSpan parsedTime = TimeSpan.Parse(text);

            Match match = regex.Match(text);
            if (match.Success)
            {
                string[] values = text.Split(':');
                TimeSpan t = new TimeSpan(Int16.Parse(values[0]), Int16.Parse(values[1]), Int16.Parse(values[2]));
                Console.WriteLine(t.Hours);
                Console.WriteLine(t.Minutes);
                Console.WriteLine(t.Seconds);
            }
        }
    }
}
