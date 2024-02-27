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
using System.Threading;

/*
 * Reference:
 * 1. https://www.youtube.com/watch?v=945Hzyzzu2I 重要,簡單易懂
 * 2. https://www.youtube.com/watch?v=fB2aHwr2qF4
 *    . System.Threading.Timer
 *    3. https://blog.csdn.net/easyboot/article/details/122470982 
 *    4. https://learn.microsoft.com/en-us/dotnet/api/system.threading.timer?view=net-8.0
 */
namespace UIFunction.Function.WorkItem
{
    /// <summary>
    /// Interaction logic for Detail0_3.xaml
    /// </summary>
    public partial class Detail0_3 : UserControl
    {
        Thread thread0_3;
        int iCount = 0;

        System.Threading.Timer timerTest02;
        public Detail0_3()
        {
            InitializeComponent();
        }

        private void TestBtn01_Click(object sender, RoutedEventArgs e)
        {
            thread0_3 = new Thread(new ThreadStart(SetText));
            thread0_3.Start();
        }

        void SetText()
        {
            //testTBox01.Text = "Multithreading example.";    //這是不同的Thread,所以不可更新UI
            this.Dispatcher.Invoke(() => { testTBox01.Text = "Multithreading example."; });  //要這樣才能更新UI thread
        }

        private void testBtn02_Click(object sender, RoutedEventArgs e)
        {
            timerTest02 = new System.Threading.Timer(new System.Threading.TimerCallback(calculateTest), null, 10, 1000);  //參數3:10表示等10ms開始算,1000表示之後每秒執行一次
        }

        public void calculateTest(object sender)
        {
            this.Dispatcher.Invoke(() =>
            {
                testTBox01.Text = iCount++.ToString();
            });
        }
    }
}
