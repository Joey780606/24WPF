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
    /// 1. 官方文件: Pattern matching: Expressions: is, switch; Operators: and, or , not, 在官方文件:p448
    ///  
    /// </summary>
    public partial class P001 : Page
    {
        static bool b01IsConferenceDay(DateTime date) => date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 }; //重要,or的用法
        public record b01Point(int X, int Y);
        public record b01Segment(Point Start, Point End);
        static bool b01IsAnyEndOnXAxis(b01Segment segment) => segment is { Start: { Y:0 } } or { End: { Y:0 } };
        static bool b01IsAnyEndOnXAxis2(b01Segment segment) => segment is { Start.Y: 0 } or { End.Y: 0 };   //與上方二種不同的寫法

        public P001()
        {
            InitializeComponent();
        }

        // Functions list
        static string B01TakeFive(object input) => input switch
        {
            string { Length: >= 5 } s => s.Substring(0, 5),
            string s => s,
            ICollection<char> { Count: >= 5 } symbols => new string(symbols.Take(5).ToArray()),
            ICollection<char> symbols => new string(symbols.ToArray()),
            null => throw new ArgumentNullException(nameof(input)),
            _ => throw new ArgumentNullException("Not supported input type."),
        };

        // Button function 

        // 在官方文件: Property pattern, p456
        private void B01_Property_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(B01TakeFive("Hello world!"));
            Debug.WriteLine(B01TakeFive("Hi!"));
            Debug.WriteLine(B01TakeFive(new[] { '1', '2', '3', '4', '5', '6', '7', }));
            Debug.WriteLine(B01TakeFive(new[] { 'a', 'b', 'c' }));
        }
    }
}
