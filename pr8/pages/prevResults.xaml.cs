using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для prevResults.xaml
    /// </summary>
    public partial class prevResults : Page
    {
        public prevResults()
        {
            InitializeComponent();
        }

        // Загружает в DataGrid данные из БД

        private void LoadAllRunners()
        {

            // Подключение к БД
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=Hatnii;Initial Catalog=MarathonSkills;Integrated Security=True";

            // Открыть подключение
            connection.Open();

            // Создание команды для БД(запрос)
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  TOP(100) Name AS [Имя бегуна], Time AS Время FROM dbo.Runners ORDER BY Time";
            cmd.Connection = connection;

            // Зафиксировать изменения в БД
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Отобразить новую таблицу
            DataTable dt = new DataTable("Runners");

            // Вывод в датагрид
            da.Fill(dt);
            MainDataGrid.ItemsSource = dt.DefaultView;

            // Закрыть поключение
            connection.Close();

        }

        private void LoadCountOfRunners(TextBlock x)
        {
            
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=Hatnii;Initial Catalog=MarathonSkills;Integrated Security=True";
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT COUNT(Name) FROM dbo.Runners";
            cmd.Connection = connection;
            x.Text = $"Всего бегунов:  {cmd.ExecuteScalar().ToString()}";
            connection.Close();
            
        }
        
        private void LoadPrevDataBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadAllRunners();
            LoadCountOfRunners(prevResTXT);
        }
    }
}
