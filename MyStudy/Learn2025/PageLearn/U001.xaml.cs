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
    /// Interaction logic for U001.xaml
    /// </summary>
    public partial class U001 : Page
    {
        public U001()
        {
            InitializeComponent();
        }

        private void U001UnmanagedType_Click(object sender, RoutedEventArgs e)
        {
            UnmanagedTypeP001();
        }

        private void UnmanagedTypeP001()  //P131
        {
            P001_02DisplaySize<P001_03Coords<int>>();
            P001_02DisplaySize<P001_03Coords<double>>();
        }

        private unsafe static void P001_02DisplaySize<T>() where T: unmanaged //where的意思是要對後面的T做一些限制
        {
            Debug.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
        }
        
        public struct P001_03Coords<T>  \
        {
            public T X;
            public T Y;
        }
    }
}
