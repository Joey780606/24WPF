using System.Diagnostics;
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
using Learn2025.PageLearn;

/*
 * 1. 過程遇到問題
 *   a. 'InitializeComponent' does not exist in the current context 的錯誤
 *     1.參: https://stackoverflow.com/questions/6925584/the-name-initializecomponent-does-not-exist-in-the-current-context
 *       . Delete the \obj folder  . Rebuild the solution
 *       
 * 2. 文件從100頁開始 p100~p174
 *   a. 可直接看的程式: p103,p106(不允許的例子),p144, p179(const)
 *   
 * 3. Launcher程式包要再加範例的
 *   a. System.Threading.Mutex
 *   b. DispatcherTimer? checkSoftwareTimer;
 *   c. System.Environment
 *    c-2. GetFolderPath, SpecialFolder
 *   d. System.Globalization
 *   e. System.Threading.Timer
 *   f. NotifyIcon
 *   g. using的用法, using var stream = System.Windows.Application.GetResourceStream(uri)?.Stream;
 *   h. Process (new Process)
 *   i. System.Windows.Application.Current.Shutdown();
 *   j. System.DateTime
 *   k. StreamReader
 *   l. DialogResult
 *   m. System.IO.Path
 *    m-2. System.IO.Directory
 *   n. HttpClient
 *   o. TimeSpan
 *   p. HttpResponseMessage
 *   q. ProcessStartInfo
 *   r. GetIconFromImageSource
 */
namespace Learn2025
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _functionInfo = { "Fuction1", "Function2", "Page20Task" , "A001", "C001", "D001", "E001", "N001", "P001", "U001" };
        public MainWindow()
        {
            InitializeComponent();
            foreach (string info in _functionInfo)
                functionCbx.Items.Add(info);

            //MyFrame.Navigate(typeof(Page001));
            MyFrame.Content = new Page001();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //btnSubmit.Content = functionCbx.SelectedItem.ToString();
            Debug.WriteLine("info =" + functionCbx.SelectedItem.ToString());
            if (functionCbx.SelectedItem.ToString() == "Function2")
                //MyFrame.Navigate(typeof(Page002));
                MyFrame.Content = new Page002();
            else if (functionCbx.SelectedItem.ToString() == "Page20Task")
                //MyFrame.Navigate(typeof(Page020Task));
                MyFrame.Content = new Page020Task();
            else if (functionCbx.SelectedItem.ToString() == "A001")
                MyFrame.Content = new A001();
            else if (functionCbx.SelectedItem.ToString() == "C001")
                MyFrame.Content = new C001();
            else if (functionCbx.SelectedItem.ToString() == "D001")
                MyFrame.Content = new D001();
            else if (functionCbx.SelectedItem.ToString() == "E001")
                MyFrame.Content = new E001();
            else if (functionCbx.SelectedItem.ToString() == "N001")
                MyFrame.Content = new N001();
            else if (functionCbx.SelectedItem.ToString() == "P001")
                MyFrame.Content = new P001();
            else if (functionCbx.SelectedItem.ToString() == "U001")
                MyFrame.Content = new U001();
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