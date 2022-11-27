using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlebKurs.Model
{
    public static class PageModel
    {
        static string connectionString = "Host=localhost;port=49155;Username=postgres;Password=postgrespw;Database=postgres";
        public static NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        public static pref pref = pref.kaz;
        public static void CheckConection()
        {
            try
            {
                //Открываем соединение.
                connection.Open();
                if (connection.FullState == ConnectionState.Broken || connection.FullState == ConnectionState.Closed)
                {
                    throw new Exception("С соединением что то не так");
                    //Тут меняем что-то в своей жизни, но я обычно выбрасываю исключение, чтобы не искать в коде миллион лет, что сломалось.
                }

            }
            catch (Exception ex)
            {
                //Код обработки ошибок
            }
        }
    }
    public enum pref
    {
        kaz,
        alm
    }
}
