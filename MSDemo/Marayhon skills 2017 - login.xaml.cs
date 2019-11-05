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
    /// Interaction logic for Marayhon_skills_2017___login.xaml
    /// </summary>
    public partial class Marayhon_skills_2017___login : Window
    {
        public Marayhon_skills_2017___login()
        {
            InitializeComponent();
        }

        private void BT0_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = new MarathonDemoDataSetTableAdapters.UserTableAdapter().GetData().Where(p => p.Email == TB0.Text && p.Password == TB1.Text).ElementAt(0);
                switch (data.RoleId)
                {
                    case "A":
                        break;

                    case "C":
                        break;

                    case "R":
                        break;
                }

            }
            catch
            {
                MessageBox.Show("Логин или пароль неправильные");
            }
        }


    }
}
