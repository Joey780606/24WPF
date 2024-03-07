using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
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
using UIFunction.Function.Slider;

/*
 * Author: Joey
 * Reference: https://stackoverflow.com/questions/4013622/adjust-screen-brightness-using-c-sharp
 *  注意有分給Laptop用的,及給外接螢幕用的寫法
 * 
 */
namespace UIFunction.Function.WorkItem
{
    /// <summary>
    /// Interaction logic for Detail0_4.xaml
    /// </summary>
    public partial class Detail0_4 : UserControl
    {
        public Detail0_4()
        {
            InitializeComponent();

            Slider1.Minimum = 0;
            Slider1.Maximum = 100;
            Slider1.ValueChanged += BrightnessUpdate;
        }


        public static int Get()
        {
            using var mclass = new ManagementClass("WmiMonitorBrightness")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            using var instances = mclass.GetInstances();
            foreach (ManagementObject instance in instances)
            {
                return (byte)instance.GetPropertyValue("CurrentBrightness");
            }
            return 0;
        }

        public static void Set(int brightness)
        {
            using var mclass = new ManagementClass("WmiMonitorBrightnessMethods")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            using var instances = mclass.GetInstances();
            var args = new object[] { 1, brightness };
            foreach (ManagementObject instance in instances)
            {
                instance.InvokeMethod("WmiSetBrightness", args);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TbBrightness.Text=Get().ToString();
        }

        private void BrightnessUpdate(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TbBrightness.Text = Math.Round(e.NewValue).ToString();
            Set((int)Math.Round(e.NewValue));
        }
    }
}
