using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClassLibrary
{
    public class Service
    {
        private Status status = Status.New;
        private float price;
        private string name;
        private string? description;

        public int Id { get; set; }
        public string Name { get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string? Description { get => description;
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public float Price { get => price;
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public Status Status { get => status;
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public enum Status
    {
        Success,
        New,
        Close
    }
}
