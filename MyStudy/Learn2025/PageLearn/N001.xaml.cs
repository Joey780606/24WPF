using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Learn2025.PageLearn
{
    /// <summary>
    /// Interaction logic for N001.xaml
    /// </summary>
    public partial class N001 : Page
    {
        public N001()
        {
            InitializeComponent();
        }

        private void N001Null_Click(object sender, RoutedEventArgs e)
        {
            string notNull = "Hello";
            //Debug.WriteLine($"N001-00: {notNull}");
            string? nullable = default;
            notNull = nullable!; //null forgiveness
            Debug.WriteLine($"N001-01: {notNull}");
        }
    }
}
