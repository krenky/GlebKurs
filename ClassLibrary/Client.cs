using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ClassLibrary
{
    public class Client : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;

        public int Id { get; set; }
        [Required]
        public string FirstName
        {
            get => firstName; 
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        [Required]
        public string LastName { get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Email { get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Phone { get => phone;
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Address { get => Address;
            set
            {
                Address = value;
                OnPropertyChanged("Address");
            }
        }
        public List<Order> Orders { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}