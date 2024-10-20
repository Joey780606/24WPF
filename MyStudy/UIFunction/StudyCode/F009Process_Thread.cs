/*
1. Function: Process, thread sample code
2. Detail: Find some useful code about how to use process, thread.
3. Keyword: [Process] [thread]
 */

/*
Code area 1:
  1. Ref: https://www.youtube.com/watch?v=6oU8OZLJvvs&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=42
  2. 進程:即程序, 線程:即執行緒
    4:30 互斥鎖 (Mutex, Mutual exclusion),防止多個執行緒同時讀寫某塊記憶體區域
    6:30 信號量 (Semaphore),用來保證多個線程不會衝突
    7:33 例子 (重要)
      10:21 異步
	  10:36 動畫說明
    此課為概念介紹,無code
*/

/*
Code area 2: 異步委托
  1. Ref: https://www.youtube.com/watch?v=6oU8OZLJvvs&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=43
    1:50 異步執行就是同時執行的意思
    6:07 一般會為較耗時的操作,開啟單獨的線程去執行,比方下載操作
  2. Program.cs
    a.第一版
    static void Test() {
        Debug.WriteLie("test");
    }

    static void Main(string[] args) {
        //1. 通過委托,開啟一個Thread
        Action a = Test;
        // a.Invoke();  //方式1: 直接調用他,這是可行的
        a.BeginInvoke(null, null); //方式2: 開啟一個新thread去執行 a 所引用的方法, 裡面需要設二個參數,先設null
          // BeginInvoke 是異步執行(非同步執行,async), Invoke是同步執行(sync)
        Debug.WriteLine("main");
    }

    b.第二版 (委託的function帶參數)
    static void Test(int i, string str) {
        Debug.WriteLie("test:" + i + " " + str);
    }

    static void Main(string[] args) {
        //1. 通過委托,開啟一個Thread
        Action<int,string> a = Test;
        a.BeginInvoke(100, "siki", null, null); 
        Debug.WriteLine("main");
    }

    c.第三版 (委托的function有返回值) 影片5:00後, 不能用Action,要用Function
    static int Test(int i, string str) {
        Debug.WriteLie("test:" + i + " " + str);
        Thread.Sleep(100);  //讓當前thread休眠 (暫停thread的執行),單位ms
        return 100;
    }

    static void Main(string[] args) {
        //1. 通過委托,開啟一個Thread
        Func <int,string,int> a = Test; //最後的int是返回值
        IAsyncResult ar = a.BeginInvoke(100, "siki", null, null); 
        // IAsyncResult 可以取得當前Thread的狀態
        Debug.Write("main");
        while (ar.IsCompleted == false) //如果當前thread沒有執行完成
        {
            Debug.WriteLine(".");
            //Thread.Sleep(10); //目的是經由主Thread的休眠,來控制 Func thread檢查的頻率 (可以少打一些.)
        }
        int res = a.EndInvoke(ar);  //取得異步線程的返回值
        Debug.WriteLine(res);
    }
*/

/*
Code area 3: 檢測Thread結束的方式
  1. Ref: https://www.youtube.com/watch?v=DnnlD0gxFn0&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=44
  2. Program.cs
    a.第一版 
    static int Test(int i, string str) {
        Debug.WriteLie("test:" + i + " " + str);
        Thread.Sleep(100);  //讓當前thread休眠 (暫停thread的執行),單位ms
        return 100;
    }

    static void Main(string[] args) {
        //1. 通過委托,開啟一個Thread
        Func <int,string,int> a = Test; //最後的int是返回值
        IAsyncResult ar = a.BeginInvoke(100, "siki", null, null); 
        // IAsyncResult可以取得當前Thread的狀態
        Debug.Write("main");

        //檢測Thread結束
        bool isEnd = ar.AsyncWaitHandle.WaitOne(1000);
            // WaitOne() 可等待目前線程結束,再執行下面的代碼
            // 1000ms是超時時間,若等待後Thread仍未結束,此方法返回false,否則會返回true
        if(isEnd)
        {
            int res = a.EndInvoke(ar);
            Debug.WriteLine(res);   //影片 3:34,看來回應是100
        }
        Debug.WriteLine(res);
    }

    b.第二版,影片4:26 異步回調
    static int Test(int i, string str) {
        Debug.WriteLie("test:" + i + " " + str);
        Thread.Sleep(100);  //讓當前thread休眠 (暫停thread的執行),單位ms
        return 100;
    }

    static void Main(string[] args) {
        // 透過回調,檢測線程結束
        Func <int,string,int> a = Test; //最後的int是返回值
        IAsyncResult ar = a.BeginInvoke(100, "siki", OnCallBack, a); 
            //第三參數,是一個委託,要傳遞一方法進去,當Thread結束時,會呼叫此方法
            //第三參數,是一個委託類型的參數,表示回調函式(callback),即當Thread結束時,會調用此委託指向的方法
            //第四參數,用來給回調函式傳遞資料
    }

    static void OnCallBack(IAsyncResult ar)
    {
        Func<int, string, int> a = ar.AsyncState as Func<int, string, int>;
        int res = a.EndInvoke(ar);  //會是100, 這是Test function的回傳值
        Debug.WriteLine("Sub thread end, get result from callback:" + res);
    }

    c.第三版,影片10:25 改成Lambda表達式
    static int Test(int i, string str) {
        Debug.WriteLie("test:" + i + " " + str);
        Thread.Sleep(100);  //讓當前thread休眠 (暫停thread的執行),單位ms
        return 100;
    }

    static void Main(string[] args) {
        // 透過回調,檢測線程結束
        Func <int,string,int> a = Test; //最後的int是返回值
        //IAsyncResult ar = a.BeginInvoke(100, "siki", OnCallBack, a); 
        ar = a.BeginInvoke(100, "siki", OnCallBack, ar =>
        {
            int res = a.EndInvoke(ar);
            Debug.WriteLine("Get value from lambda:" + res);
        }, null); 
            //第三參數,是一個委託,要傳遞一方法進去,當Thread結束時,會呼叫此方法
            //第三參數,是一個委託類型的參數,表示回調函式(callback),即當Thread結束時,會調用此委託指向的方法
            //第四參數,用來給回調函式傳遞資料
    }

    static void OnCallBack(IAsyncResult ar)
    {
        Func<int, string, int> a = ar.AsyncState as Func<int, string, int>;
        int res = a.EndInvoke(ar);  //會是100, 這是Test function的回傳值
        Debug.WriteLine("Sub thread end, get result from callback:" + res);
    }
*/

