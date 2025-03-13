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
using System.Xml.Linq;

/* 
 * C001-01 Collections
 *  1.分 Element access(ex: List, Dictionary), 動態增/減(ex: Array, System.Span<T>, System.Memory<T>, 還有像 System.Span<T>
 *  2.相關函式: Remove, RemoveAt, Add, 
 *  
 *  其他注意事項:
 *  1. KeyValuePair, TryGetValue
 */
namespace Learn2025.PageLearn
{
    /// <summary>
    /// Interaction logic for C001.xaml
    /// </summary>
    public partial class C001 : Page
    {
        public C001()
        {
            InitializeComponent();
        }

        private void C001Collections_Click(object sender, RoutedEventArgs e)
        {
            CollectionsP001List();
            Debug.WriteLine("----");
            CollectionsP002Dictionary();
            Debug.WriteLine("----");
            CollectionsP003LINQ();
        }

        private void CollectionsP003LINQ()
        {
            Debug.WriteLine($"=== LINQ testing ===");
            List<Coll_P002Element> elements = Coll_P003BuildList();

            var subset = from theElement in elements
                         where theElement.AtomicNumber < 22
                         orderby theElement.Name
                         select theElement;

            foreach (Coll_P002Element theElement in subset)
                Debug.WriteLine(theElement.Name + " " + theElement.AtomicNumber);
        }

        private static List<Coll_P002Element> Coll_P003BuildList() => new()
        {
            { new () { Symbol="K", Name="Potassium", AtomicNumber=19}},
            { new () { Symbol="Ca", Name="Calcium", AtomicNumber=20}},
            { new () { Symbol="Sc", Name="Scandium", AtomicNumber=21}},
            { new () { Symbol="Ti", Name="Titanium", AtomicNumber=22}}
        };

        public class Coll_P002Element
        {
            public required string Symbol { get; init; }
            public required string Name { get; init; }
            public required int AtomicNumber { get; init; }

        }
        private void CollectionsP002Dictionary()
        {
            Dictionary<string, Coll_P002Element> elements = Coll_P002BuildDictionary();

            Debug.WriteLine($"=== Dictionary testing ===");
            foreach (KeyValuePair<string, Coll_P002Element> kvp in elements)
            {
                Coll_P002Element theElement = kvp.Value;

                Debug.WriteLine($"key: {kvp.Key}");
                Debug.WriteLine($"Values: {theElement.Symbol},  {theElement.Name},  {theElement.AtomicNumber}");
            }

            Debug.WriteLine("  Test 1:-----");
            if (elements.ContainsKey("symbol") == false)
                Debug.WriteLine("key = symbol is not found");
            else
            {
                Coll_P002Element theElement2 = elements["symbol"];
                Debug.WriteLine("found: " + theElement2.Name);
            }

            Debug.WriteLine("  Test 2:-----");
            if (elements.ContainsKey("Ti") == false)
                Debug.WriteLine("key = Ti is not found");
            else
            {
                Coll_P002Element theElement3 = elements["Ti"];
                Debug.WriteLine("found: " + theElement3.Name);
            }

            Debug.WriteLine("  Test 3:-----");
            if(elements.TryGetValue("Ti", out Coll_P002Element? theElement4) == false)
                Debug.WriteLine("Ti" + "not found");
            else
                Debug.WriteLine("Found:" + theElement4.Name);
        }

        private static Dictionary<string, Coll_P002Element> Coll_P002BuildDictionary() =>
            new()
            {
                {"K", new () { Symbol="K", Name="Potassium", AtomicNumber=19} },
                {"Ca", new () { Symbol="Ca", Name="Calcium", AtomicNumber=20} },
                {"Sc", new () { Symbol="Sc", Name="Scandium", AtomicNumber=21} },
                {"Ti", new () { Symbol="Ti", Name="Titanium", AtomicNumber=22} }
            };

        private void CollectionsP001List() //基本功能測試
        {
            var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };

            foreach (var salmon in salmons)
            {
                Debug.WriteLine(salmon + " ");
            }
            Debug.WriteLine("----");

            salmons.Remove("coho");
            for(var index =0; index < salmons.Count; index++)
            {
                Debug.WriteLine(salmons[index] + " ");
            }
            Debug.WriteLine("----");

            salmons.Add("tiger");
            foreach (var salmon in salmons)
            {
                Debug.WriteLine(salmon + " ");
            }
            Debug.WriteLine("----");
            salmons.RemoveAt(2);
            salmons.ForEach(info => Debug.WriteLine(info + ".."));
        }
    }
}
