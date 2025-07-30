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
    /// Interaction logic for T001.xaml
    /// </summary>
    public partial class T001 : Page
    {
        public T001()
        {
            InitializeComponent();
        }

        // Function ===
        void PrintType<T>() => Debug.WriteLine($"Type of T: {typeof(T)}");


        private void T001Typeof_Click(object sender, RoutedEventArgs e)
        {
            // 獲得 type 的 System.Type 實例
            Debug.WriteLine("= = = = Test 1 = = = =");
            Debug.WriteLine($"Type of string: {typeof(List<string>)}");
            PrintType<int>();
            PrintType<System.Int32>();
            PrintType<Dictionary<int, char>>();
            PrintType<List<string>>();
            Debug.WriteLine($"Type of Dictionary<,>: {typeof(Dictionary<,>)}");
        }
    }
}
