using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace PlanAssistant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Task> tasks = new List<Task>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void TypeComboBoxSelected(object sender, RoutedEventArgs e)
        {
            switch (typeComboBox.SelectedIndex)
            {
                case -1:
                    firstTextBlock.Text = "";
                    secondTextBlock.Text = "";
                    break;
                case 0:
                    firstTextBlock.Text = "Введите адрес отправителя";
                    secondTextBlock.Text = "Текст сообщения";
                    break;
                case 1:
                    firstTextBlock.Text = "Введите url";
                    secondTextBlock.Text = "Путь куда скачать";
                    break;
                case 2:
                    firstTextBlock.Text = "Путь каталога";
                    secondTextBlock.Text = "Новый путь каталога";
                    break;
            }
        }

        private void ReadyButtonClick(object sender, RoutedEventArgs e)
        {

            tasks.Add(
                new Task
                {
                    DateTime = new DateTime(datePicker.SelectedDate.Value.Ticks + timePicker.SelectedTime.Value.Ticks),
                    Frequency = FrequrencyByNameReturing(frequencyComboBox.SelectionBoxItemStringFormat)
                });
        }

        private Frequency FrequrencyByNameReturing(string name)
        {
            Frequency frequency = new Frequency();

            switch (name)
            {
                case "раз в день":

                    break;
                case "раз в неделю":

                    break;
                case "раз в месяц":

                    break;
                case "раз в год":

                    break;
                    
            }

            return frequency;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
