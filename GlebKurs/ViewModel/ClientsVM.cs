using ClassLibrary;
using GlebKurs.Context;
using GlebKurs.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;

namespace GlebKurs.ViewModel
{
    class ClientsVM : Utilities.ViewModelBase
    {
        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients { get => clients; set { clients = value; OnPropertyChanged(); } }
        public ClientsVM() 
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext(currentFillial))
                {
                    // получаем объекты из бд и выводим на консоль
                    var clientList = db.Client.ToList();
                    Clients = new ObservableCollection<Client>(clientList);
                }
                PropertyChanged += Update_Client;
                Clients.CollectionChanged += Update_Client;
            }
            catch
            {
                //Получение списка клиентов
                Clients = new ObservableCollection<Client>();
            }
        }
        void Update_Client(object sender, EventArgs e)
        {
            using(var context = new ApplicationContext(currentFillial))
            {
                context.UpdateRange(clients.Where(x => x.Id != 0));
                context.SaveChanges();
            }
        }
    }
}
