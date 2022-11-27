using ClassLibrary;
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
            try
            {
                PageModel.CheckConection();
                var sql = @$"select * from {PageModel.pref}.Orders";
                var cmd = new NpgsqlCommand(sql, PageModel.connection);
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                    while (result.Read())
                    {
                        Services.Add(new Service()
                        {
                            Id = (int)result.GetValue(0),
                            Name= (string)result.GetValue(1),
                            Description = (string)result.GetValue(2),
                            Price = (int)result.GetValue(3),
                            Status = (Status)result.GetValue(4)
                        });

                    }
            }
            catch
            {
                //Получение списка клиентов
                Services = new ObservableCollection<Service>();
            }
        }
    }
}
