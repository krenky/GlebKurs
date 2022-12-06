using ClassLibrary;
using Npgsql;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GlebKurs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Fillial fillial = Fillial.kaz;
        static string connectionString = "Host=localhost;port=49155;Username=postgres;Password=postgrespw;Database=postgres";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        public MainWindow()
        {
            InitializeComponent();
            //try
            //{
            //    //Открываем соединение.
            //    connection.Open();
            //    if (connection.FullState == ConnectionState.Broken || connection.FullState == ConnectionState.Closed)
            //    {
            //        throw new Exception("С соединением что то не так");
            //        //Тут меняем что-то в своей жизни, но я обычно выбрасываю исключение, чтобы не искать в коде миллион лет, что сломалось.
            //    }

            //}
            //catch (Exception ex)
            //{
            //    //Код обработки ошибок
            //}
        }

        private void FillialEnumCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
