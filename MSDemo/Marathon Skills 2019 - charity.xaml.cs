using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MSDemo
{
    /// <summary>
    /// Interaction logic for Marathon_Skills_2019___charity.xaml
    /// </summary>
    public partial class Marathon_Skills_2019___charity : Window
    {
        public Marathon_Skills_2019___charity()
        {
            InitializeComponent();
        }

        private void LB0_Loaded(object sender, RoutedEventArgs e)
        {

            DateTime date = new DateTime(2019, 11, 24, 06, 00, 00);
            TimeSpan delta = date - DateTime.Now;
            LB0.Content = delta.Days.ToString() + " дней " + delta.Hours.ToString() + " часов и " + delta.Minutes.ToString() + " минут"; 


        }

        private void BT0_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().ShowDialog();
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            RunName.Content = RunFond.RunName;
            Org.Content = RunFond.Org;
            Coas.Content = RunFond.coast;
        }

       
    }
}
