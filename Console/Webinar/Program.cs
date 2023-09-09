using System;

namespace Webinar
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal myAnimal = new Animal("Kucing");
            Animal animal2 = new Animal(null);
            Dog myDog = new Dog("Dino");

            Console.WriteLine(myAnimal.Name);
            Console.WriteLine(animal2.Name);

            Console.WriteLine();

            myAnimal.MakeSound();            // Output: Kucing mengeluarkan suara.
            myAnimal.MakeSound("Meow");      // Output: Kucing mengeluarkan suara: Meow

            Console.WriteLine();

            myDog.MakeSound();               // Output: Anjing menggonggong: Woof! Woof!
            myDog.MakeSound(3);              // Output: Anjing menggonggong: Woof! Woof! Woof!

            ServiceResult result = new ServiceResult(ServiceResultCode.Ok, "respon berhasil");
            result.Obj = myDog.Name;


            Console.ReadLine();
        }
    }
}
