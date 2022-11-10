using Arrays_Collections_Generics;

string[] strings = { "one", "two", "three", "four", "five" };
int[] ints = { 1, 2, 3, 4, 5 };

Console.WriteLine($"Initial arrays:");
foreach (var thing in strings)
{
    Console.Write(thing + " ");
}

Console.WriteLine();
foreach (var thing in ints)
{
    Console.Write(thing + " ");
}

Console.WriteLine();

var answer = Collection.AnswerFromConsole("Do you want to work with an array of string or integers? 's' or 'i'.");
if (answer == "s")
{
    Collection.GetItem(strings);
    answer = Collection.AnswerFromConsole("Enter a string you wish to set: ");
    Collection.SetItem(strings, answer);
    Collection.SwapItems(strings);
}
else if (answer == "i")
{
    Collection.GetItem(ints);
    answer = Collection.AnswerFromConsole("Enter an integer you wish to set: ");
    Collection.SetItem(ints, int.Parse(answer));
    Collection.SwapItems(ints);
}

Console.ReadLine();