/*
Code area 4: 透過Thread類
  1. Ref: https://www.youtube.com/watch?v=3WRc_ex4yZg&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=45
  2. Program.cs
    a.第一版
    static void DownloadFile() {
        Debug.WriteLie("Start download: " + Thread.CurrentThread.ManagedThreadId);
            //Thread.CurrentThread.ManagedThreadId : 取得此 Thread 的 ID
        Thread.Sleep(2000);  //讓當前thread休眠 (暫停thread的執行),單位ms
        Debug.WriteLie("Download done");
    }

    static void Main(string[] args) {
        Thread t = new Thread(DownloadFile);    //創建Thread,但還沒啟動
        t.Start(); //啟動
        Debug.WriteLie("Main");        
    }

    b.第二版, 使用 Lambda 表達式
    static void Main(string[] args) {
        Thread t = new Thread(() =>
        {
            Debug.WriteLie("Start download: " + Thread.CurrentThread.ManagedThreadId);
                //Thread.CurrentThread.ManagedThreadId : 取得此 Thread 的 ID
            Thread.Sleep(2000);  //讓當前thread休眠 (暫停thread的執行),單位ms
            Debug.WriteLie("Download done");            
        }
        t.Start(); //啟動
        Debug.WriteLie("Main");        
    }

    c.第三版,傳遞參數 (方法一)
    static void DownloadFile(object filename) { //注意,傳遞的參數是object類型
        Debug.WriteLie("Start download: " + Thread.CurrentThread.ManagedThreadId + " " + filename);
            //Thread.CurrentThread.ManagedThreadId : 取得此 Thread 的 ID
        Thread.Sleep(2000);  //讓當前thread休眠 (暫停thread的執行),單位ms
        Debug.WriteLie("Download done");
    }

    static void Main(string[] args) {
        Thread t = new Thread(DownloadFile);    //創建Thread,但還沒啟動
        t.Start("xxx.doc"); //注意,傳遞的參數是放在這裡
        Debug.WriteLie("Main");        
    }

    c.第三版,傳遞參數 (方法二)
    ///// 建立一個 MyThread.cs的檔案
    class MyThread
    {
        private string filename;
        private string filepath;

        public MyThread(string fileName, string filePath) {
            this.filename = fileName;
            this.filepath = filePath;
        }

        public void DownFile() {
            Debug.WriteLine("開始下載:" + filepath + filename);
            Thread.Sleep(2000);
            Debug.WriteLine("下載完成");
        }
    }

    static void Main(string[] args) {
        MyThread my = new Thread("xxx.bt", "http://www.xxx.bbs");    //創建Thread,但還沒啟動
        Thread t = new Thread(my.DownFile);
        //我們構造一個thread對象的時侯,可以傳遞一個靜態方法,也可以傳遞一個對象的普通方法
        t.Start();
    }
*/

/*
Code area 5: 後台線程,前台線程
  1. Ref: https://www.youtube.com/watch?v=zmKJWXzLgt0&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=46
    0:00~2:35 說明很重要
    4:26~5:30 線程的優先級, Thread可設Priority屬性,影響線程的基本優先級,Priority屬性是ThreadPriority enum定義的值,
        有 Highest, AboveNormal, BelowNormal, Lowest. (只說明,無code)
    5:35 控制線程狀態 (Running, Untrusted), 我們使用Start方法後,新Thread不是馬上進入running的狀態,而是Untrusted,
        只有系統的線程調度器選擇了要運行的線程,才會改為Running狀態. 
        若使用 Thread.Sleep()方法,可讓目前線程休眠,進到WaitSleepJoin狀態
        Abort(): 可以停止Thread. 調用此方法,會在終止要終止的Thread中抛出 ThreadAboutException 異常,可用try catch此異常,來做清理的工作
  2. Program.cs
    static void DownloadFile(object filename) { //注意,傳遞的參數是object類型
        Debug.WriteLie("Start download: " + Thread.CurrentThread.ManagedThreadId + " " + filename);
            //Thread.CurrentThread.ManagedThreadId : 取得此 Thread 的 ID
        Thread.Sleep(2000);  //讓當前thread休眠 (暫停thread的執行),單位ms
        Debug.WriteLie("Download done");
    }

    static void Main(string[] args) {
        Thread t = new Thread(DownloadFile);    //這是前台行程
        //我們構造一個thread對象的時侯,可以傳遞一個靜態方法,也可以傳遞一個對象的普通方法
        t.IsBackground = true; //設置為後台線程,若是執行,不會等待二秒,直接隨程式結束而結束
        t.Start("xxx");
        //t.Abort();    //終止此線程的執行
        //t.Join();     //讓當前線程休眠,等待t線程執行完,再繼續運行下面的代碼
    }
*/