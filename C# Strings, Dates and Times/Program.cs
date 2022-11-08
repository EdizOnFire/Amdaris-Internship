using System.Globalization;

string sentence = "This is a sentence which will be split, reversed, and joined.";
Console.WriteLine(sentence);
string[] array = sentence.Split();
Array.Reverse(array);
string s1 = string.Join(" ", array);
Console.WriteLine(s1);

Console.WriteLine("Difference between dates using TimeSpan:");
DateTime date1 = new DateTime(2022, 4, 23, 13, 30, 30);
DateTime date2 = new DateTime(2022, 3, 23, 12, 31, 31);
TimeSpan interval = date1 - date2;
Console.WriteLine("{0} - {1} = {2}", date1, date2, interval.ToString());

Console.WriteLine("Current date and time using DateTime:");
Console.WriteLine(DateTime.Now);

Console.WriteLine("Difference between dates using DateTimeOffset:");
var dateOffset1 = DateTimeOffset.Now;
var dateOffset2 = DateTimeOffset.UtcNow;
var difference = dateOffset1 - dateOffset2;
Console.WriteLine("{0} - {1} = {2}", dateOffset1, dateOffset2, difference);

Console.WriteLine("Current timezone using TimeZoneInfo:");
TimeZoneInfo localZone = TimeZoneInfo.Local;
Console.WriteLine(localZone);

Console.WriteLine("Showing culture using CultureInfo:");
CultureInfo myCIintl = new CultureInfo(("bg-BG"), false);
Console.WriteLine($"Culture: {myCIintl.DisplayName}");