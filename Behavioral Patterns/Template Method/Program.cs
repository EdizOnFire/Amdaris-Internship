using static System.Console;

namespace TemplateMethod
{
    class Program
    {
        public static void Main()
        {
            WriteLine("Original variant:");
            new AttackWithThree().Attack();
            WriteLine("First variation:");
            new Variation1().Attack();
            WriteLine("Second variation:");
            new Variation2().Attack();
        }

        public class AttackWithThree
        {
            public virtual void Attack()
            {
                new FireSword().Attack();
                new FrostSword().Attack();
                new ThunderSword().Attack();
            }
        }
        public class Variation1 : AttackWithThree
        {
            public override void Attack()
            {
                new FireSword().Attack();
                new FrostSword().Attack();
            }
        }

        public class Variation2 : AttackWithThree
        {
            public override void Attack()
            {
                new FireSword().Attack();
                new ThunderSword().Attack();
            }
        }
    }
}