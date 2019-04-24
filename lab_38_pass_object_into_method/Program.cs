using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_38_pass_object_into_method
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Animal("Cat", 3, 2800);
            var b = new Animal("Tiger", 13, 300);
            ProcessAnimal(a);
            ProcessAnimal(a);
            Console.WriteLine($"after processing animal has age {a.Age} and weight {a.Weight}");
        }

        // Process animals
        static void ProcessAnimal(Animal animal)
        {
            animal.Age++;
            animal.Weight += 20;
        }
    }

    class Animal
    {
        public string Type { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        // Constructor
        public Animal(string type, int age, double weight)
        {
            Type = type;
            Age = age;
            Weight = weight;
        }
    }
}
