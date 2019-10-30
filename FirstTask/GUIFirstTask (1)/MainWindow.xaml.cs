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
        List<FullAge> fullAges = new List<FullAge> { };
        List<Human> humen = new List<Human> { };
        static FullAge addNewFullAge(string newName, string newAge, string newWeight, string newPasport)
        {
            FullAge newOne;
            if (!Program.checkAge(newAge) || int.Parse(newAge) < 14)
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный возраст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            if (!Program.checkWeight(newWeight))
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный вес", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            if (!Program.checkWeight(newPasport))
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный номер паспорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            else { 
            // TODO add checks
                int newIntAge = int.Parse(newAge);
                float newFloatWeight = float.Parse(newWeight);
                newOne = new FullAge(newName, newIntAge, newFloatWeight, newPasport);
                return newOne;
            }
        }
        static FullAge addNewHuman(string newName, string newAge, string newWeight)
        {
            FullAge newOne;
            if (!Program.checkAge(newAge) || int.Parse(newAge) < 14)
            {
                MessageBoxResult result = MessageBox.Show("Ошибка, неверный возраст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            if (!Program.checkWeight(newWeight))
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
            if (chooseBox.Text == "Человек")
            {
                Human human;
                human = addNewHuman(name, stringAge, stringWeight);
                if (human != null)
                {
                    humen.Add(human);
                    MessageBox.Show("Успешно добавлено", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if (chooseBox.Text == "Совершеннолетний")
            {
                FullAge fullAge;
                fullAge = addNewFullAge(name, stringAge, stringWeight, pasportNumber);
                if (fullAge != null)
                {
                    fullAges.Add(fullAge);
                    MessageBox.Show("Успешно добавлено", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void txtButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (FullAge onefullAge in fullAges)
            {
                onefullAge.streamToFileFullAge();
            }
            foreach (Human oneHuman in humen)
            {
                oneHuman.streamToFileHuman();
            }
            MessageBox.Show("Успешно выведенно", "Вывод", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
