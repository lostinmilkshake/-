using System;
using System.IO;
using System.Collections.Generic;
/*
Создать класс человек, имеющий имя(указатель на строку), возраст, вес.
Определить конструкторы, деструктор и запись в файл .
Создать public- производный класс - совершеннолетний, имеющий номер паспорта.
Определить конструкторы по умолчанию и конструкторы с разным числом параметров,
деструкторы, функцию вывода данных в файл.
Определить функции переназначения возраста и номера паспорта.
*/
namespace FirstTask
{
    public class Human
    {
        protected string name; //Name of the human
        protected int age; //Age of the human
        protected int weight; //Weight of the human
        //Constructor by default
        public Human() {
            name = "";
            age = 0;
            weight = 0;
        }
        //Constructor with all values
        public Human(string name="", int age=0, int weight=0)
        {
            this.name = name;
            this.age = age;
            this.weight = weight;
        }
        //TODO fix??? destructor
        ~Human()
        {
            name = null;
            age = 0;
            weight = 0;
        }
        //Method to get age
        public int getAge()
        {
            return age;
        }
        //Method to change age
        public void changeAge(int newAge)
        {
            this.age = newAge;
        }
        //Override output
        public override string ToString() 
        {
            return "Name: " + name + "\nAge: " +
                age + "\nWeight: " + weight;
        }
        //Output all data in txt file
        public void streamToFileHuman()
        {
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile =
                new StreamWriter(name + "Human.txt"))
            {
                outputFile.Write(ToString());
            }
        }
    }
    public class FullAge: Human
    {
        private string passportNumber; //Number of pasport
        //Constructor by default
        public FullAge()
        {
            passportNumber = "0000000000";
        }
        //Constructor with all values
        public FullAge(string name="", int age=0, int weight=0,
            string passportNumber= "0000000000")
            : base(name, age, weight)
        {
            this.passportNumber = passportNumber;
        }
        //TODO fix??? destructor
        ~FullAge()
        {
            passportNumber = null;
        }
        //Method to get passport number
        public string getPassportNumber()
        {
            return passportNumber;
        }
        //Override output
        public override string ToString() 
        {
            return base.ToString() + "\nPassport Number: " + passportNumber;
        }
        //Output all data in txt file
        public void streamToFileFullAge()
        {
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile =
                new StreamWriter(name + "FullAge.txt"))
            {
                outputFile.Write(ToString());
            }
        }
        //Method to change passport number
        public void changePassport(string newPassport)
        {
            this.passportNumber = newPassport;
        }
    }
    class Program
    {
        static bool checkPassport(string passportNumber)
        {
            try
            {
                int.Parse(passportNumber);
            }
            catch (Exception)
            {
                return false;
            }
            return (passportNumber.Length == 10);
        }
        static bool checkAge(string age)
        {
            try
            {
                int.Parse(age);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static bool checkWeight(string weight)
        {
            try
            {
                int.Parse(weight);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static FullAge addFullAge()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            string stringAge;
            int age;
            do
            {
                Console.WriteLine("Enter age:");
                stringAge = Console.ReadLine();
            } while (!checkAge(stringAge) || int.Parse(stringAge) < 14);
            age = int.Parse(stringAge);  
            string stringWeight;
            int weight;
            do
            {
                Console.WriteLine("Enter weight:");
                stringWeight = Console.ReadLine();
            } while (!checkWeight(stringWeight));
            weight = int.Parse(stringWeight);
            string passportNumber; 
            do
            {
                Console.WriteLine("Enter passport number (length should be 10 symbols):");
                passportNumber = Console.ReadLine();
            } while (!checkPassport(passportNumber));
            FullAge newOne = new FullAge(name, age, weight, passportNumber);
            return newOne;
        }
        static Human addHuman()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            string stringAge;
            int age;
            do
            {
                Console.WriteLine("Enter age:");
                stringAge = Console.ReadLine();
            } while (!checkAge(stringAge));
            age = int.Parse(stringAge);
            string stringWeight;
            int weight;
            do
            {
                Console.WriteLine("Enter weight:");
                stringWeight = Console.ReadLine();
            } while (!checkWeight(stringWeight));
            weight = int.Parse(stringWeight);
            Human newOne = new Human(name, age, weight);
            return newOne;
        }
        static void Main(string[] args)
        {
            //FullAge Dima = new FullAge("Dima", 19, 70);
            //Console.WriteLine(Dima);
            List<FullAge> fullAges = new List<FullAge> { };
            List<Human> humen = new List<Human> { };
            int input;
            do
            {
                Console.WriteLine("Enter 1 to add new fullage");
                Console.WriteLine("Enter 2 to add new Human");
                Console.WriteLine("Enter 0 to exit the program ");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        FullAge newFullAge = addFullAge();
                        fullAges.Add(newFullAge);
                        break;
                    case 2:
                        Human newHuman = addHuman();
                        humen.Add(newHuman);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Wrong input, please try again");
                        break;
                }
            } while (input != 0);
            foreach (FullAge oneFullAge in fullAges)  
            {
                Console.WriteLine(oneFullAge);
            }
        }
    }
}
