using static System.Console;

namespace Factory
{

    class Program
    {
        static void Main()
        {
            Builder[] builders = new Builder[2];
            builders[0] = new MachineBuilder();
            builders[1] = new HouseBuilder();

            foreach (Builder builder in builders)
            {
                Product product = builder.FactoryMethod();
                WriteLine("Built {0}",
                  product.GetType().Name);
            }

            ReadKey();
        }
    }

    abstract class Product
    {
    }

    class Machine : Product
    {
    }

    class House : Product
    {
    }

    abstract class Builder
    {
        public abstract Product FactoryMethod();
    }

    class MachineBuilder : Builder
    {
        public override Product FactoryMethod()
        {
            return new Machine();
        }
    }

    class HouseBuilder : Builder
    {
        public override Product FactoryMethod()
        {
            return new House();
        }
    }
}