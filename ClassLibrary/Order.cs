using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class Order : INotifyPropertyChanged
    {
        private int clientId;
        private int managerId;
        private PayType payType = PayType.Картой;
        private StatusOrder status = StatusOrder.НеОплачено;

        public int Id { get; set; }
        public int ClientId { get => clientId;
            set
            {
                clientId = value;
                OnPropertyChanged("ClientId");
            }
        }
        public Client Client { get; set; }
        public int ManagerId { get => managerId;
            set
            {
                managerId = value;
                OnPropertyChanged("ManagerId");
            }
        }
        public Manager Manager { get; set; }
        public List<Service> Services { get; set; }
        public PayType PayType { get => payType;
            set
            {
                payType = PayType;
                OnPropertyChanged("Name");
            }
        }
        public StatusOrder Status { get => status;
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
    public enum PayType
    {
        Картой,
        Наличными
    }
    public enum StatusOrder
    {
        Оплачено,
        НеОплачено
    }
}
