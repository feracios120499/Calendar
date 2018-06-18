using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public class Week
        {
            public string Monday { get; set; }
            public string Tuesday { get; set; }
            public string Wednesday { get; set; }
            public string Thursday { get; set; }
            public string Friday { get; set; }
            public string Saturday { get; set; }
            public string Sunday { get; set; }
        }
        
        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            List<Week> weeks = new List<Week>();
            try
            {
                DateTime first = new DateTime(DateTime.Now.Year, Convert.ToInt32((treeView.SelectedItem as TreeViewItem).Tag), 1);
                int numberMonth = 1;
                if(Convert.ToInt32((treeView.SelectedItem as TreeViewItem).Tag) != 12)
                {
                    numberMonth = Convert.ToInt32((treeView.SelectedItem as TreeViewItem).Tag);
                }
                DateTime last = new DateTime(DateTime.Now.Year, numberMonth + 1, 1).AddDays(-1);
                int numberDay = ((int)first.DayOfWeek == 0) ? 7 : (int)first.DayOfWeek;
                weeks.Add(new Week());
                for(int i = 1; i < numberDay; i++)
                {
                    switch (i)
                    {
                        case 1:
                            weeks.First().Monday = "";
                            break;
                        case 2:
                            weeks.First().Tuesday = "";
                            break;
                        case 3:
                            weeks.First().Wednesday = "";
                            break;
                        case 4:
                            weeks.First().Thursday = "";
                            break;
                        case 5:
                            weeks.First().Friday = "";
                            break;
                        case 6:
                            weeks.First().Saturday = "";
                            break;
                    }    
                }
                for(int i = numberDay; i <= 7; i++)
                {
                    switch (i)
                    {
                        case 1:
                            weeks.First().Monday = first.Day.ToString();
                            break;
                        case 2:
                            weeks.First().Tuesday = first.Day.ToString();
                            break;
                        case 3:
                            weeks.First().Wednesday = first.Day.ToString();
                            break;
                        case 4:
                            weeks.First().Thursday = first.Day.ToString();
                            break;
                        case 5:
                            weeks.First().Friday = first.Day.ToString();
                            break;
                        case 6:
                            weeks.First().Saturday = first.Day.ToString();
                            break;
                        case 7:
                            weeks.First().Sunday = first.Day.ToString();
                            break;
                    }
                    first = first.AddDays(1);
                }
                numberDay = 1;
                while (first.Day != last.AddDays(1).Day)
                {
                    if (numberDay == 1)
                    {
                        weeks.Add(new Week());
                    }
                    switch (numberDay)
                    {
                        case 1:
                            weeks.Last().Monday = first.Day.ToString();
                            break;
                        case 2:
                            weeks.Last().Tuesday = first.Day.ToString();
                            break;
                        case 3:
                            weeks.Last().Wednesday = first.Day.ToString();
                            break;
                        case 4:
                            weeks.Last().Thursday = first.Day.ToString();
                            break;
                        case 5:
                            weeks.Last().Friday = first.Day.ToString();
                            break;
                        case 6:
                            weeks.Last().Saturday = first.Day.ToString();
                            break;
                        case 7:
                            weeks.Last().Sunday = first.Day.ToString();
                            break;
                    }
                    first = first.AddDays(1);
                    numberDay++;
                    if (numberDay == 8)
                    {
                        numberDay = 1;
                    }
                }
                listView.ItemsSource = weeks;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
