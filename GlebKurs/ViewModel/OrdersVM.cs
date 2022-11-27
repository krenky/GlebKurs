using ClassLibrary;
using GlebKurs.Model;
using GlebKurs.View;
using Npgsql;
using System.Collections.ObjectModel;

namespace GlebKurs.ViewModel
{
    class OrdersVM : Utilities.ViewModelBase
    {
        private ObservableCollection<Order> orders;
        private ObservableCollection<Order> Orders { get => orders; set { orders = value; OnPropertyChanged(); } }
        public OrdersVM()
        {
            try
            {
                PageModel.CheckConection();
                var sql = @$"select * from {PageModel.pref}.Orders";
                var cmd = new NpgsqlCommand(sql, PageModel.connection);
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                    while (result.Read())
                    {
                        Orders.Add(new Order()
                        {
                            Id = (int)result.GetValue(0),
                            ClientId= (int)result.GetValue(1),
                            ManagerId= (int)result.GetValue(2),
                            PayType = (PayType)result.GetValue(3),
                            Status = (StatusOrder)result.GetValue(4),
                        });

                    }
            }
            catch
            {
                //Получение списка клиентов
                Orders = new ObservableCollection<Order>();
            }
        }
    }
}
