using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_01_Apr_23
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Parent> list01 = new List<Parent>();
            Queue<Parent> queue01 = new Queue<Parent>();
            Stack<Parent> stack01 = new Stack<Parent>();

            list01.Add(new Parent("John", 46));
            list01.Add(new Parent("Eve", 53, "Senior developer"));
            list01.Add(new Parent(age : 37, status : "Junior developer", name : "Tom"));
            list01.Add(new Parent(name: "Adam", age: 64));
            list01.Add(new Child(status: "Attending university", name : "George", age: 22, grades: "high"));
            list01.Add(new Child("Catherine", 16));
            list01.Add(new Child("Amy", 24, "Trainee at Sparta Global"));
            list01.Add(new GrandChild("Elize", 10, "In primary school", "doll"));
            list01.Add(new GrandChild("Billy", 3, favouriteToy: "car"));
            list01.Add(new GrandChild("Phil", 13, "In high school", "robot"));

            Console.WriteLine("List:");
            foreach(var item in list01)
            {
                item.Grow();
                Console.WriteLine(item.AsString());
                queue01.Enqueue(item);
            }

            Console.WriteLine("\n------------------\nQueue:");
            while(queue01.Count != 0)
            {
                var item = queue01.Dequeue();
                item.Grow();
                Console.WriteLine(item.AsString());
                stack01.Push(item);
            }

            Console.WriteLine("\n------------------\nStack:");
            while(stack01.Count != 0)
            {
                var item = stack01.Pop();
                item.Grow();
                Console.WriteLine(item.AsString());
            }

        }
    }

    class Parent
    {
        protected Random _random = new Random();

        public string Name { get; set; }
        public int Age { get; set; }

        protected string _status;

        public Parent() { }

        public Parent(string name, int age, string status = "Senior developer")
        {
            if (age < 18)
            {
                throw new System.Exception("Parent cannot be younger than 16");
            }
            Name = name;
            Age = age;
            _status = status;
        }
        public virtual void Grow()
        {
            ++Age;
            if(Age == 65)
            {
                _status = "Retired";
            }
            else if(_status == "Junior developer")
            {
                // Throw a dice
                if(_random.Next(1, 6) == 6)
                {
                    _status = "Senior developer";
                }
            }
        }
        public virtual string AsString() => Name + " is " + Age + " years old " + (_status == "Retired" ? "and is retired." : "works as a " + _status) + ".";
    }

    class Child : Parent
    {
        protected string _grades;

        public Child() { }

        public Child(string name, int age, string status = "In high school", string grades = "average") {
            Name = name;
            Age = age;
            _status = status;
            _grades = grades;
        }

        public override void Grow()
        {
            ++Age;
            if(Age == 12)
            {
                _status = "In high school";
            }
            else if(Age == 18)
            {
                _status = "Attending university";
            }
            else if(Age == 24)
            {
                _status = "Trainee at Sparta Global";
            }
            else if(Age == 26)
            {
                _status = "Junior developer";
            }
            else if(_status == "Junior developer")
            {
                // Throw a dice
                if (_random.Next(1, 6) == 6)
                {
                    _status = "Senior developer";
                }
            }
        }

        public override string AsString() => Name + " is " + Age + " years old and is currently " + (Age < 26 ? _status : (" a " + _status)) + ".";
    }

    class GrandChild : Child
    {
        public string _favouriteToy;

        public GrandChild(string name, int age, string status = "In kindergarten", string favouriteToy = "bear") : base(name, age, status)
        {
            _favouriteToy = favouriteToy;
        }

        public override void Grow()
        {
            ++Age;
            if (Age == 12)
            {
                _status = "In primary school";
            }
            if (Age == 12)
            {
                _status = "In high school";
            }
            else if (Age == 18)
            {
                _status = "Attending university";
            }
            else if (Age == 24)
            {
                _status = "Trainee at Sparta Global";
            }
            else if (Age == 26)
            {
                _status = "Junior developer";
            }
            else if (_status == "Junior developer")
            {
                // Throw a dice
                if (_random.Next(1, 6) == 6)
                {
                    _status = "Senior developer";
                }
            }
        }
        public override string AsString() => Name + " is " + Age + " and his/her favourite toy is a " + _favouriteToy + ". He/she is currently " + (Age < 26 ? _status : (" a " + _status)) + ".";
    }

  
}
