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
    /// Логика взаимодействия для Managers.xaml
    /// </summary>
    public partial class Managers : UserControl
    {
        public Managers()
        {
            InitializeComponent();
            switch (MainWindow.fillial)
            {
                case Fillial.kaz:
                    {
                        using (var context = new KazContext())
                        {

                            MangerData.ItemsSource = null;
                            MangerData.ItemsSource = context.Manager.ToList(); ;
                        }
                    }
                    break;
                case Fillial.che:
                    {
                        using (var context = new CheContext())
                        {

                            MangerData.ItemsSource = null;
                            MangerData.ItemsSource = context.Manager.ToList(); ;
                        }
                    }
                    break;
                case Fillial.alm:
                    {
                        using (var context = new AlmContext())
                        {
                            MangerData.ItemsSource = null;
                            MangerData.ItemsSource = context.Manager.ToList(); ;
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

                            MangerData.ItemsSource = null;
                            MangerData.ItemsSource = context.Manager.ToList(); ;
                        }
                    }
                    break;
                case Fillial.che:
                    {
                        using (var context = new CheContext())
                        {

                            MangerData.ItemsSource = null;
                            MangerData.ItemsSource = context.Manager.ToList(); ;
                        }
                    }
                    break;
                case Fillial.alm:
                    {
                        using (var context = new AlmContext())
                        {
                            MangerData.ItemsSource = null;
                            MangerData.ItemsSource = context.Manager.ToList(); ;
                        }
                    }
                    break;
            }
        }
    }
}
