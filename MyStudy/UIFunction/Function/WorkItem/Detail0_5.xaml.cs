using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading;
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
 * Author: Joey Yang
 * Reference: https://learn.microsoft.com/zh-tw/dotnet/csharp/linq/
 * Theme: LINQ (Language integrated query)
 */
namespace UIFunction.Function.WorkItem
{
    /// <summary>
    /// Interaction logic for Detail0_5.xaml
    /// </summary>
    public partial class Detail0_5 : UserControl
    {
        public Detail0_5()
        {
            InitializeComponent();
        }

        private void Test1_Click(object sender, RoutedEventArgs e)
        {
            int[] scores = { 97, 92, 81, 60 };
            IEnumerable<int> scoreQuery = 
                from score in scores
                where score > 80
                select score;

            foreach (var i in scoreQuery)
            {
                //Console.WriteLine("Result: {0} ", i);
                Debug.WriteLine("Result: {0} ", i);
            }
        }
    }
}
