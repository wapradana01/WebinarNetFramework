using System;

namespace Webinar
{
    public class Dog : Animal
    {
        public Dog() { }
        public Dog(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} menggonggong sebanyak 1 kali");
            Console.WriteLine($"{Name} menggonggong: Woof! Woof!\n");
        }

        public void MakeSound(int count)
        {
            Console.WriteLine($"{Name} menggonggong sebanyak {count} kali");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{Name} menggonggong: Woof! Woof!");
            }
        }
    }
}
