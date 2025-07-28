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

        double Ot002SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
        {
            //return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
            return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? 2.0;   //Joey's testing, 這樣值就會變成2了
        }

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
    }
}
