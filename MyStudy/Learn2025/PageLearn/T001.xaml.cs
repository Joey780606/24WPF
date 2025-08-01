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

        public class Animal { }
        public class Giraffe : Animal { }   

        private void T001Typeof_Click(object sender, RoutedEventArgs e)
        {
            // 獲得 type 的 System.Type 實例, Original document: p416
            Debug.WriteLine("= = = = Test 1 = = = =");
            Debug.WriteLine($"Type of string: {typeof(List<string>)}");
            PrintType<int>();
            PrintType<System.Int32>();
            PrintType<Dictionary<int, char>>();
            PrintType<List<string>>();
            Debug.WriteLine($"Type of Dictionary<,>: {typeof(Dictionary<,>)}");

            Debug.WriteLine("= = = = Test 2 = = = =");
            // Original document: p417, is 與 typeof 的差異
            // typeof: 在編譯時期就確定了型態, 檢查一個 expression 在 run-time 的型態,是否與指定的型態相符,不能跟父類別比較
            object b = new Giraffe();
            Debug.WriteLine("b test is 1:" + (b is Animal));    // true, 因為 Giraffe 是 Animal 的子類別
            Debug.WriteLine("b test is 2:" + (b is Giraffe));

            Debug.WriteLine("b test typeof 1:" + (b.GetType() == typeof(Animal)));  //跟父類別比較,會返回 false
            Debug.WriteLine("b test typeof 2:" + (b.GetType() == typeof(Giraffe)));
        }
    }
}
