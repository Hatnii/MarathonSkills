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
using System.Windows.Shapes;

namespace pr8
{
    /// <summary>
    /// Логика взаимодействия для Окно_приложения.xaml
    /// </summary>
    public partial class Окно_приложения : Window
    {
        public Окно_приложения()
        {
            InitializeComponent();
            DateTime date1 = new DateTime(2021, 11, 24, 0, 0, 0);
            int d = (date1.Month * 31) - DateTime.Now.Day;
            int h = date1.Hour - DateTime.Now.Hour;
            int min = date1.Minute - DateTime.Now.Minute;
            int sec = date1.Second - DateTime.Now.Second;
            if (date1.Hour < DateTime.Now.Hour)
            {
                h = h * -1;
            }
            if (date1.Minute < DateTime.Now.Minute)
            {
                min = 60 + min;
            }
            if (date1.Second < DateTime.Now.Second)
            {
                sec = sec + 60;
            }
            timerLab.Content = d + " дней " + h + " часов "
                 + min + " минут" + " и " + sec + " секунд до старта марафона";
        }

        private void Conteiner_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ConteinerDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void aboutBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new pages.About();
        }

        private void BMIbtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new pages.BMI();
        }

        private void prevResultBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new pages.prevResults();
        }
    }
}
