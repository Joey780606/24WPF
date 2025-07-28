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
    /// Interaction logic for R001.xaml
    /// </summary>
    public partial class R001 : Page
    {
        public R001()
        {
            InitializeComponent();
        }

        public class R001Class
        {
            private int id;
            public R001Class(int id) => this.id = id;
        }

        private void R001ReferenceType_Click(object sender, RoutedEventArgs e)
        {   //Official document: p393
            var a = new R001Class(1);
            var b = new R001Class(1);
            var c = a;
            Debug.WriteLine("a == b: " + (a == b)); // False, 因為是不同的實例
            Debug.WriteLine("a == c: " + (a == c)); // True, 因為 c 是 a 的引用
        }
    }
}
