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
    /// Interaction logic for D001.xaml
    /// </summary>
    public partial class D001 : Page
    {
        public D001()
        {
            InitializeComponent();
        }

        private void D001Default_Click(object sender, RoutedEventArgs e)    //p133
        {
            int a = default(int);
            int b = default;

            // C# 中用於表示複數。複數由實部和虛部組成，形式為 a + bi，其中 a 是實部，b 是虛部，i 是虛數單位. (數學函數較常用到)
            var c = new System.Numerics.Complex();
            var d = new System.Numerics.Complex(2, 3);
            Debug.WriteLine($"Default result: {a}, {b}, {c}, {d}");
        }

        private void D001Double_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"double.NaN < 5.1: " + (double.NaN < 5.1));    //output: False
            Debug.WriteLine($"double.NaN >= 5.1: " + (double.NaN >= 5.1));    //output: False
        }
    }
}
