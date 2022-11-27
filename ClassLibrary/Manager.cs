using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClassLibrary
{
    public class Manager : INotifyPropertyChanged
    {
        private string name;
        private int fillialId;

        public int Id { get; set; }
        public string Name { get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public List<Order> Orders { get; set; }
        public int FillialId { get => fillialId;
            set
            {
                fillialId = value;
                OnPropertyChanged("FillialId");
            }
        }
        public Fillial Fillial { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
