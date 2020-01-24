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
        private string name; //Name of the human
        private int age { get; set; } //Age of the human
        private float weight; //Weight of the human
        //Constructor by default
        public Human() {
            name = "";
            age = 0;
            weight = 0;
        }
        //Constructor with all values
        public Human(string name="", int age=0, float weight=0)
        {
            this.name = name;
            this.age = age;
            this.weight = weight;
        }
        //Override output
        public override string ToString() 
        {
            return "Name: " + name + "\nAge: " +
                age + "\nWeight: " + weight;
        }
        //Output all data in txt file
        public void streamToFile()
        {
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile =
                File.AppendText("Humans.txt"))
            {
                outputFile.Write(ToString());
            }
        }
    }
    
    public class PasportHolder: Human
    {
        private string pasportNumber { get; set; } //Number of pasport
        public PasportHolder()
        {
            pasportNumber = "";
        }
        public PasportHolder(string name = "", int age = 0, float weight = 0,
            string pasportNumber = "")
            : base(name, age, weight)
        {
            this.pasportNumber = pasportNumber;
        }
        public override string ToString()
        {
            return base.ToString() + "\nPassport Number: " + pasportNumber;
        }
    }

    public class FullAge: PasportHolder
    {
        private bool hasResponsability;
        private bool canBePresident;
        //Constructor by default
        public FullAge()
        {
            hasResponsability = true;
            canBePresident = false;
        }
        //Constructor with all values
        public FullAge(string name="", int age=0, float weight=0,
            string passportNumber= "")
            : base(name, age, weight, passportNumber)
        {
            this.hasResponsability = true;
            if (age >= 35)
            {
                this.canBePresident = true;
            }
            else
            {
                this.canBePresident = false;
            }
        }
        //Override output
        public override string ToString() 
        {
            return base.ToString() + "\nHas Responsability: " + hasResponsability.ToString() +
                "\nCan be president: "+ canBePresident.ToString();
        }
    }
    class CheckHumanEnter
    {
        public static bool checkPasport(string passportNumber) //Function to check pasportNumber
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
        public static bool checkAge(string age) //Function to check age
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
        public static bool checkWeight(string weight) //Function to check weight
        {
            try
            {
                float.Parse(weight);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
