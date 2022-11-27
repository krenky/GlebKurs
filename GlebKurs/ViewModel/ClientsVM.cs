using ClassLibrary;
using GlebKurs.Model;
using Npgsql;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                PageModel.CheckConection();
                var sql = @$"select * from {PageModel.pref}.Clients";
                var cmd = new NpgsqlCommand(sql, PageModel.connection);
                var result = cmd.ExecuteReader();
                if(result.HasRows)
                    while (result.Read())
                    {
                        Clients.Add(new Client()
                        {
                            Id = (int)result.GetValue(0),
                            FirstName = (string)result.GetValue(1),
                            LastName = (string)result.GetValue(2),
                            Email= (string)result.GetValue(3),
                            Phone= (string)result.GetValue(4),
                            Address= (string)result.GetValue(5),
                        }) ;
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
