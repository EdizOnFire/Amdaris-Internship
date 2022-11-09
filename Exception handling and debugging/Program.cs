using Exception_handling_and_debugging.Models;

Console.WriteLine("You will have to register in order to use the app.");
RegisteredUser user = new RegisteredUser();

AudioEditorApp.Register(user);
Console.Clear();
user.Welcome();
AudioEditorApp.UploadFileQuestion();
Console.ReadLine();