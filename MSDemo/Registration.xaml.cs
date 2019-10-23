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
using System.Text.RegularExpressions;

namespace MSDemo
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Pass.Text == RePass.Text)
                {
                    if (Regex.IsMatch(Pass.Text, "(?.=A-Z)(?.=a-z)(?.=0-9)(?.=!@#$%^)(A-Za-z0-9!@#$%^){8,})"))
                    {
                        new MarathonDemoDataSetTableAdapters.UserTableAdapter().Insert(Mail.Text, Pass.Text, Name.Text, LasTName.Text, "R");
                        new MarathonDemoDataSetTableAdapters.RunnerTableAdapter().Insert(Mail.Text, Gender.SelectedItem.ToString(), dateOfB.SelectedDate, Country.SelectedValuePath);


                    }
                    else
                    {
                        MessageBox.Show("Пароль не соответствует требованиям безопастности. Он должен: состоять не менее 8 символов, заглавные и строчные буквы, цифры и спец.символы - !@#$%^");
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают, повторите попытку");
                }
            }
            catch
            {

            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Gender.ItemsSource = new MarathonDemoDataSetTableAdapters.GenderTableAdapter().GetData();
            Gender.DisplayMemberPath = "Gender";
            Gender.SelectedValuePath = "Gender";

            Country.ItemsSource = new MarathonDemoDataSetTableAdapters.CountryTableAdapter().GetData();
            Country.DisplayMemberPath = "CountryName";
            Country.SelectedValuePath = "CountryCode";
        }

        
    }
}
