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
using System.IO;

namespace MSDemo
{
    /// <summary>
    /// Interaction logic for CharityShow.xaml
    /// </summary>
    public partial class CharityShow : Window
    {
        public CharityShow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                FondName.Content = RunFond.Org;
                var charityData = new MarathonDemoDataSetTableAdapters.CharityTableAdapter().GetData().Where(p => p.CharityName == RunFond.Org).ElementAt(0);
                FondLogo.Source = (ImageSource) new ImageSourceConverter().ConvertFrom(File.ReadAllBytes("C:\\Users\\Ellie\\Desktop\\4 курс\\Подготовка к демо\\task-01\\MSDemo\\charityLogo\\" + charityData.CharityLogo));
                Discript.Content = charityData.CharityDescription;
            }
            catch { }

        }
    }
}
