using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using FirstTask;

namespace GUIFirstTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Human> humans = new List<Human> { }; //List of all humen
        //Error handling for PasportHolder
        static PasportHolder addNewPasportHolder(string newName, string newAge, string newWeight, string newPasport)
        {
            PasportHolder newOne;
            if (!CheckHumanEnter.checkAge(newAge) || int.Parse(newAge) < 14)
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный возраст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            if (!CheckHumanEnter.checkWeight(newWeight))
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный вес", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            if (!CheckHumanEnter.checkPasport(newPasport))
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный номер паспорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            else { 
                int newIntAge = int.Parse(newAge);
                float newFloatWeight = float.Parse(newWeight);
                newOne = new PasportHolder(newName, newIntAge, newFloatWeight, newPasport);
                return newOne;
            }
        }
        //Error handling for FullAge
        static FullAge addNewFullAge(string newName, string newAge, string newWeight, string newPasport)
        {
            FullAge newOne;
            if (!CheckHumanEnter.checkAge(newAge) || int.Parse(newAge) < 14)
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный возраст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            if (!CheckHumanEnter.checkWeight(newWeight))
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный вес", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            if (!CheckHumanEnter.checkPasport(newPasport))
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный номер паспорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            else
            {
                int newIntAge = int.Parse(newAge);
                float newFloatWeight = float.Parse(newWeight);
                newOne = new FullAge(newName, newIntAge, newFloatWeight, newPasport);
                return newOne;
            }
        }
        //Error handling for Human
        static FullAge addNewHuman(string newName, string newAge, string newWeight)
        {
            FullAge newOne;
            if (!CheckHumanEnter.checkAge(newAge) || int.Parse(newAge) < 14)
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный возраст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            if (!CheckHumanEnter.checkWeight(newWeight))
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный вес", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            else
            {
                // TODO add checks
                int newIntAge = int.Parse(newAge);
                float newFloatWeight = float.Parse(newWeight);
                newOne = new FullAge(newName, newIntAge, newFloatWeight);
                return newOne;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            string stringAge = ageBox.Text;
            string stringWeight = weightBox.Text;
            string pasportNumber = pasportBox.Text;
            switch (chooseBox.Text) //Deciding who to add, based on chooseBox
            {
                case "Человек":
                    Human human;
                    human = addNewHuman(name, stringAge, stringWeight);
                    if (human != null)
                    {
                        humans.Add(human);
                        MessageBox.Show("Успешно добавлено", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
                case "Держатель паспорта":
                    PasportHolder pasportHolder;
                    pasportHolder = addNewPasportHolder(name, stringAge, stringWeight, pasportNumber);
                    if (pasportHolder != null)
                    {
                        humans.Add(pasportHolder);
                        MessageBox.Show("Успешно добавлено", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
                case "Совершеннолетний":
                    FullAge fullAge;
                    fullAge = addNewFullAge(name, stringAge, stringWeight, pasportNumber);
                    if (fullAge != null)
                    {
                        humans.Add(fullAge);
                        MessageBox.Show("Успешно добавлено", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
                default: break;
            }
        }
        //Button for printing all humans in txt file
        private void txtButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Human oneHuman in humans)
            {
                oneHuman.streamToFile();
            }
            MessageBox.Show("Успешно выведенно", "Вывод", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
