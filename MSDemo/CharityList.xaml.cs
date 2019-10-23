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
    /// Interaction logic for CharityList.xaml
    /// </summary>
    public partial class CharityList : Window
    {
        public CharityList()
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

        }
        
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
        /*    var data = new MarathonDemoDataSetTableAdapters.CharityTableAdapter().GetData();
            UserControl1[] UC = new UserControl1[data.Rows.Count];
             
            for (int i = 0; i < UC.Length; i++)
            {
                var data1 = new MarathonDemoDataSetTableAdapters.CharityTableAdapter().GetData().ElementAt(i);
                UC[i] = new UserControl1();
                UC[i].setup(data1.CharityLogo, data1.CharityName, data1.CharityDescription);
                if (i == 0)
                {
                    UC[i].Margin.Top = 
                    UC[i].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    UC[i].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                }
                else
                {
                    
                }
                

            }
            */
            var data = new MarathonDemoDataSetTableAdapters.CharityTableAdapter().GetData();
            int n = data.Count;

            ST.HorizontalAlignment = HorizontalAlignment.Center;
            

            StackPanel[] panels = new StackPanel[n];
            StackPanel[] innerPanels = new StackPanel[n];
            
            Label[] Names = new Label[n];
            Image[] Logos = new Image[n];
            TextBlock[] Discript = new TextBlock[n];
            for (int i = 0; i < n; i++)
            {
                panels[i] = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                innerPanels[i] = new StackPanel
                {
                    Orientation = Orientation.Vertical
                };

                

                Names[i] = new Label
                {
                    Margin = new Thickness(15),
                    Content = data.ElementAt(i).CharityName,
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };

                innerPanels[i].Children.Add(Names[i]);

                Logos[i] = new Image
                {
                    Stretch = Stretch.Uniform,
                    Width = 64,
                    Height = 64,
                    Margin = new Thickness(15)
                };
                Logos[i].Source = (ImageSource)new ImageSourceConverter().ConvertFrom(File.ReadAllBytes("C:\\Users\\Ellie\\Desktop\\4 курс\\Подготовка к демо\\task-01\\MSDemo\\charityLogo\\" + data.ElementAt(i).CharityLogo));



                Discript[i] = new TextBlock
                {
                    Margin = new Thickness(15),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontSize = 20,
                    VerticalAlignment = VerticalAlignment.Center,
                    Text = data.ElementAt(i).CharityDescription,
                    TextWrapping = TextWrapping.Wrap
                };
                innerPanels[i].Children.Add(Discript[i]);
                
                panels[i].Children.Add(Logos[i]);
                panels[i].Children.Add(innerPanels[i]);
                
                ST.Children.Add(panels[i]);
            }
                    
        }
    }
}
