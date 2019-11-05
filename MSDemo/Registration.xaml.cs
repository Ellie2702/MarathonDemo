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
using System.Globalization;
using Microsoft.Win32;
using System.IO;

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

        byte[] arr;

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Pass.Text == RePass.Text)
                {
                    if (Regex.IsMatch(Pass.Text, "^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^])([A-Za-z0-9!@#$%^]){8,}$"))
                    {

                        new MarathonDemoDataSetTableAdapters.UserTableAdapter().Insert(Mail.Text, Pass.Text, Name.Text, LasTName.Text, "R");
                        if (Source.Text == null)
                        {
                            new MarathonDemoDataSetTableAdapters.RunnerTableAdapter().InsertQuery(Mail.Text, Gender.Text, (DateTime)dateBD.SelectedDate, Country.SelectedValue.ToString());
                        }
                        else
                        {
                            new MarathonDemoDataSetTableAdapters.RunnerTableAdapter().Insert(Mail.Text, Gender.Text, (DateTime)dateBD.SelectedDate, Country.SelectedValue.ToString(), Source.Text);
                        }
                        MessageBox.Show("Выполнено! Для входа авторизируйтесь.");
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
               
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

        
        private void SelImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Image files(*.BMP;*.JPG;*.PNG|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            if (d.ShowDialog() == true)
            {
                arr = File.ReadAllBytes(d.FileName);
                Photo.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(arr);
                Source.Text = d.FileName;
            }
        }

        
    }
}
