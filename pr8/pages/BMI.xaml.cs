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

namespace pr8.pages
{
    /// <summary>
    /// Логика взаимодействия для BMI.xaml
    /// </summary>
    public partial class BMI : Page
    {
        public BMI()
        {
            InitializeComponent();
        }

        private void CountBtn_Click(object sender, RoutedEventArgs e)
        {

            if (WeightBox.Text == "")
            {
                ResultTxT.Text = "Поля для ввода не должны быть пустыми";
            }

            else if (HeightBox.Text == "")
            {
                ResultTxT.Text = "Поля для ввода не должны быть пустыми";
            }
            
            else
            {
                try
                {
                    double weight = int.Parse(WeightBox.Text);
                    string x = HeightBox.Text;
                    x = x.Insert(1, ",");
                    double height = double.Parse(x);
                    double badresult = weight / Math.Pow(height, 2);
                    badresult = Math.Round(badresult, 2);
                    Result(badresult);
                }
                catch 
                { 
                    ResultTxT.Text = "Введите числа!"; 
                }
            }

        }

        private void EraseBtn_Click(object sender, RoutedEventArgs e)
        {
            HeightBox.Text = null;
            WeightBox.Text = null;
        }

        public void Result(double x)
        {


            if (x < 16)
            {
                string classific = "Выраженный дефицит массы тела";
                ResultTxT.Text = $"Ваш индекс массы тела: {x}\n Данное значение ИМТ соответствует:\n {classific}";
            }
            else if (x >= 16 && x < 18.5)
            {
                string classific = "Недостаточная масса тела";
                ResultTxT.Text = $"Ваш индекс массы тела: {x}\n Данное значение ИМТ соответствует:\n {classific}";
            }
            else if(x >= 18.5 && x< 25)
            { 
                string classific = "Нормальная масса тела";
                ResultTxT.Text = $"Ваш индекс массы тела: {x}\n Данное значение ИМТ соответствует:\n {classific}";
            }
            else if (x >= 25 && x < 30)
            {
                string classific = "Избыточная масса тела (предожирение)";
                ResultTxT.Text = $"Ваш индекс массы тела: {x}\n Данное значение ИМТ соответствует:\n {classific}";
            }
            else if (x >= 30 && x < 35)
            {
                string classific = "Ожирение 1-ой степени ";
                ResultTxT.Text = $"Ваш индекс массы тела: {x}\n Данное значение ИМТ соответствует:\n {classific}";
            }
            else if (x >= 35 && x < 40)
            {
                string classific = "Ожирение 2-ой степени";
                ResultTxT.Text = $"Ваш индекс массы тела: {x}\n Данное значение ИМТ соответствует:\n {classific}";
            }

            else if (x >= 40)
            {
                string classific = "Ожирение 3-ой степени";
                ResultTxT.Text = $"Ваш индекс массы тела: {x}\n Данное значение ИМТ соответствует:\n {classific}";
            }

        }

        private void HeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HeightBox.Text.Length > 0)
            {
                HeightWater.Visibility = Visibility.Collapsed;
            }
            else
            {
                HeightWater.Visibility = Visibility.Visible;
            }
        }

        private void WeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (WeightBox.Text.Length > 0)
            {
                WeightWater.Visibility = Visibility.Collapsed;
            }
            else
            {
                WeightWater.Visibility = Visibility.Visible;
            }
        }
    }

}
