using Microsoft.VisualBasic;
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
    /// Interaction logic for Other001.xaml
    /// </summary>
    public partial class Other001 : Page
    {
        public Other001()
        {
            InitializeComponent();
        }
        
        static void Ot001Write(int[] values, Range range) =>    //第二個參數重要,是Range
            Debug.WriteLine($"{range}:\t{string.Join(", " ,values[range])}");

        double Ot002SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
        {
            //return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
            return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? 2.0;   //Joey's testing, 這樣值就會變成2了
        }

        void Ot001Display<T>(IEnumerable<T> xs) => Debug.WriteLine(string.Join(", ", xs));  //重要的寫法

        private void Ot001Dot_Click(object sender, RoutedEventArgs e)
        {   // Official document: p400
            List<Double> constants = [Math.PI, Math.E]; // C# 11 的新語法，使用 [] 定義 List
            Debug.WriteLine($"{constants.Count} values to show: ");
            Debug.WriteLine(string.Join(", ", constants));
        }

        int Ot001_GetSumOfFirstTwoOrDefault(int[]? numbers)
        {
            if ((numbers?.Length ?? 0) < 2)
            {
                return 0; // 如果數組為 null 或長度小於 2，則返回 0
                // return 5;
            }
            return numbers[0] + numbers[1];
        }

        private void Ot001Null_conditional_Click(object sender, RoutedEventArgs e)
        {   // Office document: p403
            var sum1 = Ot002SumNumbers(null, 0);
            Debug.WriteLine($"Sum1: {sum1}"); // output: NaN

            List<double[]?> numberSets = [
                    [1.0, 2.0, 3.0],
                    null
            ];

            var sum2 = Ot002SumNumbers(numberSets, 0);
            Debug.WriteLine($"Sum2: {sum2}"); // output: 6 ,處理資料是 [1.0, 2.0, 3.0]

            var sum3 = Ot002SumNumbers(numberSets, 1);
            Debug.WriteLine($"Sum3: {sum3}"); // output: NaN, 處理資料是 null
        }

        private void Ot001Null_conditional2_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(Ot001_GetSumOfFirstTwoOrDefault(null)); // output: 0
            Debug.WriteLine(Ot001_GetSumOfFirstTwoOrDefault([])); // output: 0
            Debug.WriteLine(Ot001_GetSumOfFirstTwoOrDefault([3, 4, 5])); // output: 7, 處理資料是 [3, 4, 5]
        }

        private void Ot001FromEndOperator_Click(object sender, RoutedEventArgs e)
        {   // ^ : 從最後面取得元素
            int[] xs = [0, 10, 20, 30, 40];
            int last = xs[^1]; // 使用 ^1 取得最後一個元素
            Debug.WriteLine($"FromEnd-1: {last}");    // output: 40

            List<string> lines = ["one", "two", "three", "four"];
            string prelast = lines[^2]; // 使用 ^2 取得倒數第二個元素
            Debug.WriteLine($"FromEnd-2: {prelast}"); // output: three

            string word = "Twenty";
            Index toFirst = ^word.Length; // 先取得Length, 然後從最後面開始計算索引, 重要(Index)
            char first = word[toFirst]; // 取得第一個字符
            Debug.WriteLine(first); // output: T
        }

        private void Ot001RangeOperator_Click(object sender, RoutedEventArgs e)
        {   // Official document: p408
            int[] numbers = [0, 10, 20, 30, 40, 50];
            int start = 1;
            int amountToTake = 3;
            int[] subset = numbers[start..(start + amountToTake)]; // 使用 .. 取得子數組
            Debug.WriteLine($"Range1: {start}, {start + amountToTake}");
            Ot001Display(subset);   // output: 10, 20, 30

            int margin = 1;
            int[] inner = numbers[margin..^margin]; // 使用 ^ 取得倒數的範圍
            Ot001Display(inner);    // output: 10, 20, 30, 40

            string line = "one two three";
            int amountToTakeFromEnd = 5;
            Range endIndices = ^amountToTakeFromEnd..^0; // 使用 ^ 取得從結尾開始的範圍
            string end = line[endIndices];
            Ot001Display(end);

            //= = = = =
            int amountToDrop = numbers.Length / 2; // 取得數組長度的一半

            int[] rightHalf = numbers[amountToDrop..]; // 使用 .. 取得右半部分
            Ot001Display(rightHalf); // output: 30, 40, 50

            int[] leftHalf = numbers[..^amountToDrop]; // 使用 ^ 取得左半部分
            Ot001Display(leftHalf); // output: 0, 10, 20

            int [] all = numbers[..]; // 使用 .. 取得整個數組
            Ot001Display(all); // output: 0, 10, 20, 30, 40, 50

            //= = = = =
            Debug.WriteLine("======= Part 3 =======");
            int[] oneThroughTen = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            Ot001Write(oneThroughTen, ..);  //取得整個數組
            Ot001Write(oneThroughTen, ..3); //從頭取到索引3(不含索引3)的元素
            Ot001Write(oneThroughTen, 2..); //取得從索引2開始到結尾的所有元素
            Ot001Write(oneThroughTen, 3..5);    //取得索引3到索引5(不包含)的元素
            Ot001Write(oneThroughTen, ^2..);
            Ot001Write(oneThroughTen, ..^3);
            Ot001Write(oneThroughTen, 3..^4);
            Ot001Write(oneThroughTen, ^4..^2);

            //0..^0:	1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            //0..3:	    1, 2, 3
            //2..^0:	3, 4, 5, 6, 7, 8, 9, 10
            //3..5:	    4, 5
            //^2..^0:	9, 10
            //0..^3:	1, 2, 3, 4, 5, 6, 7
            //3..^4:	4, 5, 6
            //^4..^2:	7, 8
        }
    }
}
