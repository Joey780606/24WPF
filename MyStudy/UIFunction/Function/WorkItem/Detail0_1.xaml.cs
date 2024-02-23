using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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

/*
 * Author: Joey
 * Important:
 *  1. System.Management 這個需要用Nuget安裝
 * 
 * Reference:
 *  1. https://www.youtube.com/watch?v=taa5VN-9iyg
 *  2. https://stackoverflow.com/questions/17832969/c-constantly-monitor-battery-level //Delegate的用法
 */
namespace UIFunction.Function.WorkItem
{
    /// <summary>
    /// Interaction logic for Detail0_1.xaml
    /// </summary>
    
    public partial class Detail0_1 : UserControl
    {
        public delegate void DoAsync();
        public Detail0_1()
        {
            InitializeComponent();
        }

        private void btnBattery_Click(object sender, RoutedEventArgs e)
        {
            GetBatteryDetails();
            //DoAsync async = new DoAsync(GetBatteryDetails);
            //async.BeginInvoke(null, null);
        }

        public void GetBatteryDetails()
        {
            /*
            int i = 0;

            PowerStatus ps = System.Windows.Forms.SystemInformation.PowerStatus;
            while (true)
            {
                if (this.InvokeRequired)
                    this.Invoke(new Action(() => this.Text = ps.BatteryLifePercent.ToString() + i.ToString()));
                else
                    this.Text = ps.BatteryLifePercent.ToString() + i.ToString();

                i++;
            }
            */
            System.Management.ManagementClass wmi = new System.Management.ManagementClass("win32_Battery");
            var allBatteries = wmi.GetInstances();

            foreach (var battery in allBatteries)
            {
                int estimatedChargeRemaining = Convert.ToInt32(battery["EstimatedChargeRemaining"]);
                tbBattValue.Text= estimatedChargeRemaining.ToString();
            }

        }
    }
}
