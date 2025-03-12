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
using _2025Study.PageLearn;


/*
 * 1. 過程遇到問題
 *   a. 'InitializeComponent' does not exist in the current context 的錯誤
 *     1.參: https://stackoverflow.com/questions/6925584/the-name-initializecomponent-does-not-exist-in-the-current-context
 *       . Delete the \obj folder  . Rebuild the solution
 *   b. 加入MVVM機制: 看到19:30 難,第二次:(ok: 0, 中等:1, 重要:2(35),3,4
 *     1.參: https://www.youtube.com/watch?v=wFzmBZpjuAo
 *       1:00 - HomeView.xaml: 應該要顯示各頁的畫面?
 *       2:00 - SettingView.xaml,設定畫面.
 *       3:00 - App.xaml 設定  DataTemplate
 *       4:00 - Microsoft.Extensions.DependencyInjection Nuget加此library
 *       5:00 - 做 ServiceCollection() 的處理 App.xaml.cs
 *       6:00 - 設立 DataContext
 *       7:00 - Service > NavigationService
 *       8:00 - Core > ViewModel.cs, ObservableObject.cs, INotifyPropertyChanged, 針對 HomeViewModel等各ViewModel 帶入繼承 Core.ViewModel
 *       9:00 - Core > RelayCommand.cs, Services > NavigationService.cs
 *       10:00 ~ 12:00 - Service > NavigationService
 *       13:00 - App.xaml.cs, services.AddSingleton
 *       14:00 - App.xaml.cs, MainViewModel.cs
 *       15:00 - MainViewModel.cs, 加入 RelayCommand
 *       16:00 - MainViewModel.cs, MainViewModel.xaml (XAML設計,不重要)
 *       17:00 - MainWindow.xaml <Button 使用 Command參數,重要)
 *       18:00 - xaml 設計
 *   c. Dependency Injection: https://www.youtube.com/watch?v=z8nx6AMQEO4
 *      https://www.youtube.com/watch?v=wwzhReyKV2Y 推薦
 */
namespace _2025Study
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _functionInfo = { "Fuction1", "Function2", "Page20Task" };
        public MainWindow()
        {
            InitializeComponent();
            foreach (string info in _functionInfo)
                functionCbx.Items.Add(info);

            //MyFrame.Navigate(typeof(Page001));
            //MyFrame.Content = new Page001();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //btnSubmit.Content = functionCbx.SelectedItem.ToString();
            Debug.WriteLine("info =" + functionCbx.SelectedItem.ToString());
            //if (functionCbx.SelectedItem.ToString() == "Function2")
            //    //MyFrame.Navigate(typeof(Page002));
            //    MyFrame.Content = new Page002();
            //else if (functionCbx.SelectedItem.ToString() == "Page20Task")
            //    //MyFrame.Navigate(typeof(Page020Task));
            //    MyFrame.Content = new Page020Task();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //if (MyFrame.CanGoBack)
            //{
            //    MyFrame.GoBack();
            //}
        }
    }
}