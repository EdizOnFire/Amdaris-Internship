using C_Sharp_Basics.Models;

ComputerModel computer = new ComputerModel();

MachineCreatorApp.CreateComputer(computer);
Console.Clear();

MachineCreatorApp.GetComputerInfo(computer);
MachineCreatorApp.TurnOnOrOff(computer);