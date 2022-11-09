using C_Sharp_Basics.Models;

Console.WriteLine("You will have to register in order to use the app.");
UserModel user = new UserModel();

AudioEditorApp.Register(user);
Console.Clear();
AudioEditorApp.GetUserInfo(user);
AudioEditorApp.UploadFileQuestion();
Console.ReadLine();