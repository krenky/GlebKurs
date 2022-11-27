using ClassLibrary;
using GlebKurs.Model;
using GlebKurs.View;
using Npgsql;
using System.Collections.ObjectModel;

namespace GlebKurs.ViewModel
{
    class ManagersVM : Utilities.ViewModelBase
    {
        private ObservableCollection<Manager> managers;
        private ObservableCollection<Manager> Managers { get => managers; set { managers = value; OnPropertyChanged(); } }
        public ManagersVM()
        {
            try
            {
                PageModel.CheckConection();
                var sql = @$"select * from {PageModel.pref}.Managers";
                var cmd = new NpgsqlCommand(sql, PageModel.connection);
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                    while (result.Read())
                    {
                        Managers.Add(new Manager()
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1),
                            FillialId = (int)result.GetValue(2)
                        });

                    }
            }
            catch
            {
                //Получение списка клиентов
                Managers = new ObservableCollection<Manager>();
            }
        }
    }
}
