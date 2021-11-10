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
using System.Windows.Threading;

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

            pbNextArchivement.Maximum = 900;
        }

        private void btnMatch_Click(object sender, RoutedEventArgs e)
        {
            
            if(lbColumnA.SelectedIndex == -1 | lbColumnB.SelectedIndex == -1)
            {
                //If the user has not selected anything show this error!
                MessageBox.Show( "Please choose form list box A and B.", "Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Checking what the user has selected.
                string selectedCall1 = lbColumnA.SelectedItem.ToString();
                string selectedCall2 = lbColumnB.SelectedItem.ToString();

                if (settingCallVsArea)
                {
                    //Call vs area
                    int tempSelectedCall1 = Int32.Parse(selectedCall1);
                    if (columnMan.DoTheyMatch(tempSelectedCall1, selectedCall2))
                    {
                        theyDoMatch();
                    }
                    else
                    {
                        theyDoNotMatch();
                    }

                }
                else
                {
                    //Area vs call
                    if(columnMan.DoTheyMatch(Int32.Parse(selectedCall2), selectedCall1))
                    {
                        theyDoMatch();
                    }
                    else
                    {
                        theyDoNotMatch();
                    }
                }
            }

        }

        //Checking if the selected, match together
        private void theyDoMatch()
        {
            if(lbColumnA.SelectedIndex != -1)
            {
                lbColumnA.Items.RemoveAt(lbColumnA.SelectedIndex);

            }

            if (lbColumnA.Items.Count == 0)
            {
                endGame();
                progressBarUpdate();

                //Then show the message to the user
                lbMessageRight.Visibility = Visibility.Hidden;
                lbMessageWrong.Visibility = Visibility.Hidden;
            }

            //Then show the message to the user
            lbMessageRight.Visibility = Visibility.Visible;
            lbMessageWrong.Visibility = Visibility.Hidden;
        }

        //Checking if the selected, match together

        private void theyDoNotMatch()
        {
            MessageBox.Show("Wrong!", "Answer", MessageBoxButton.OK, MessageBoxImage.Error);

            lbMessageRight.Visibility = Visibility.Hidden;
            lbMessageWrong.Visibility = Visibility.Visible;

            if (!LifeMan.removeLife())
            {
                startGameCallsVsAreas(settingCallVsArea);
            }

            updateLives();
        }

        //Run this logic when the game ends
        private void endGame()
        {
            progressBarUpdate();

            TimeSpan userFinishTime = stop();

            //The faster the player finishes the more points
            if (userFinishTime <= new TimeSpan(0, 0, 2, 0))
            {
                //messageForUser();
                MessageBox.Show("well done you have own gold", "Done");
                PointsMan.addPoints(10);
            }
            else if (userFinishTime <= new TimeSpan(0, 0, 5, 0))
            {
                //messageForUser();
                MessageBox.Show("well done you have own sliver\nTry to get gold next time.", "Done");
                PointsMan.addPoints(5);
            }
            else if (userFinishTime <= new TimeSpan(0, 0, 10, 0))
            {
                //messageForUser();
                MessageBox.Show("well done you have own bronze\nTry to get sliver next time.", "Done");
                PointsMan.addPoints(2);
            }
            else
            {
                MessageBox.Show("well done you have own.\nTry to beat the game in at least 10 minutes to win bronze.", "Done");

            }

            startGameCallsVsAreas(settingCallVsArea);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            progressBarUpdate();
            startGameCallsVsAreas(true);
        }

        //Load values to list boxes
        private void startGameCallsVsAreas(bool callVsArea)
        {
            if (timerRunning)
            {
                stop();
            }

            startTime();

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
                         * So if the call is 0 put "000" in list box*/
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
            lbMessageRight.Visibility = Visibility.Hidden;
            lbMessageWrong.Visibility = Visibility.Hidden;
            startGameCallsVsAreas(settingCallVsArea);
        }

        private void btnAchievements_Click(object sender, RoutedEventArgs e)
        {
            Achievements achievements = new();
            achievements.ShowDialog();
        }

        private void progressBarUpdate()
        {
            lbPt.Content = PointsMan.getPointPercent() + " / 900";
            pbNextArchivement.Value = PointsMan.getPointPercent();
        }

        private void btnLifeInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("When the game starts you get 3 lives.\n" +
                "Every time you get a 'match' wrong you lose a life.\n" +
                "This is to encourage you not to Spam click", 
                "Information",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
























        //Timer section
#warning Put in own class
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private TimeSpan userTime = new TimeSpan(0, 0, 0, 0);

        bool timerRunning = false;


        private void startTime()
        {
            //If the timer is running already, stop it
            if (timerRunning)
            {
                dispatcherTimer.Stop();
            }

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

            timerRunning = true;
            #warning This is why its counting in 2s
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        //Stop timer and return the current time
        private TimeSpan stop()
        {
            stopTime = dispatcherTimer.Interval;

            lbTime.Content = "00:00:00";

            userTime = new TimeSpan();

            dispatcherTimer.Stop();

            timerRunning = false;

            return userTime;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (timerRunning)
            {


                userTime += dispatcherTimer.Interval;
                //userTime += new TimeSpan(0, 0, 1);
                lbTime.Content = userTime.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            startGameCallsVsAreas(settingCallVsArea);
        }

 
    }
}
