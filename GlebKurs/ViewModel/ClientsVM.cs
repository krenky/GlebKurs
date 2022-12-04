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
        private ObservableCollection<Client> Clients { get => clients; set { clients = value; OnPropertyChanged(); } }
        public ClientsVM() 
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    // получаем объекты из бд и выводим на консоль
                    var clientList = db.Client.ToList();
                    Clients = new ObservableCollection<Client>(clientList);
                }
            }
            catch
            {
                //Получение списка клиентов
                Clients = new ObservableCollection<Client>();
            }
        }
    }
}
