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
using UIFunction.Function.Slider;

/*
 * Author: Joey
 * License: 
 *   1. NetCore5.0.Microsoft.Expression.Drawing (https://www.nuget.org/packages/NetCore5.0.Microsoft.Expression.Drawing/)
 * Importantance:
 *   1. xmlns declare: xmlns:ed="http://schemas.microsoft.com/expression/2010/drawing"
 *   2. Reference: https://www.youtube.com/watch?v=a7uBKEe6AtA
 */
namespace UIFunction.Function.ProgressBar
{
    /// <summary>
    /// Interaction logic for Circle1.xaml
    /// </summary>
    public partial class Circle1 : UserControl
    {
        public Circle1()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var sldr = (System.Windows.Controls.Slider)sender;  //重要,要這樣寫(System.Windows.Controls.Slider),因為這個專案有一個我們自建的Slider namespace,但我們是要用系統的,所以要這樣寫
            ARC1.EndAngle = sldr.Value * 3.6;
            ARC2.EndAngle = sldr.Value * 3.6;
            ARC1.Fill = this.Resources["FillBrush"] as RadialGradientBrush;
            ARC2.Fill = this.Resources["FillBrush"] as RadialGradientBrush;
        }
    }
}
