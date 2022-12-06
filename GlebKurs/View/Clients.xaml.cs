using ClassLibrary;
using GlebKurs.Context;
using GlebKurs.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace GlebKurs.View
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : UserControl
    {
        List<Client> clients;
        public Clients()
        {
            InitializeComponent();
            //using (var context = new ApplicationContext(Fillial.kaz))
            //{
            //    clients = context.Client.ToList();
            //    DataClient.ItemsSource = clients;
            //}
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
            switch (MainWindow.fillial)
            {
                case Fillial.kaz:
                    {
                        using (var context = new KazContext())
                        {

                            context.Client.Add(new Client()
                            {
                                FirstName = FirstNameBox.Text,
                                LastName = LastNameBox.Text,
                                Email = EmailBox.Text,
                                Phone = PhoneBox.Text,
                                Address = AddressBox.Text,
                            });
                            context.SaveChanges();
                            DataClient.ItemsSource = null;
                            DataClient.ItemsSource = context.Client.ToList();
                        }
                    }
                    break;
                case Fillial.che:
                    {
                        using (var context = new CheContext())
                        {

                            context.Client.Add(new Client()
                            {
                                FirstName = FirstNameBox.Text,
                                LastName = LastNameBox.Text,
                                Email = EmailBox.Text,
                                Phone = PhoneBox.Text,
                                Address = AddressBox.Text,
                            });
                            context.SaveChanges();
                            DataClient.ItemsSource = null;
                            DataClient.ItemsSource = context.Client.ToList();
                        }
                    }
                    break;
                case Fillial.alm:
                    {
                        using (var context = new AlmContext())
                        {
                            context.Client.Add(new Client()
                            {
                                FirstName = FirstNameBox.Text,
                                LastName = LastNameBox.Text,
                                Email = EmailBox.Text,
                                Phone = PhoneBox.Text,
                                Address = AddressBox.Text,
                            });
                            context.SaveChanges();
                            DataClient.ItemsSource = null;
                            DataClient.ItemsSource = context.Client.ToList();
                        }
                    }
                    break;
            }

        }

        private void FillialEnumCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock selectedItem = (TextBlock)FillialEnumCombo.SelectedItem;
            MainWindow.fillial = Enum.Parse<Fillial>(selectedItem.Text);
            switch (MainWindow.fillial)
            {
                case Fillial.kaz:
                    {
                        using (var context = new KazContext())
                        {

                            DataClient.ItemsSource = null;
                            DataClient.ItemsSource = context.Client.ToList(); ;
                        }
                    }
                    break;
                case Fillial.che:
                    {
                        using (var context = new CheContext())
                        {

                            DataClient.ItemsSource = null;
                            DataClient.ItemsSource = context.Client.ToList(); ;
                        }
                    }
                    break;
                case Fillial.alm:
                    {
                        using (var context = new AlmContext())
                        {
                            DataClient.ItemsSource = null;
                            DataClient.ItemsSource = context.Client.ToList(); ;
                        }
                    }
                    break;
            }
            
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var client = DataClient.SelectedItem as Client;
            switch (MainWindow.fillial)
            {
                case Fillial.kaz:
                    {
                        using (var context = new KazContext())
                        {
                            context.Client.Remove(client);
                            context.SaveChanges();
                            DataClient.ItemsSource = null;
                            DataClient.ItemsSource = context.Client.ToList(); ;
                        }
                    }
                    break;
                case Fillial.che:
                    {
                        using (var context = new CheContext())
                        {
                            context.Client.Remove(client);
                            context.SaveChanges();
                            DataClient.ItemsSource = null;
                            DataClient.ItemsSource = context.Client.ToList(); ;
                        }
                    }
                    break;
                case Fillial.alm:
                    {
                        using (var context = new AlmContext())
                        {
                            context.Client.Remove(client);
                            context.SaveChanges();
                            DataClient.ItemsSource = null;
                            DataClient.ItemsSource = context.Client.ToList(); ;
                        }
                    }
                    break;
            }
        }
    }
}
