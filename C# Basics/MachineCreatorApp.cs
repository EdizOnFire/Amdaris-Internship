using C_Sharp_Basics.Models;

public static class MachineCreatorApp
{
    public static string AnswerFromConsole(string request)
    {
        Console.Write(request);
        return Console.ReadLine();
    }

    public static void CreateComputer(ComputerModel computer)
    {
        computer.MachineId = AnswerFromConsole("Please enter the ID of the computer: ");
        computer.Processor = AnswerFromConsole("Please enter the name of the Processor of the computer: ");
        computer.AmountOfRam = int.Parse(AnswerFromConsole("Please enter the amount of RAM of the computer in GB: "));
    }

    public static void GetComputerInfo(ComputerModel computer)
    {
        Console.WriteLine("Information about the created computer.");
        Console.WriteLine($"ID: {computer.MachineId}.");
        Console.WriteLine($"Processor: {computer.Processor}.");
        Console.WriteLine($"Amount of RAM: {computer.AmountOfRam} GB.");
    }

    public static void TurnOnOrOff(ComputerModel computer)
    {
        string answer = AnswerFromConsole("Do you want to turn the computer on? 'y' or 'n'. ");
        if (answer == "y")
        {
            computer.TurnOn();
        }
        else if (answer == "n")
        {
            computer.TurnOff();
        }
    }
}