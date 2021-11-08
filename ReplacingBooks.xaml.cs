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
    /// Interaction logic for ReplacingBooks.xaml
    /// </summary>
    public partial class ReplacingBooks : Window
    {
        TimeSpan bestTime = new TimeSpan();
        TimeSpan stopTime = new TimeSpan();

        public ReplacingBooks()
        {
            InitializeComponent();

            pbNextArchivement.Maximum = 900;
        }

        //This will send the user back to the main menu if they say yes
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to go back to the main menu?", "Close?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
#warning This is creating a new instance of main, find a way to reuse the hidden main
                MainWindow main = new MainWindow();
                main.Show();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            populateLbNewCalls();
        }

        //When the user click on the lb I will enable or disable
        private void lbCalls_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbCalls.SelectedIndex != 1)
            {
                lbCalls.Items.Remove(lbCalls.SelectedItem);
            }
        }

        private void btnNewCalls_Click(object sender, RoutedEventArgs e)
        {
            if (timerRunning)
            {
                stop();
            }

            if(lbCalls.Items.Count > 1)
            {
                lbCalls.Items.Clear();
            }
            populateLbNewCalls();
        }

        private void lbCallsRandom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbCallsRandom.SelectedIndex != -1)
            {
                if (!timerRunning)
                {
                    startTime();
                }

                //Check if the user list have 10 items or less
                if (lbCalls.Items.Count < 10)
                {
                    lbCalls.Items.Add(lbCallsRandom.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("You now have 10 items, Click 'Done' to check answer.", "Max reached");
                }
            }

        }

        //Clear user list
        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            lbCalls.Items.Clear();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            //Check if the user selected 10 items
            if (lbCalls.Items.Count == 10)
            {
                TimeSpan userFinishTime = stop();

                //I'm converting the users list box details to a list
                List<string> userList = lbCalls.Items.Cast<string>().ToList();



                //Comparing the users list and the sorted list
                if (Enumerable.SequenceEqual(CallList.getSortedString(), userList))
                {
                    //The faster the player finishes the more points
                    if (userFinishTime <= new TimeSpan(0, 0, 2, 0))
                    {
                        MessageBox.Show("well done you have own gold", "Done");
                        PointsMan.addPoints(10);
                    }
                    else if (userFinishTime <= new TimeSpan(0, 0, 5, 0))
                    {
                        MessageBox.Show("well done you have own sliver\nTry to get gold next time.", "Done");
                        PointsMan.addPoints(5);
                    }
                    else if (userFinishTime <= new TimeSpan(0, 0, 10, 0))
                    {
                        MessageBox.Show("well done you have own bronze\nTry to get sliver next time.", "Done");
                        PointsMan.addPoints(2);
                    }
                    else
                    {
                        MessageBox.Show("well done you have own.\nTry to beat the game in at least 10 minutes to win bronze.", "Done");

                    }

                    progressBarUpdate();

                    lbPt.Content = PointsMan.getPoints();
                    lbCalls.Items.Clear();

                    populateLbNewCalls();

                }
                else
                {
                    MessageBox.Show("Wrong, try again", "Done");

                    lbCalls.Items.Clear();//Clear user list
                    populateLbNewCalls();//RePopulate list to order
                }

            }
            else//If players items are less then 10
            {
                MessageBox.Show("Fill the list with 10 call numbers", "Not finished");

            }
        }

        private void lbCallsRandom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //populate the list with new calls
        private void populateLbNewCalls()
        {
            CallList.generateCalls();

            //If the list is not empty then clear it
            if (lbCallsRandom.Items.Count != 0)
            {
                lbCallsRandom.Items.Clear();
            }

            foreach (var item in CallList.callList)
            {
                lbCallsRandom.Items.Add(item.ToString());
            }
        }

#warning remove this button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in CallList.getSortedString())
            {
                lbCalls.Items.Add(item);
            }

            //Check if the user selected 10 items
            if (lbCalls.Items.Count == 10)
            {
                TimeSpan userFinishTime = stop();

                //I'm converting the users list box details to a list
                List<string> userList = lbCalls.Items.Cast<string>().ToList();



                //Comparing the users list and the sorted list
                if (Enumerable.SequenceEqual(CallList.getSortedString(), userList))
                {
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

                    progressBarUpdate();

                    lbPt.Content = PointsMan.getPoints();
                    lbCalls.Items.Clear();

                    populateLbNewCalls();

                }
                else
                {
                    MessageBox.Show("Wrong, try again", "Done");

                    lbCalls.Items.Clear();//Clear user list
                    populateLbNewCalls();//RePopulate list to order
                }

            }
            else//If players items are less then 10
            {
                MessageBox.Show("Fill the list with 10 call numbers", "Not finished");

            }

        }

        private void progressBarUpdate()
        {
            pbNextArchivement.Value = PointsMan.getPointPercent();
        }



        private void messageForUser()
        {
            if (bestTime.Ticks.Equals(0))//There is no current best time
            {
                bestTime = userTime;
                MessageBox.Show("Correct! this is your new best time! \nTime: " + bestTime.ToString(@"mm\:ss"));
            }
            else//There is a current best time
            {
                int stopTimeBestDiff = stopTime.CompareTo(bestTime.Seconds);

                if (stopTimeBestDiff < 0)//The user best the best time
                {
                    MessageBox.Show("Yay! you beat your old best time of " +
                        bestTime.ToString(@"mm\:ss") +
                        "\nThis is now your new best time: " + stopTime.ToString(@"mm\:ss"));
                    bestTime = stopTime;//Now set the new best time

                }
                else//Failed to beat the best time
                {
                    MessageBox.Show("Nice! \nYou finished in " +
                        stopTime.ToString(@"mm\:ss") +
                        "\nTry to beat your best time of " +
                        bestTime.ToString(@"mm\:ss"));
                }

            }
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

        public void reset()
        {
            userTime = new TimeSpan(0, 0, 0, 0);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (timerRunning)
            {
                userTime += dispatcherTimer.Interval;
                lbTime.Content = userTime.ToString();
            }
        }

        private void btnAchievements_Click(object sender, RoutedEventArgs e)
        {
            Achievements achievements = new();
            achievements.ShowDialog();
        }
    }
}
