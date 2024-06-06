using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace UIFunction.Function.WorkItem
{
    /// <summary>
    /// Interaction logic for PCShutdown.xaml
    /// </summary>
    /// 

    // Reference: https://www.codeproject.com/Tips/480049/Shut-Down-Restart-Log-off-Lock-Hibernate-or-Sleep
    public partial class PCShutdown : UserControl
    {
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public PCShutdown()
        {
            InitializeComponent();
        }

        private void btnSleep_Click(object sender, RoutedEventArgs e)
        {
            SetSuspendState(true, true, true);
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");
            // starts the shutdown application 
            // the argument /s is to shut down the computer
            // the argument /t 0 is to tell the process that 
            // the specified operation needs to be completed 
            // after 0 seconds
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("shutdown", "/r /t 0"); // the argument /r is to restart the computer
        }
    }
}
