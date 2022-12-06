using ClassLibrary;
using GlebKurs.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlebKurs.View
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        public Orders()
        {
            InitializeComponent();
            switch (MainWindow.fillial)
            {
                case Fillial.kaz:
                    {
                        using (var context = new KazContext())
                        {

                            OrdersData.ItemsSource = null;
                            OrdersData.ItemsSource = context.Order.ToList();
                            ComboClient.ItemsSource = context.Client.ToList();
                            ComboClient.DisplayMemberPath = "FirstName";
                            ComboClient.SelectedValuePath = "Id";

                            ComboManager.ItemsSource = context.Manager.ToList();
                            ComboManager.DisplayMemberPath = "Name";
                            ComboManager.SelectedValuePath = "Id";

                            ComboService.ItemsSource = context.Service.ToList();
                            ComboService.DisplayMemberPath = "Name";
                            ComboService.SelectedValuePath = "Id";
                        }
                    }
                    break;
                case Fillial.che:
                    {
                        using (var context = new CheContext())
                        {

                            OrdersData.ItemsSource = null;
                            OrdersData.ItemsSource = context.Order.ToList();
                            ComboClient.ItemsSource = context.Client.ToList();
                            ComboClient.DisplayMemberPath = "FirstName";
                            ComboClient.SelectedValuePath = "Id";

                            ComboManager.ItemsSource = context.Manager.ToList();
                            ComboManager.DisplayMemberPath = "Name";
                            ComboManager.SelectedValuePath = "Id";

                            ComboService.ItemsSource = context.Service.ToList();
                            ComboService.DisplayMemberPath = "Name";
                            ComboService.SelectedValuePath = "Id";
                        }
                    }
                    break;
                case Fillial.alm:
                    {
                        using (var context = new AlmContext())
                        {
                            OrdersData.ItemsSource = null;
                            OrdersData.ItemsSource = context.Order.ToList();
                            ComboClient.ItemsSource = context.Client.ToList();
                            ComboClient.DisplayMemberPath = "FirstName";
                            ComboClient.SelectedValuePath = "Id";

                            ComboManager.ItemsSource = context.Manager.ToList();
                            ComboManager.DisplayMemberPath = "Name";
                            ComboManager.SelectedValuePath = "Id";

                            ComboService.ItemsSource = context.Service.ToList();
                            ComboService.DisplayMemberPath = "Name";
                            ComboService.SelectedValuePath = "Id";
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

                            OrdersData.ItemsSource = null;
                            OrdersData.ItemsSource = context.Order.ToList();
                            ComboClient.ItemsSource = context.Client.ToList();
                            ComboClient.DisplayMemberPath = "FirstName";
                            ComboClient.SelectedValuePath = "Id";

                            ComboManager.ItemsSource = context.Manager.ToList();
                            ComboManager.DisplayMemberPath = "Name";
                            ComboManager.SelectedValuePath = "Id";

                            ComboService.ItemsSource = context.Service.ToList();
                            ComboService.DisplayMemberPath = "Name";
                            ComboService.SelectedValuePath = "Id";

                            


                        }
                    }
                    break;
                case Fillial.che:
                    {
                        using (var context = new CheContext())
                        {

                            OrdersData.ItemsSource = null;
                            OrdersData.ItemsSource = context.Order.ToList();
                            ComboClient.ItemsSource = context.Client.ToList();
                            ComboClient.DisplayMemberPath = "FirstName";
                            ComboClient.SelectedValuePath = "Id";

                            ComboManager.ItemsSource = context.Manager.ToList();
                            ComboManager.DisplayMemberPath = "Name";
                            ComboManager.SelectedValuePath = "Id";

                            ComboService.ItemsSource = context.Service.ToList();
                            ComboService.DisplayMemberPath = "Name";
                            ComboService.SelectedValuePath = "Id";
                        }
                    }
                    break;
                case Fillial.alm:
                    {
                        using (var context = new AlmContext())
                        {
                            OrdersData.ItemsSource = null;
                            OrdersData.ItemsSource = context.Order.ToList();
                            ComboClient.ItemsSource = context.Client.ToList();
                            ComboClient.DisplayMemberPath = "FirstName";
                            ComboClient.SelectedValuePath = "Id";

                            ComboManager.ItemsSource = context.Manager.ToList();
                            ComboManager.DisplayMemberPath = "Name";
                            ComboManager.SelectedValuePath = "Id";

                            ComboService.ItemsSource = context.Service.ToList();
                            ComboService.DisplayMemberPath = "Name";
                            ComboService.SelectedValuePath = "Id";
                        }
                    }
                    break;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var paytype = (ComboBoxItem)ComboPayType.SelectedItem;
            var SelectedClient = ComboClient.SelectedItem as Client;
            var selectedManager = ComboManager.SelectedItem as Manager;
            var order = new Order()
            {
                ClientId = SelectedClient.Id,
                ManagerId = selectedManager.Id,
                Services = new List<Service> { ComboService.SelectedItem as Service },
                PayType = Enum.Parse<PayType>(paytype.Content.ToString())
            };
            switch (MainWindow.fillial)
            {
                case Fillial.kaz:
                    {
                        using (var context = new KazContext())
                        {

                            OrdersData.ItemsSource = null;
                            OrdersData.ItemsSource = context.Order.ToList();
                            context.Order.Add(order);
                            context.SaveChanges();


                        }
                    }
                    break;
                case Fillial.che:
                    {
                        using (var context = new CheContext())
                        {

                            OrdersData.ItemsSource = null;
                            OrdersData.ItemsSource = context.Order.ToList();
                            context.Order.Add(order);
                            context.SaveChanges();
                        }
                    }
                    break;
                case Fillial.alm:
                    {
                        using (var context = new AlmContext())
                        {
                            OrdersData.ItemsSource = null;
                            OrdersData.ItemsSource = context.Order.ToList();
                            context.Order.Add(order);
                            context.SaveChanges();
                        }        
                        
                    }
                    break;
            }
        }
    }
}
