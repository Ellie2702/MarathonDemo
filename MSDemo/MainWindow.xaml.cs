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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BT4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Label_Loaded(object sender, RoutedEventArgs e)
        {
         

            DateTime date = new DateTime(2019, 11, 24, 06, 00, 00);
            TimeSpan delta = date - DateTime.Now;
            LB0.Content = delta.Days.ToString() + " дней " + delta.Hours.ToString() + " часов и " + delta.Minutes.ToString() + " минут"; 
        }
    }
}
