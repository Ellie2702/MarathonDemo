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
    /// Interaction logic for find_out_more_information.xaml
    /// </summary>
    public partial class find_out_more_information : Window
    {
        public find_out_more_information()
        {
            InitializeComponent();
        }

        private void LB0_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime date = new DateTime(2019, 11, 24, 06, 00, 00);
            TimeSpan delta = date - DateTime.Now;
            LB0.Content = delta.Days.ToString() + " дней " + delta.Hours.ToString() + " часов и " + delta.Minutes.ToString() + " минут"; 
        }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new CharityList().ShowDialog();
            this.Show();
        }

     

        private void BT5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
