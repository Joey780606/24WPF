using System;
using System.Collections.Generic;
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
using System.Diagnostics;

namespace UIFunction.Function.WorkItem
{
    /// <summary>
    /// Interaction logic for DeleteFile.xaml
    /// </summary>
    public partial class DeleteFile : UserControl
    {
        const string directoryPath = @"C:\Users\pcpJoey\Downloads";

        public DeleteFile()
        {
            InitializeComponent();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            int cutoffDay = 0;
            
            try
            {
                cutoffDay = Convert.ToInt32(tbCutOffDay.Text) * -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Shutdown err:" + ex.Message);
                cutoffDay = -60;
            }

            DateTime cutoffDate = DateTime.Now.AddDays(cutoffDay);

            try
            {
                // 取得目錄中的所有檔案
                string[] files = Directory.GetFiles(directoryPath);
                Debug.WriteLine($"Delete file, before amount: {files.Count()}");
                int fitFileAmount = 0;

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    // 檢查創建時間是否早於閾值
                    if (fi.CreationTime < cutoffDate)
                    {
                        fitFileAmount++;
                        File.Delete(file);
                        Debug.WriteLine($"Delete file success: {file}");
                    }
                }
                string[] files2 = Directory.GetFiles(directoryPath);
                Debug.WriteLine($"Delete file, after amount: {files2.Count()}, fit file amount: {fitFileAmount}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Delete file error: {ex.Message}");
            }
        }

        private void btnChkFile_Click(object sender, RoutedEventArgs e)
        {
            int cutoffDay = 0;

            try
            {
                cutoffDay = Convert.ToInt32(tbCutOffDay.Text) * -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Shutdown err:" + ex.Message);
                cutoffDay = -60;
            }

            DateTime cutoffDate = DateTime.Now.AddDays(cutoffDay);

            try
            {
                // 取得目錄中的所有檔案
                string[] files = Directory.GetFiles(directoryPath);
                Debug.WriteLine($"Check file, before amount: {files.Count()}");
                int fitFileAmount = 0;

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    // 檢查創建時間是否早於閾值
                    if (fi.CreationTime < cutoffDate)
                    {
                        fitFileAmount++;
                        //File.Delete(file);
                        Debug.WriteLine($"Check file success: {file}");
                    }
                }
                string[] files2 = Directory.GetFiles(directoryPath);
                Debug.WriteLine($"Check file, after amount: {files2.Count()}, fit file amount: {fitFileAmount}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Check file error: {ex.Message}");
            }
        }

        private void btnCrushTest_Click(object sender, RoutedEventArgs e)
        {
            int x = 10;
            int y = 0;
            int result = x / y;
        }
    }
}
