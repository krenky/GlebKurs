using ClassLibrary;
using GlebKurs.Context;
using GlebKurs.Model;
using GlebKurs.View;
using Npgsql;
using System.Collections.ObjectModel;
using System.Linq;

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
                    using (ApplicationContext db = new ApplicationContext(currentFillial))
                    {
                        // получаем объекты из бд и выводим на консоль
                        var orderList = db.Order.ToList();
                        Orders = new ObservableCollection<Order>(orderList);
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
