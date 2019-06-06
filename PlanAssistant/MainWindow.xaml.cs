using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            try
            {
                tasks.Add(
                new Task
                {
                    DateTime = new DateTime(datePicker.SelectedDate.Value.Ticks + timePicker.SelectedTime.Value.Ticks),
                    Frequency = FrequrencyByNameReturing(frequencyComboBox.SelectionBoxItemStringFormat),
                    TaskType = new object(),
                });

                switch (typeComboBox.SelectedIndex)
                {
                    case 0:
                        //tasks[tasks.Count - 1].ChooseTaskType("email", firstTextBox.Text, secondTextBox.Text);
                        SendMessage(firstTextBox.Text, "", secondTextBox.Text);
                        break;
                    case 1:
                        tasks[tasks.Count - 1].ChooseTaskType("downloadFile", firstTextBox.Text, secondTextBox.Text);
                        break;
                    case 2:
                        tasks[tasks.Count - 1].ChooseTaskType("moveCatalog", firstTextBox.Text, secondTextBox.Text);
                        break;
                }
                ////База данных не сохраняет данные, что-то одинаковое
                //using (var context = new AppContext())
                //{
                //    context.Tasks.Add(tasks[tasks.Count - 1]);
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        public void SendMessage(string mail, string header, string text)
        {
            MailAddress From;
            MailAddress To;

            From = new MailAddress("dinara_myrzabek@mail.ru", "Dinara");
            To = new MailAddress(mail, "");

            MailMessage m = new MailMessage(From, To);

            m.Subject = header;
            m.Body = text;
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient(From.Address, -875);
            smtp.Credentials = new NetworkCredential(From.Address, "J21Z9Z4U");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
