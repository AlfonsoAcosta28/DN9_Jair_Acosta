using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioManager;

namespace OOP.ConsoleExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Helle World!");

            Animal animal = new Animal();
            animal.animalSound();

            Console.ReadKey();
        }
    }
}
