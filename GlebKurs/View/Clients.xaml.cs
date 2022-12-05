using ClassLibrary;
using GlebKurs.Context;
using System;
using System.Windows.Controls;

namespace GlebKurs.View
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : UserControl
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void DataClient_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            
        }

        private void DataClient_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            TextBlock selectedItem = (TextBlock)FillialEnumCombo.SelectedItem;
            using (var context = new ApplicationContext(Enum.Parse<Fillial>(selectedItem.Text)))
            {

            }
            Console.WriteLine(DataClient.Items);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBlock selectedItem = (TextBlock)FillialEnumCombo.SelectedItem;
            using (var context = new ApplicationContext(Enum.Parse<Fillial>(selectedItem.Text)))
            {
                context.Client.Add(new Client()
                {
                    FirstName= FirstNameBox.Text,
                    LastName= LastNameBox.Text,
                    Email= EmailBox.Text,
                    Phone= PhoneBox.Text,
                    Address= AddressBox.Text,
                });
                context.SaveChanges();
            }
            DataClient.UpdateLayout();
        }
    }
}
