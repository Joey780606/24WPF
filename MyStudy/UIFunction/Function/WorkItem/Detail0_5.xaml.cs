using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
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
 * Author: Joey Yang
 * Reference: https://learn.microsoft.com/zh-tw/dotnet/csharp/linq/
 * Theme: LINQ (Language integrated query)
 */
namespace UIFunction.Function.WorkItem
{
    /// <summary>
    /// Interaction logic for Detail0_5.xaml
    /// </summary>
    public partial class Detail0_5 : UserControl
    {
        record City(string Name, long Population);  //著重在具結構性的一組資料(通常是固定的內容)
        record Country(string Name, double Area, long Population, List<City> Cities);

        static readonly Country[] countries = {
            new Country ("Vatican City", 0.44, 526, [new City("Vatican City", 826)]),
            new Country ("Monaco", 2.02, 38_000, [new City("Monte Carlo", 38_000)]),
            new Country ("Nauru", 21, 10_900, [new City("Yaren", 1_100)]),
            new Country ("Tuvalu", 26, 11_600, [new City("Funafuti", 6_200)]),
            new Country ("San Marino", 61, 33_900, [new City("San Marino", 4_500)]),
            new Country ("Liechtenstein", 160, 38_000, [new City("Vaduz", 5_200)]),
            new Country ("Marshall Islands", 181, 58_000, [new City("Majuro", 28_000)]),
            new Country ("Saint Kitts & Nevis", 261, 53_000, [new City("Basseterre", 13_000)])
        };

        public Detail0_5()
        {
            InitializeComponent();
        }

        private void Test1_Click(object sender, RoutedEventArgs e)
        {
            int[] scores = { 97, 92, 81, 60 };
            IEnumerable<int> scoreQuery = 
                from score in scores
                where score > 80
                select score;

            foreach (var i in scoreQuery)
            {
                Debug.WriteLine("Result: {0}", i);
            }
        }

        private void Test2_Click(object sender, RoutedEventArgs e)
        {
            // https://learn.microsoft.com/zh-tw/dotnet/csharp/linq/get-started/introduction-to-linq-queries
            List<int> numbers = new List<int> { 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

            IEnumerable<int> queryFactorsOfFour =
                from num in numbers
                where num % 4 == 0
                select num;

            var factorsofFourList = queryFactorsOfFour.ToList();    //主要是要存在新的變數
            Debug.WriteLine("Result 1: {0}", factorsofFourList[2]);
            factorsofFourList[2] = 0;
            Debug.WriteLine("Result 2: {0}", factorsofFourList[2]);
        }

        private void Test3_Click(object sender, RoutedEventArgs e)
        {
            int[] scores = { 90, 71, 82, 93, 75, 82 };
            IEnumerable<int> scoreQuery = 
                from score in scores    //必要的
                where score > 80    //可選的
                orderby score descending //可選的
                select score;   //必須要以 select 或是 group 當做結束

            foreach (var testScore in scoreQuery)
                Debug.WriteLine("Result 1: {0}", testScore);

            //====== 取資料裡的最大值
            var highestScore = (
                from score in scores
                select score
            ).Max();
            Debug.WriteLine("Result 2: {0}", highestScore);

            //====== 取資料裡的最大值,最簡化版
            var highScore = scores.Max();
            Debug.WriteLine("Result 3: {0}", highScore);

            //====== 取國家裡,城市中人數大於10000人的
            var largeCitiesList = (
                from country in countries
                from city in country.Cities
                where city.Population > 10000
                select city
            ).ToList();

            foreach (var largeCity in largeCitiesList)
                Debug.WriteLine("Result 4: {0} {1}", largeCity.Name, largeCity.Population);

            //====== 取國家裡,城市中人數大於10000人的
            IEnumerable<City> largeCitiesQuery =
                from country in countries
                from city in country.Cities
                where city.Population > 10000
                select city;
            var largeCitiesList2 = largeCitiesQuery.ToList();

            foreach (var largeCity in largeCitiesList2)
                Debug.WriteLine("Result 5: {0} {1}", largeCity.Name, largeCity.Population);

            //====== 找出人數超過500,000的國家
            IEnumerable<Country> countryAreaQuery =
                from country in countries
                where country.Area > 500000 //sq km
                select country;
            var countryInfos = countryAreaQuery.ToList();

            foreach (var countryInfo in countryInfos)
                Debug.WriteLine("Result 6: {0} {1}", countryInfo.Name, countryInfo.Population);

            //===== 假設您有 Country 物件集合，各包含名為 Cities的 City 物件。 若要查詢每個 Country 中的 City 物件，請使用兩個 from 子句
            IEnumerable<City> cityQuery =
                from country in countries
                from city in country.Cities     //重要,要用到二個from
                where city.Population > 10000
                select city;
            var cityInfos = cityQuery.ToList();

            foreach (var cityInfo in cityInfos)
                Debug.WriteLine("Result 7: {0} {1}", cityInfo.Name, cityInfo.Population);

            //===== Group的使用
            // 參: https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/group-clause
            var queryCountryGroups =
                from country in countries
                group country by country.Name[0];
            var countryInfos2 = queryCountryGroups;

            foreach (IGrouping<char, Country> countryGroup in countryInfos2)
            {
                Debug.WriteLine("Result 8-0: {0}", countryGroup.Key);
                // Explicit type for student could also be used here.
                foreach (var country in countryGroup)
                {
                    Debug.WriteLine("Result 8-1:    {0}, {1}", country.Name, country.Cities);
                }
            }
        }

        private void Test4_Click(object sender, RoutedEventArgs e)
        {
            City[] cities = {   //結合了record的用法,應該class也能用
                new City("Tokyo", 37_833_000),  //重要,數字代表底線
                new City("Delhi", 30_290_000),
                new City("Shanghai", 27_110_000),
                new City("São Paulo", 22_043_000)
            };

            IEnumerable<City> queryMajorCities = 
                from city in cities
                where city.Population > 100000
                select city;

            foreach (City city in queryMajorCities)
                Debug.WriteLine("Result 1: {0}", city);

            Debug.WriteLine("====");
            IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 100000);
            foreach (City city in queryMajorCities2)
                Debug.WriteLine("Result 2: {0}", city);

        }

        //看到 使用 select 子句來產生所有其他類型的序列
    }
}
