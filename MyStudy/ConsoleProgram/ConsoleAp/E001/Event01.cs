/// 目的:是會亂數取一個threshold值，然後每次按下a鍵就會加1，當加到threshold的時候就會觸發事件
/// 編譯是 Run -> Starting debugging
/// 執行是在 Terminal -> 打上 dotnet run
namespace ConsoleAp
{
    class Counter
    {
        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            Console.WriteLine("total, threshold: {0}, {1}", total, threshold);
            if (total >= threshold)
            {
                ThresholdReached?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler ThresholdReached;
    }

    internal class Event01
    {
        //static void Main(string[] args)
        public static void Mytest()
        {
            Counter c = new Counter(new Random().Next(10));
            c.ThresholdReached += c_ThresholdReached;
            
            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }

            static void c_ThresholdReached(object sender, EventArgs e) {
                Console.WriteLine("The threshold was reached.");
                Environment.Exit(0);
            }
        }
    }    
}