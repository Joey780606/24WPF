using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
using Learn2025.PageLearn.NonUIProgram;
/*
 * A001-01 Array : 讀 p117 ~ p127 (看 p117
 * 
 */
namespace Learn2025.PageLearn
{
    /// <summary>
    /// Interaction logic for A001.xaml
    /// </summary>
    public partial class A001 : Page
    {
        public A001()
        {
            InitializeComponent();
        }

        private void A001Array_Click(object sender, RoutedEventArgs e)
        {
            ArrayP001Define();
        }

        private void ArrayP001Define()  //僅為列出可行的定義
        {
            int[] array1 = new int[5];
            int[] array2 = { 1, 2, 3, 4, 5, 6 };
            int[,] multiDimensionalArray1 = new int[2, 3];
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[][] jaggedArray = new int[6][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
        }

        private void A001Abstract_Click(object sender, RoutedEventArgs e)
        {
            P_001Abstract.MyTest();
        }

        private async void A001Async_Click(object sender, RoutedEventArgs e)
        {
            MyTextBox1.Text += "\n";
            try
            {
                int length = await Async001Method();
                MyTextBox1.Text += String.Format("Length: {0:N0}\n", length);
            }
            catch (Exception)
            {
                MyTextBox1.Text += "Some error happen.";
            }
        }

        public async Task<int> Async001Method()
        {
            var httpClient = new HttpClient();
            int exampleInt = (await httpClient.GetStringAsync("http://msdn.microsoft.com")).Length;
            MyTextBox1.Text += "Preparing to finish ExampleMethodAsync. \n";
            return exampleInt;
        }

        private void A001Action_Click(object sender, RoutedEventArgs e)
        {
            Action action1 = () => MyTextBox1.Text += "Action 1 executed.\n";
            Action action2 = () => MyTextBox1.Text += "Action 2 executed.\n";
            Action action3 = () => MyTextBox1.Text += "Action 3 executed.\n";
            Action[] actions = { action1, action2, action3 };
            foreach (var action in actions)
            {
                action();
            }
            MyTextBox1.Text += "All actions executed.\n";
        }

        private void A001Action2_Click(object sender, RoutedEventArgs e)
        {   // Official document: p395, Delegate equality: 都是 null, 或他們的呼叫列表(invocation lists)長度相同,且每個位置的 entries 都相同 
            Action a = () => Debug.WriteLine("a");

            Action b = a + a;
            Action c = a + a;
            Debug.WriteLine("1. Object.ReferenceEquals(b, c): " + Object.ReferenceEquals(b, c));  // Output: False, 因為 b 和 c 的呼叫列表長度相同，但它們是不同的實例
            Debug.WriteLine("2. b == c: " + (b == c) );    // Output: True, 因為它們的呼叫列表相同 (都是呼叫兩次 a)

            Action d = () => Debug.WriteLine("d");
            Action e2 = () => Debug.WriteLine("e2");

            Debug.WriteLine("3. d == e2: " + (d == e2));    // Output: False, 因為 d 和 e 是不同的實例，即使它們的內容相同
            Debug.WriteLine("4. d + e2 == d + 2: " + (d + e2 == d + e2));    // Output: True, 因為它們的呼叫列表相同 (都是呼叫 d 和 e2)
            Debug.WriteLine("5. e2 + d == d + e2: " + (e2 + d == d + e2));    // Output: True, 因為呼叫列表的順序不影響相等性 (即使順序不同，內容相同仍然被視為相等)
        }

        private void A001Action3_Click(object sender, RoutedEventArgs e)
        {
            Action<int> display = s => Debug.WriteLine(s);

            List<int> numbers = [10, 17];
            display(numbers.Count);  // Output: 2, 因為 numbers 中有兩個元素

            numbers.Clear();
            display(numbers.Count);  // Output: 0, 因為 numbers 已經被清空
        }

        private void A001As_Click(object sender, RoutedEventArgs e)
        {   // as : 明確(explicitly)地轉換 expression 的結果,到一個指定的reference,或是nullable value
            // Official document: p414
            IEnumerable<int> numbers = new[] { 10, 20, 30 };
            IList<int> indexable = numbers as IList<int>;
            if(indexable != null)  // 確認轉換成功
            {
                Debug.WriteLine($"indexable add result: {indexable[0] + indexable[indexable.Count - 1]}");  // output: 40
            }
        }
    }
}
