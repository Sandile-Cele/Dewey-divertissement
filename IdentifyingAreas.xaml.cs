using Dewey_divertissement.Class;
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
using System.Windows.Shapes;

namespace Dewey_divertissement
{
    /// <summary>
    /// Interaction logic for Identifying_areas.xaml
    /// </summary>
    public partial class Identifying_areas : Window
    {
        ColumnMan columnMan = new();

        public Identifying_areas()
        {
            InitializeComponent();
        }

        private void btnMatch_Click(object sender, RoutedEventArgs e)
        {
            int selectedWord1 = Int32.Parse(lbColumnA.SelectedItem.ToString());
            string selectedWord2 = lbColumnB.SelectedItem.ToString();

            if (columnMan.DoTheyMatch(selectedWord1, selectedWord2))
            {
                MessageBox.Show("You are right 👍");
            }
            else
            {
                LifeMan.removeLife();
                updateLives();
                MessageBox.Show("You are wrong 👎");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in ColumnMan.columnList)
            {
                //Adding to column B
                lbColumnB.Items.Add(item.Value);

                //c# converting 000 to 0, i need to show the user "000"
                if (item.Key.Equals(0))
                {
                    lbColumnA.Items.Add("000");
                }
                else
                {
                    lbColumnA.Items.Add(item.Key.ToString());
                }

            }
        }

        private void updateLives()
        {
            if (LifeMan.getLives().Length.Equals(0))
            {
                //reset game
            }
            else
            {
                lbLives.Content = "Lives: " + LifeMan.getLives();
            }

        }
    }
}
