using ClassLibrary;
using GlebKurs.Context;
using GlebKurs.Model;
using GlebKurs.View;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlebKurs.ViewModel
{
    class ServicesVM : Utilities.ViewModelBase
    {
        private ObservableCollection<Service> services;
        private ObservableCollection<Service> Services { get => services; set { services = value; OnPropertyChanged(); } }
        public ServicesVM()
        {
            //try
            //{
            //    using (ApplicationContext db = new ApplicationContext(currentFillial))
            //    {
            //        // получаем объекты из бд и выводим на консоль
            //        var serviceList = db.Service.ToList();
            //        Services = new ObservableCollection<Service>(serviceList);
            //    }
            //}
            //catch
            //{
            //    //Получение списка клиентов
            //    Services = new ObservableCollection<Service>();
            //}
        }
    }
}
