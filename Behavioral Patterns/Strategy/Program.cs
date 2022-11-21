using static System.Console;

namespace Strategy
{
    class Program
    {
        public static void Main()
        {
            new FireSword().Attack();
            new FrostSword().Attack();
            new ThunderSword().Attack();
        }

        public interface IDoDamage
        {
            void DoDamage();
        }

        public class Weapon
        {
            public IDoDamage damageType;
            public void Attack()
            {
                damageType?.DoDamage();
            }
        }

        public class FireDamage : IDoDamage
        {
            public void DoDamage()
            {
                WriteLine($"You've inflicted fire damage.");
            }
        }

        public class FireSword : Weapon
        {
            public FireSword()
            {
                damageType = new FireDamage();
            }
        }

        public class FrostDamage : IDoDamage
        {
            public void DoDamage()
            {
                WriteLine($"You've inflicted frost damage.");
            }
        }

        public class FrostSword : Weapon
        {
            public FrostSword()
            {
                damageType = new FrostDamage();
            }
        }

        public class ThunderDamage : IDoDamage
        {
            public void DoDamage()
            {
                WriteLine($"You've inflicted thunder damage.");
            }
        }

        public class ThunderSword : Weapon
        {
            public ThunderSword()
            {
                damageType = new ThunderDamage();
            }
        }
    }
}