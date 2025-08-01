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

        // Begin: Interface 001 
        interface I001If1IPoint
        {
            int X { get; set; }
            int Y { get; set; }
            double Distance { get; }
        }

        class Point : I001If1IPoint
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }  //寫法重要,沒有分號
            public int Y { get; set; }

            public double Distance => Math.Sqrt(X * X + Y * Y);
        }
        // End: Interface 001

        // Begin: Implicit
        public readonly struct ImplicitDigit    //重要
        {
            private readonly byte digit;

            public ImplicitDigit(byte digit)
            {
                if (digit > 9)
                    throw new ArgumentOutOfRangeException(nameof(digit), "Digit must be between 0 and 9.");
                this.digit = digit;
            }

            // 以下重要, operator
            public static implicit operator byte(ImplicitDigit d) => d.digit; // 定義隱式轉換運算符,從 ImplicitDigit 到 byte 的轉換
            public static explicit operator ImplicitDigit(byte b) => new ImplicitDigit(b); // 定義明確轉換運算符,一定要用 ImplicitDigit 的建構函式來轉換 byte 到 ImplicitDigit

            public override string ToString() => $"{digit}"; 
        }
        // End: Implicit

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

        private void I001Interface1_Click(object sender, RoutedEventArgs e)
        {   // Original document: p103
            static void PrintPoint(I001If1IPoint p) // 重要,可以在裡面定義 static 方法
            {
                Debug.WriteLine("x={0}, y={1}", p.X, p.Y); // 使用介面屬性
            }

            I001If1IPoint p = new Point(2, 3);  //重要,宣告一個介面型別的變數,並實例化為 Point 類別
            PrintPoint(p);
        }

        private void I001Implicit_Click(object sender, RoutedEventArgs e)
        {   // Original document: p419
            var d = new ImplicitDigit(7); // 使用 ImplicitDigit 的建構函式

            byte number = d;    //使用隱式轉換運算符
            Debug.WriteLine($"ImplicitDigit -1: {number}"); // Output: 7

            ImplicitDigit digit = (ImplicitDigit)number; // 使用明確轉換運算符
            Debug.WriteLine($"ImplicitDigit -2: {number}");
        }
    }
}
