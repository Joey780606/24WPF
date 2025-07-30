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
    /// Interaction logic for I001.xaml
    /// </summary>
    public partial class I001 : Page
    {
        public I001()
        {
            InitializeComponent();
        }

        public class I001Base { }

        public class I001Derived: I001Base { }

        private void I001is_Click(object sender, RoutedEventArgs e)
        {
            //is: 檢查一個 expression 在 run-time 的型態,是否與指定的型態相符
            // Official document: p413
            Debug.WriteLine("= = = = Test 1 = = = =");
            object b = new I001Base();
            Debug.WriteLine($"b is I001Base: {b is I001Base}"); // true
            Debug.WriteLine($"b is I001Derived: {b is I001Derived}"); // false

            object d = new I001Derived();
            Debug.WriteLine($"d is I001Base: {d is I001Base}"); // true
            Debug.WriteLine($"d is I001Derived: {d is I001Derived}"); // true

            Debug.WriteLine("= = = = Test 2 = = = =");
            int i = 27;
            Debug.WriteLine($"i is I001Base: {i is System.IFormattable}"); // true

            object iBoxed = i;
            Debug.WriteLine($"iBoxed is int: {iBoxed is int}"); // true
            Debug.WriteLine($"iBoxed is int: {iBoxed is long}"); // false

            Debug.WriteLine("= = = = Test 3 = = = =");
            int i2 = 23;
            object iBoxed2 = i2;
            int? jNullable = 7;
            if (iBoxed2 is int a && jNullable is int b2) // 使用模式匹配
            {
                Debug.WriteLine($"a + b: {a + b2}");    // 30
            }

        }
    }
}
