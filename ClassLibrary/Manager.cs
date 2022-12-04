using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClassLibrary
{
    public class Manager : INotifyPropertyChanged
    {
        private string name;
        private Fillial fillial;

        public int Id { get; set; }
        public string Name { get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public List<Order> Orders { get; set; }
        public Fillial Fillial { get => fillial;
            set
            {
                fillial = value;
                OnPropertyChanged("Fillial");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public enum Fillial
    {
        kaz,
        alm,
        che
    }
}
