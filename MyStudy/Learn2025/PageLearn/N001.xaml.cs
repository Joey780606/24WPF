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
    public class Null01_ProductDescription  //重要,除了主程式外,還可在外面加其他class
    {
        private string shortDescription;
        private string? detailedDescription;

        public Null01_ProductDescription()   //建議 shortDescription 不能為 initialized
        {
        }

        public Null01_ProductDescription(string productDescription) => shortDescription = productDescription; //重要,簡化寫法, 只有一行

        public Null01_ProductDescription(string productDescription, string? details = null)
        {
            shortDescription = productDescription;
            detailedDescription = details;
        }

        public void SetDescription(string productDescription, string? details = null)
        {
            shortDescription = productDescription;
            detailedDescription = details;
        }

        public string GetDescription()
        {
            if (detailedDescription.Length == 0) //重要, 如果 detailedDescription 是 null, 這行會報錯
            {
                return shortDescription;
            }
            else
            {
                return $"{shortDescription}\n{detailedDescription}";
            }
        }

        public string FullDescription() {
            if (detailedDescription == null)
            {
                return shortDescription;
            }
            else if(detailedDescription.Length > 0)
            {
                return $"{shortDescription}\n{detailedDescription}";
            }
            return shortDescription; //如果 detailedDescription 是空字串, 也返回 shortDescription
        }

    }

    /// <summary>
    /// Interaction logic for N001.xaml
    /// </summary>
    public partial class N001 : Page
    {
        public N001()
        {
            InitializeComponent();
        }

        private void N001Null_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("= = = = Test 1 = = = =");
            string notNull = "Hello";
            //Debug.WriteLine($"N001-00: {notNull}");
            string? nullable = default; //nullable可以是null, 但notNull不能是null
            notNull = nullable!; //null forgiveness
            Debug.WriteLine($"N001-01: {notNull}, {nullable}, {notNull == null}, {nullable == null}");

            Debug.WriteLine("= = = = Test 2 = = = =");
            // Original document: p107
            string shortDescription = default;  //設為default,結果會是null
              //重要,這行不會有編譯錯誤,只有在嘗試存取 shortDescription 的屬性或方法（如 shortDescription.Length）時，才會因為 null 而發生執行時錯誤（NullReferenceException）。
            var product = new Null01_ProductDescription(shortDescription);

            string description = "widget";
            var item = new Null01_ProductDescription(description);
            item.SetDescription(description, "These widgets will do everything.");
        }
    }
}
