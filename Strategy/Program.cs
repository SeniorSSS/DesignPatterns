using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class Program
    {
        public abstract class Duck
        {
            private readonly IFlyBehaviour _flyBehaviour;
            private readonly IQuackBehaviour _quackBehaviour;
            protected Duck(IFlyBehaviour flyBehaviour, IQuackBehaviour quackBehaviour)
            {
                _flyBehaviour = flyBehaviour;
                _quackBehaviour = quackBehaviour;
            }
            public void PerformFly()
            {
                _flyBehaviour.Fly();
            }

            public void PerformQuack()
            {
                _quackBehaviour.Quack();
            }
            public abstract void Display();
        }

        public interface IFlyBehaviour
        {
            void Fly();
        }
        public class FlyWithWings : IFlyBehaviour
        {
            public void Fly()
            {
                Console.WriteLine("I'm flying!");
            }
        }
        public class FlyWithNoWings : IFlyBehaviour
        {
            public void Fly()
            {
                Console.WriteLine("I can't fly!");
            }
        }
        public class FlyWithAirplane : IFlyBehaviour
        {
            public void Fly()
            {
                Console.WriteLine("I fly only on airplane!");
            }
        }

        public interface IQuackBehaviour
        {
            void Quack();
        }

        public class Quacky : IQuackBehaviour
        {
            public void Quack()
            {
                Console.WriteLine("Quack");
            }
        }

        public class MuteQuack : IQuackBehaviour
        {
            public void Quack()
            {
                Console.WriteLine("Enjoy the silence");
            }
        }

        public class Speak : IQuackBehaviour
        {
            public void Quack()
            {
                Console.WriteLine("I speak");
            }
        }

        public class MallardDuck : Duck
        {
            public MallardDuck() : base(new FlyWithWings(), new Quacky()) { }

            public override void Display()
            {
                Console.WriteLine("I'm Mallard Duck");
            }
        }

        public class RubberDuck : Duck
        {
            public RubberDuck() : base(new FlyWithNoWings(), new MuteQuack()) { }

            public override void Display()
            {
                Console.WriteLine("Take me to bath because i'm rubber Duck");
            }
        }

        public class DonaldDuck : Duck
        {
            public DonaldDuck() : base(new FlyWithAirplane(), new Speak()) { }
            public override void Display()
            {
                Console.WriteLine("My name is Donald Duck");
            }
        }
        static void Main(string[] args)
        {
            var ducks = new List<Duck>();
            ducks.Add(new MallardDuck());
            ducks.Add(new RubberDuck());
            ducks.Add(new DonaldDuck());

            foreach (var duck in ducks)
            {
                duck.Display();
                duck.PerformQuack();
                duck.PerformFly();
                Console.WriteLine("----------------------");
            }
                      
            Console.ReadKey();
        }
    }
}
