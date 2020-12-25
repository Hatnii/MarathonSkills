using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Регистрация.xaml
    /// </summary>
    public partial class Регистрация : Window
    {
        public Регистрация()
        {
            InitializeComponent();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (tb2.Password.Length > 0)
            {
                WaterMark.Visibility = Visibility.Collapsed;
            }
            else
            {
                WaterMark.Visibility = Visibility.Visible;
            }
        }

        private void tb3_TextChanged(object sender, TextChangedEventArgs e)
        {


            string expresion = @"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+ \w*вич$";
            string expresionFem = @"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+ \w*вна$";

            if (Regex.IsMatch(tb3.Text, expresion) || Regex.IsMatch(tb3.Text, expresionFem))
            {
                if (Regex.Replace(tb3.Text, expresion, string.Empty).Length == 0)
                {
                    CorrectFIO(okFIO, badFIO, tb3);
                }
               

                else if (Regex.Replace(tb3.Text, expresionFem, string.Empty).Length == 0)
                {
                    CorrectFIO(okFIO, badFIO, tb3);
                }
                else tb3.BorderBrush = Brushes.Red;

            }
            else
            {
                IncorrectFIO(badFIO, okFIO, tb3);

            }

        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string expresion = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            if (Regex.IsMatch(tb1.Text, expresion))
            {
                if (Regex.Replace(tb1.Text, expresion, string.Empty).Length == 0)
                {
                    CorrectEmail(okEmail, badEmail, tb1);
                }
                else
                {
                    tb1.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                IncorrectEmail(badEmail, okEmail, tb1);

            }
        }

        private void tb2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string expresion = tb2.Password;
            if (expresion.Length > 5)
            {
                if (Regex.Replace(tb2.Password, expresion, string.Empty).Length == 0)
                {
                    CorrectPass(okPass, badPass, tb2);
                }
                else
                {
                    tb2.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                IncorrectPass(badPass, okPass, tb2);

            }
        }

        private void CorrectEmail(Label x, Label y, TextBox z)
        {
            x.Content = "Почта введена корректно";
            y.Content = "";
            z.BorderBrush = Brushes.Green;
        }

        private void IncorrectEmail(Label x, Label y, TextBox z)
        {
            x.Content = "Почта введена некорректно";
            y.Content = "";
            z.BorderBrush = Brushes.Red;

        }

        private void CorrectPass(Label x, Label y, PasswordBox z)
        {
            x.Content = "Пароль введен корректно";
            y.Content = "";
            z.BorderBrush = Brushes.Green;
        }

        private void IncorrectPass(Label x, Label y, PasswordBox z)
        {
            x.Content = "Пароль должен быть больше 5-ти символов";
            y.Content = "";
            z.BorderBrush = Brushes.Red;
        }

        private void CorrectFIO(Label x, Label y, TextBox z)
        {
            x.Content = "ФИО введено корректно";
            y.Content = "";
            z.BorderBrush = Brushes.Green;
        }

        private void IncorrectFIO(Label x, Label y, TextBox z)
        {
            x.Content = "ФИО введено некорректно";
            y.Content = "";
            z.BorderBrush = Brushes.Red;
        }

    }
}
