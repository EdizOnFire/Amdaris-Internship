using C_Sharp_Basics.Models;

Console.WriteLine("You will have to register in order to use the app.");
RegisteredUser user = new RegisteredUser();

AudioEditorApp.Register(user);
Console.Clear();
user.Welcome();
AudioEditorApp.UploadFileQuestion();
Console.ReadLine();