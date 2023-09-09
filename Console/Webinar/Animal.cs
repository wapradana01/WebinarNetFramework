using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webinar
{
    public class Animal
    {
        public int kaki { get; set; }
        public string Name { get; set; }

        public Animal()
        {
            Name = "Jerapah";
        }

        public Animal(string name)
        {
            Name = name;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} mengeluarkan suara.");
        }

        public void MakeSound(string sound)
        {
            Console.WriteLine($"{Name} mengeluarkan suara: {sound}");
        }
    }
}
