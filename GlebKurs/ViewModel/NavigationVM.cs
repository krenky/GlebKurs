using GlebKurs.Utilities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Windows.Input;

namespace GlebKurs.ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;

        public object CurrentView { get => _currentView; set { _currentView = value; OnPropertyChanged(); } }


        public ICommand ClientsCommand { get; set; }
        public ICommand ManagersCommand { get; set; }
        public ICommand OrdersCommand { get; set; } 
        public ICommand ServiceCommand { get; set; }

        private void Clients(object obj) => CurrentView = new ClientsVM();
        private void Managers(object obj) => CurrentView = new ManagersVM();
        private void Orders(object obj) => CurrentView = new OrdersVM();
        private void Service(object obj) => CurrentView = new ServicesVM();

        public NavigationVM()
        {
            ClientsCommand = new RelayCommand(Clients);
            ManagersCommand= new RelayCommand(Managers);
            OrdersCommand= new RelayCommand(Orders);
            ServiceCommand= new RelayCommand(Service);

            CurrentView = new ClientsVM();

        }
    }
}
