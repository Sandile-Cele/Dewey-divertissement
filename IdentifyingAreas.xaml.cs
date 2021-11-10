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

        bool settingCallVsArea = true;//User setting for alternate between descriptions to call numbers and call numbers to descriptions.

        public Identifying_areas()
        {
            InitializeComponent();
        }

        private void btnMatch_Click(object sender, RoutedEventArgs e)
        {
            
            if(lbColumnA.SelectedIndex == -1 & lbColumnB.SelectedIndex == -1)
            {
                //If the user has not selected anything show this error!
                MessageBox.Show("Error", "Please choose form list box A and B.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //if (settingCallVsArea)
                //{
                //    columnMan.doCallVsAreaMatch();
                //}
                //else
                //{
                //    columnMan.doAreaVsCallsMatch();
                //}

                int selectedWord1 = Int32.Parse(lbColumnA.SelectedItem.ToString());
                string selectedWord2 = lbColumnB.SelectedItem.ToString();

                if (columnMan.DoTheyMatch(selectedWord1, selectedWord2))
                {
                    MessageBox.Show("Game done", "You are right!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    LifeMan.removeLife();
                    updateLives();
                    MessageBox.Show("Game done", "You are wrong!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            startGameCallsVsAreas(true);
        }

        //Load values to list boxes
        private void startGameCallsVsAreas(bool callVsArea)
        {
            lbColumnA.Items.Clear();
            lbColumnB.Items.Clear();

            LifeMan.reset();
            updateLives();

            Dictionary<int, string> tempRandomValues = columnMan.getRandomList();

            //If user is playing calls vs areas, then load calls in column a then areas in column b
            if (callVsArea)
            {

                for (int i = 0; i < tempRandomValues.Count; i++)
                {
                    if(i < 4)//Only load 4 items in column a
                    {
                        /*C# will change "000"(int) to "0" but it want to show "000".
                         * So if the call is 0 put "000" in list box
                         */
                        if (tempRandomValues.ElementAt(i).Key != 0)
                        {
                            lbColumnA.Items.Add(tempRandomValues.ElementAt(i).Key.ToString());
                        }
                        else
                        {
                            lbColumnA.Items.Add("000");
                        }
                    }

                    lbColumnB.Items.Add(tempRandomValues.ElementAt(i).Value);

                }

            }
            //Otherwise load areas in column a then calls in column b
            else
            {
                for (int i = 0; i < tempRandomValues.Count; i++)
                {

                    if (i < 4)//Only load 4 items in column a
                    {
                        lbColumnA.Items.Add(tempRandomValues.ElementAt(i).Value);
                    }

                    if (tempRandomValues.ElementAt(i).Key != 0)
                    {
                        lbColumnB.Items.Add(tempRandomValues.ElementAt(i).Key.ToString());
                    }
                    else
                    {
                        lbColumnB.Items.Add("000");
                    }

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

        private void btnCallsVsAreas_Click(object sender, RoutedEventArgs e)
        {
            if (settingCallVsArea)
            {
                btnCallsVsAreas.Content = "Areas vs calls";
                settingCallVsArea = false;
            }
            else
            {
                btnCallsVsAreas.Content = "Calls vs areas";
                settingCallVsArea = true;
            }
            startGameCallsVsAreas(settingCallVsArea);
        }

        private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            startGameCallsVsAreas(settingCallVsArea);
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            startGameCallsVsAreas(settingCallVsArea);
        }

        private void btnAchievements_Click(object sender, RoutedEventArgs e)
        {
            Achievements achievements = new();
            achievements.ShowDialog();
        }
    }
}
