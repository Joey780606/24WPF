using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for Page020Task.xaml
    /// </summary>
    public partial class Page020Task : Page
    {
        public Page020Task()
        {
            InitializeComponent();
        }

        private async void P001Test1_Click(object sender, RoutedEventArgs e)
        {
            // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.run?view=net-8.0
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var files = new List<Tuple<string, string, long, DateTime>>();

            var t = Task.Run(() =>
            {
                string dir = "C:\\Windows\\System32\\";
                //string dir = "C:\\PCP\\2024\\Document\\";
                //string dir = "C:\\Joey\\";
                object obj = new object();
                if (Directory.Exists(dir))
                {
                    Debug.WriteLine("The files amount: " + Directory.GetFiles(dir).Length);
                    Parallel.ForEach(Directory.GetFiles(dir),
                        f =>
                        {
                            if (token.IsCancellationRequested)
                                token.ThrowIfCancellationRequested();
                            var fi = new FileInfo(f);
                            lock (obj)
                            {
                                files.Add(Tuple.Create(fi.Name, fi.DirectoryName, fi.Length, fi.LastAccessTimeUtc));
                            }
                        });
                }
                else
                {
                    Debug.WriteLine("Directory is not exist.");
                }
            }, token);

            await Task.Yield();
            tokenSource.Cancel();
            try
            {
                await t;
                Debug.WriteLine("Retrieved information for {0} files.", files.Count);
            }
            catch (AggregateException ex)
            {
                Debug.WriteLine("Exception messages:");
                foreach (var ie in ex.InnerExceptions)
                    Debug.WriteLine("   {0}: {1}", ie.GetType().Name, ie.Message);

                Debug.WriteLine("\nTask status: {0}", t.Status);
            }
            finally
            {
                tokenSource.Dispose();
            }
        }
    }
}
