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
    /// Interaction logic for Achievements.xaml
    /// </summary>
    public partial class Achievements : Window
    {
        public Achievements()
        {
            InitializeComponent();

            unlock();
        }

        private void unlock()
        {
            for (int i = 0; i < 10; i++)
            {
                if(PointsMan.getPoints() >= 100)
                {
                    btn1.IsEnabled = true;
                }
                if (PointsMan.getPoints() >= 200)
                {
                    btn2.IsEnabled = true;
                }
                if (PointsMan.getPoints() >= 300)
                {
                    btn3.IsEnabled = true;
                }
                if (PointsMan.getPoints() >= 400)
                {
                    btn4.IsEnabled = true;
                }
                if (PointsMan.getPoints() >= 500)
                {
                    btn5.IsEnabled = true;
                }
                if (PointsMan.getPoints() >= 600)
                {
                    btn6.IsEnabled = true;
                }
                if (PointsMan.getPoints() >= 700)
                {
                    btn7.IsEnabled = true;
                }
                if (PointsMan.getPoints() >= 800)
                {
                    btn8.IsEnabled = true;
                }
                if (PointsMan.getPoints() >= 900)
                {
                    btn9.IsEnabled = true;
                }
            }
        }
    }
}
