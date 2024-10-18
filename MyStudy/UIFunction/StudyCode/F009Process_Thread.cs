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
        // IAsyncResult可以取得當前Thread的狀態
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