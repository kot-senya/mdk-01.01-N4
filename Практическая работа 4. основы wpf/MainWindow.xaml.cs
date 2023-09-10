using System;
using System.Collections.Generic;
using System.Data;
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

namespace Практическая_работа_4.основы_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Back.Visibility = Visibility.Collapsed;
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime date = DP.SelectedDate.Value; //получение даты рождения

                if (date > DateTime.Now)
                {
                    Back.Visibility = Visibility.Collapsed;
                    MessageBox.Show("Выбранная дата не может быть больше текущей");
                }
                else
                {
                    TBAnswer1.Text = task1(date);
                    TBAnswer2.Text = task2(date);
                    TBAnswer3.Text = task3(date);

                    Back.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string task1(DateTime actualDate)
        {
            DateTime date = new DateTime(actualDate.Year + 1, 12, 31); //получение сегодняшней даты

            double allDay = (DateTime.Now - actualDate).TotalDays + 1; //количество всех дней

            int countYear = 0;//количество лет
            int countMonth = 0;//количество месяцев
            int countDay = 0;//количество дней

            //считаем года
            while (allDay > date.DayOfYear)
            {
                countYear++;
                if (date.Year == DateTime.Now.Year)
                {
                    break;
                }
                else
                {
                    allDay -= date.DayOfYear;
                    date = date.AddYears(1);
                }
            }

            date = new DateTime(date.Year, 1, 1); //начало года

            //считаем месяца
            while (allDay > DateTime.DaysInMonth(date.Year, date.Month))
            {
                allDay -= DateTime.DaysInMonth(date.Year, date.Month);
                countMonth++;
                date = date.AddMonths(1);
            }

            //вычитаем излишки
            if (DateTime.Now > new DateTime(DateTime.Now.Year, actualDate.Month, actualDate.Day) && countMonth > 12)
            {
                countMonth -= 12;
            }

            //считаем дни
            if (allDay > 0)
            {
                countDay = (int)allDay / 1;
            }

            //формулировка предложения
            string value = "Вам " + countYear + " ";

            if (countYear > 19 && countYear < 11)
            {
                switch (countYear % 10)
                {
                    case (1):
                        {
                            value += "год " + countMonth + " ";
                        }
                        break;
                    case (2):
                    case (3):
                    case (4):
                        {
                            value += "года " + countMonth + " ";
                        }
                        break;
                    case (5):
                    case (6):
                    case (7):
                    case (8):
                    case (9):
                    case (0):
                        {
                            value += "лет " + countMonth + " ";
                        }
                        break;

                }
            }
            else
            {
                value += "лет " + countMonth + " ";
            }

            if (countMonth == 1)
            {
                value += "месяц " + countDay + " ";
            }
            else if (countMonth == 2 || countMonth == 3 || countMonth == 4)
            {
                value += "месяца " + countDay + " ";
            }
            else
            {
                value += "месяцев " + countDay + " ";
            }

            if (countDay > 19 || countDay < 11)
            {
                switch (countDay % 10)
                {
                    case (1):
                        {
                            value += "день ";
                        }
                        break;
                    case (2):
                    case (3):
                    case (4):
                        {
                            value += "дня ";
                        }
                        break;
                    case (5):
                    case (6):
                    case (7):
                    case (8):
                    case (9):
                    case (0):
                        {
                            value += "дней ";
                        }
                        break;

                }
            }
            else
            {
                value += "дней ";
            }

            return value;
        }

        private string task2(DateTime actualDate)
        {
            DateTime date = actualDate; //переменная для хождения по датам
            int count = 0; //количество др в этот день

            while (date <= DateTime.Now)
            {
                if (actualDate.DayOfWeek == date.DayOfWeek)
                {
                    count++;
                }
                date = date.AddYears(1);
            }

            return "День недели в который вы родились - " + actualDate.ToString("dddd") + "\nКоличество дней рождения до " + DateTime.Now.ToString("dd MMM yyyy") + ", которые попадали на этот день недели - " + count;
        }

        private string task3(DateTime actualDate)
        {
            DateTime date = new DateTime(actualDate.Year, 12, 31);
            string value = "Високосные года: ";
            int count = 0;

            while (date.Year <= DateTime.Now.Year)
            {
                if (date.DayOfYear == 366)
                {
                    value += date.ToString("yyyy") + ", ";
                    count++;
                }
                date = date.AddYears(1);
            }

            if (count == 0)//т.е. человек не прожил еще весокосный год
            {
                return "Количество високосных лет, прошедших со дня рождения 0";
            }
            else
            {
                return "Количество високосных лет, прошедших со дня рождения - " + count + "\n" + value.Remove(value.Length - 2);
            }
        }
    }
}
