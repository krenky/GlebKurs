using ClassLibrary;
using GlebKurs.Context;
using GlebKurs.Model;
using GlebKurs.View;
using Npgsql;
using System.Collections.ObjectModel;
using System.Linq;

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
                using (ApplicationContext db = new ApplicationContext())
                {
                    // получаем объекты из бд и выводим на консоль
                    var managerList = db.Manager.ToList();
                    Managers = new ObservableCollection<Manager>(managerList);
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
