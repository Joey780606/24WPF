using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _2025Study.PageLearn;

namespace _2025Study
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _functionInfo = { "Fuction1", "Function2" };
        public MainWindow()
        {
            InitializeComponent();
            foreach (string info in _functionInfo)
                functionCbx.Items.Add(info);

            MyFrame.Navigate(typeof(Page001));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //btnSubmit.Content = functionCbx.SelectedItem.ToString();
            MyFrame.Navigate(typeof(Page002));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
            }
        }
    }
}