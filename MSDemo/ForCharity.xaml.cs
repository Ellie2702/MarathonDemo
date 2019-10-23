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
using System.IO;


namespace MSDemo
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void setup(string img, string s1, string s2)
        {
            try 
            {
                CharityName.Content = s1;
                Discript.Content = s2;
                image1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(File.ReadAllBytes("C:\\Users\\Ellie\\Desktop\\4 курс\\Подготовка к демо\\task-01\\MSDemo\\charityLogo\\" + img));

            }
            catch
            {
                CharityName.Content = s1;
                Discript.Content = s2;
            }
        }

       
    }
}
