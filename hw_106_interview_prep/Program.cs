using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_106_interview_prep
{
    class Program
    {
        static void Main(string[] args)
        {
            var woofy = new Dog();

            woofy.Breathe();
            woofy.Pet();
            woofy.IncreaseAge(5);
            woofy.IncreaseAge(4.5);
            woofy.MakeSound();
            string happinessState = woofy.Happines > 0 ? "happy" : "depressed";
            Console.WriteLine($"Woofy is a dog that is {woofy.Age} days old and is a {happinessState} dog");

            try
            {
                Console.WriteLine($"Woofies overall change of happiness has been {woofy.Happines / woofy.Age}");
            }
            catch (System.Exception)
            {
                Console.WriteLine("Woofie was just born today");
            }
            finally
            {
                Console.WriteLine("That's all there is to it");
            }

        }
    }

    abstract class Animal
    {
        public abstract void Breathe();
    }

    interface IMakeSound
    {
        void MakeSound();
    }

    sealed class Dog : Animal, IMakeSound
    {
        // Age in days
        private int _age;

        // The happiness level of the dog
        public int Happines { get; private set; }

        public int Age
        {
            get
            {
                return _age;
            }
        }

        public Dog()
        {
            _age = 0;
            Happines = 0;
        }

        public void Pet()
        {
            ++Happines;
        }


        public override void Breathe()
        {
            Console.WriteLine("The dog is panting with its tongue out of its mouth.");
        }

        public void MakeSound()
        {
            Console.WriteLine("The dog barks happily when he sees his owner.");
        }

        public void IncreaseAge(int days)
        {
            _age += days;
        }

        public void IncreaseAge(double weeks)
        {
            _age += (int)(weeks * 7);
        }
    }

    public static class ASCIINonsense
    {
        public static int ASCIIFromStringIndex(string s, int i)
        {
            if (i >= s.Length) return -1;

            return (int)(s[i]);
        }
    }

}
