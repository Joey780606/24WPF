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

        public record R002Point(int X, int Y, string Name);
        public record R002TaggedNumber(int number, List<string> Tags);

        private void R001ReferenceType_Click(object sender, RoutedEventArgs e)
        {   //Official document: p393
            var a = new R001Class(1);
            var b = new R001Class(1);
            var c = a;
            Debug.WriteLine("a == b: " + (a == b)); // False, 因為是不同的實例
            Debug.WriteLine("a == c: " + (a == c)); // True, 因為 c 是 a 的引用
        }

        private void R002ReferenceType_Click(object sender, RoutedEventArgs e)
        {   // Official document: p394
            // Record types are reference types, but they implement value equality by default(預設就有值相等).
            var p1 = new R002Point(2, 3, "A");
            var p2 = new R002Point(1, 3, "B");
            var p3 = new R002Point(2, 3, "A");

            Debug.WriteLine("p1 == p2: " + (p1 == p2)); // False, 因為是不同的實例
            Debug.WriteLine("p1 == p3: " + (p1 == p3)); // True, 因為記錄類型自動實現了值比較

            var n1 = new R002TaggedNumber(2, new List<string> { "A", "B" });
            var n2 = new R002TaggedNumber(30, new List<string> { "A", "B", "C" });
            var n3 = new R002TaggedNumber(2, new List<string> { "A", "B" });
            Debug.WriteLine("n1 == n2: " + (n1 == n2)); // False, 因為是不同的實例
            Debug.WriteLine("n1 == n3: " + (n1 == n3)); // True, 因為記錄類型自動實現了值比較
        }
    }
}
