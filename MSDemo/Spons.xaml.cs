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
    /// Interaction logic for Spons.xaml
    /// </summary>
    public partial class Spons : Window
    {
        public Spons()
        {
            InitializeComponent();
        }

        private void Label_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime date = new DateTime(2019, 11, 24, 06, 00, 00);
            TimeSpan delta = date - DateTime.Now;
            LB0.Content = delta.Days.ToString() + " дней " + delta.Hours.ToString() + " часов и " + delta.Minutes.ToString() + " минут"; 
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                RunName.ItemsSource = new MarathonDemoDataSetTableAdapters.User1TableAdapter().GetData();
                RunName.DisplayMemberPath = "Name";
                RunName.SelectedValuePath = "mail";
            }
            catch(Exception ex)
            {
                //MessageBox.Show("You are shaitan, you broke all of it");
                MessageBox.Show(ex.Message);
            }
        }
         
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TB6.Text = (Convert.ToInt32(TB6.Text) + 10).ToString();
                Mon.Content = "$" + TB6.Text;
            }
            catch
            {
                MessageBox.Show("Что-то не так");
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(TB6.Text) >= 10)
                {
                    TB6.Text = (Convert.ToInt32(TB6.Text) - 10).ToString();
                    Mon.Content = "$" + TB6.Text;
                }
                else
                {
                    MessageBox.Show("Вы не можете пожертвовать минусовую сумму!");
                }
            }
            catch
            {
                MessageBox.Show("Что-то не так");
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = SponsName.Text;
                string run = RunName.SelectedValue.ToString();
                RunFond.RunName = RunName.Text;
              
            
                string card = Map.Text;
                string num = Number.Text;
                int mm = Convert.ToInt32(MM.Text);
                int yy = Convert.ToInt32(YY.Text);
                int cvc = Convert.ToInt32(CVC.Text);
                int sum = Convert.ToInt32(TB6.Text);
                RunFond.coast = sum;
                DateTime delta = DateTime.Now;
                if (delta.Month >= mm && delta.Year >= yy)
                {
                    MessageBox.Show("Срок действия вашей карты истёк!");
                }
                else
                {
                    var data = new MarathonDemoDataSetTableAdapters.RunnerTableAdapter().GetData().Where(p => p.Email == run).ElementAt(0);
                    int runID = data.RunnerId;
                    var data1 = new MarathonDemoDataSetTableAdapters.RegistrationTableAdapter().GetData().Where(p => p.RunnerId == runID).ElementAt(0);
                    int regID = data1.RegistrationId;

                    int OrgID = data1.CharityId;
                    var data2 = new MarathonDemoDataSetTableAdapters.CharityTableAdapter().GetData().Where(p => p.CharityId == OrgID).ElementAt(0);
                    RunFond.Org = data2.CharityName;


                    new MarathonDemoDataSetTableAdapters.SponsorshipTableAdapter().Insert(name, regID, sum);
                    new MarathonDemoDataSetTableAdapters.RegistrationTableAdapter().UpdateQuery(sum, runID);

                    new Marathon_Skills_2019___charity().ShowDialog();
                   
                    
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TB6_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Mon.Content = "$" + TB6.Text;
                if (Convert.ToInt32(TB6.Text) < 0)
                {
                    MessageBox.Show("Жулик, не воруй!");
                    TB6.Text = (-1 * Convert.ToInt32(TB6.Text)).ToString();
                    Mon.Content = "$" + TB6.Text;
                }
                else if (Convert.ToInt32(TB6.Text) == 0)
                {
                    TB6.Text = 1.ToString();
                    Mon.Content = "$" + TB6.Text;
                }
              
            }
            catch
            {
                MessageBox.Show("Шота ни так как нада! Переделывай, говна!");
            }
        }

       
        private void RunName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string run = RunName.SelectedValue.ToString();
            var data = new MarathonDemoDataSetTableAdapters.RunnerTableAdapter().GetData().Where(p => p.Email == run).ElementAt(0);
            int runID = data.RunnerId;
            var data1 = new MarathonDemoDataSetTableAdapters.RegistrationTableAdapter().GetData().Where(p => p.RunnerId == runID).ElementAt(0);
            int regID = data1.RegistrationId;

            int OrgID = data1.CharityId;
            var data2 = new MarathonDemoDataSetTableAdapters.CharityTableAdapter().GetData().Where(p => p.CharityId == OrgID).ElementAt(0);
            Fond.Content = data2.CharityName;
            RunFond.Org = data2.CharityName;
        }

        private void Charity_Click(object sender, RoutedEventArgs e)
        {
            new CharityShow().ShowDialog();
        }

       
    }
}
