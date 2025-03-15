using System;
using System.Collections.Generic;
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
    }
}
