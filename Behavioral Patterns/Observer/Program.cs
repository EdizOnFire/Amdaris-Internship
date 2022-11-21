using static System.Console;

class Program
{
    public static void Main()
    {
        var notifier = new Notifier();
        notifier.AddNotifier(new Phone());
        notifier.AddNotifier(new Email());
        notifier.AddNotifier(new Fax());
        notifier.Notify();
        notifier.Notify();
    }

    public class Notifier
    {
        List<INotifier<Notifier>> notifiers = new();

        public void AddNotifier(INotifier<Notifier> notifier)
        {
            notifiers.Add(notifier);
        }

        public void Notify()
        {
            foreach (var n in notifiers)
            {
                n.Alert();
            }
        }
    }

    public interface INotifier<T>
    {
        public void Alert();
    }

    public class Phone : INotifier<Notifier>
    {
        public void Alert()
        {
            WriteLine("Phone notification sent.");
        }
    }

    public class Email : INotifier<Notifier>
    {
        public void Alert()
        {
            WriteLine("Email notification sent.");
        }
    }

    public class Fax : INotifier<Notifier>
    {
        public void Alert()
        {
            WriteLine("Fax notification sent.");
        }
    }
}