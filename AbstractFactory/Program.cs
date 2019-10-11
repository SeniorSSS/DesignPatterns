using System;

namespace AbstractFactory
{
    class Program
    {
        abstract class Weapon
        {
            public abstract void Hit();
        }

        abstract class Movement
        {
            public abstract void Move();
        }

        class Bow : Weapon
        {
            public override void Hit()
            {
                Console.WriteLine("Shoot with a bow");
            }
        }

        class Sword : Weapon
        {
            public override void Hit()
            {
                Console.WriteLine("Hit with a sowrd");
            }
        }

        class FlyMovement : Movement
        {
            public override void Move()
            {
                Console.WriteLine("Flying");
            }
        }

        class RunMovement : Movement
        {
            public override void Move()
            {
                Console.WriteLine("Running");
            }
        }

        abstract class HeroFactory
        {
            public abstract Movement CreateMovement();
            public abstract Weapon CreateWeapon();
        }

        class ElfFactory : HeroFactory
        {
            public override Movement CreateMovement()
            {
                return new FlyMovement();
            }

            public override Weapon CreateWeapon()
            {
                return new Bow();
            }
        }

        class VoinFactory : HeroFactory
        {
            public override Movement CreateMovement()
            {
                return new RunMovement();
            }

            public override Weapon CreateWeapon()
            {
                return new Sword();
            }
        }

        class Hero
        {
            private Weapon _weapon;
            private Movement _movement;
            public Hero(HeroFactory factory)
            {
                _weapon = factory.CreateWeapon();
                _movement = factory.CreateMovement();
            }
            public void Run()
            {
                _movement.Move();
            }
            public void Hit()
            {
                _weapon.Hit();
            }
        }
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            Hero hero = new Hero(new VoinFactory());

            elf.Hit();
            elf.Run();
            Console.WriteLine("------------------");
            hero.Hit();
            hero.Run();

            Console.ReadKey();
        }
    }
}
