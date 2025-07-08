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

namespace Learn2025.PageLearn
{
    /// <summary>
    /// Interaction logic for O001.xaml
    /// </summary>
    public partial class O001 : Page
    {
        public O001()
        {
            InitializeComponent();
        }

        private void O001Operator_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public readonly struct O001Fraction
    {
        private readonly int num;
        private readonly int den;

        public O001Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
            }
            num = numerator;
            den = denominator;
        }

        public static O001Fraction operator +(O001Fraction a) => a;
        public static O001Fraction operator -(O001Fraction a) => new O001Fraction(-a.num, -a.den);
        public static O001Fraction operator +(O001Fraction a, O001Fraction b) => a;
    }
}
