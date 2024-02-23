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
 * Author: Joey
 * Reference:
 *  1. https://learn.microsoft.com/zh-tw/dotnet/standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously
 *  2. 疑似失敗的原因: https://blog.csdn.net/yl2isoft/article/details/11711833
 */
namespace UIFunction.Function.WorkItem
{
    public class AsyncDemo
    {
        // 此方法會非同步執行
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }

        // delegate須有相同的signature為method, 它將會非同步地呼叫
        public delegate string AsyncMethodCaller(int callDuration, out int threadId);
    }

    /// <summary>
    /// Interaction logic for Detail0_2.xaml
    /// </summary>
    public partial class Detail0_2 : UserControl
    {
        public Detail0_2()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            //****************測試1
            int threadId;

            AsyncDemo ad = new AsyncDemo();
            AsyncDemo.AsyncMethodCaller caller = new AsyncDemo.AsyncMethodCaller(ad.TestMethod);  //要加 AsyncDemo.

            IAsyncResult result = caller.BeginInvoke(3000, out threadId, null, null);

            Thread.Sleep(0);
            Console.WriteLine("Main thread {0} does some work.", Thread.CurrentThread.ManagedThreadId);

            string returnValue = caller.EndInvoke(out threadId, result);
            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", threadId, returnValue);
        }
    }
}
