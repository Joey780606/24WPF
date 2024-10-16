/*
1. Function: Delegate sample code
2. Detail: Find some useful code about how to use delegate.
3. Keyword: [Delegate]
4. 
 */

/*
Code area 1:
  1. Ref: https://www.youtube.com/watch?v=QD47TwnvB_g&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=14&t=1s
   9:50開始 (這是最基本介紹,但實際上較少人這樣做)
    private delegate string GetAString(); //定義

    int x = 40;
    GetAString a = new GetAString(x.ToString); //使用委託類型,創建實例, 委託是指向一個方法,所以括弧內加入 x.ToString ,不加括號,只是把引用拿過來
    //上句就是把a指向了x中的ToString方法

    string s = a(); //結果為 "40"
    Debug.WriteLine(s);

  2. Ref: https://www.youtube.com/watch?v=HWATQKLqckY&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=15
    a. 第一項的延伸說明:
    private delegate string GetAString(); //定義
    int x = 40;

    //另一種宣告和呼叫的方法
    GetAString a = x.ToString;  //ToString方法的引用,不帶括號
    string s = a.Invoke();  //通過invoke方法調用a所引用的方法

    b. 使用委托類型作為方法的參數
    private delegate void PrintString();
    static void ShowStr( PrintString print) //ShowStr名稱跟影片不同,是為了避免搞淆
    {
        print();
    }

    static void Method1() {
        Debug.WriteLine("method1");
    }

    static void Method2() {
        Debug.WriteLine("method2");
    }

    主程式加以下:
    PrintString method = Method1;   //不是呼叫 Method1的方法,只是引用 Method1,重要
    ShowStr(medhod);
    method = Method2;
    ShowStr(method);
    Console.ReadKey();
*/

/*
Code area 2: 多播委託 (一個委託可引用多個方法, += , -=)
  1. Ref: https://www.youtube.com/watch?v=6ekfgeHhQ9U&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=18
    a. 例1: 5:03介紹重要
    static void Test1()
    {
        Debug.WriteLine("test1");
    }

    static void Test2()
    {
        Debug.WriteLine("test2");
    }

    static void Main(string[] args) {
        //以下不是多播委托,因為要兼容
        //Action a = Test1;
        //a=Test2;

        Action a = Test1;
        a += Test2; //添加一個委託的引用(注意不加())
        a -= Test1;
        a -= Test2; //重要: 當委託沒有指向任何方法,執行會出現異常
        if(a != null)
            a();    //印出 test1 test2
        Console.ReadKey();
    }

    b. 取得多播委托中所有方法的委託
    Action a1 = Test1; //借用上面的方法的引用(注意不加())
    a1 += Test2

    Delegate[] delegates = a1.GetInvocationList();
    foreach(Delegate de in delegates) {
        de.DynamicInvoke();
    Console.ReadKey();
*/

/*
Code area 3: 觀察者模式
  1. Ref: https://www.youtube.com/watch?v=uH4HLzf2YBU&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=23
   說明: 貓(被觀察者)和老鼠(觀察者), 在被觀察者(貓)裡提供一個委託,讓別的觀察者註冊(添加到)這個委託
  2. 貓(被觀察者)
    class Cat
    {
        private string name;
        private string color;

        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public void CatComing()
        {
            Console.WriteLine(color + "的貓" + name + "過來了");
            catCome();
        }

        public Action catCome;  //重要: 提供一個委託,讓別的觀察者老鼠註冊(添加到)這個委託
    }

  3. 老鼠
    class Mouse
    {
        private string name;
        private string color;

        public Mouse(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public void RunAway()
        {
            Console.WriteLine(color + "的老鼠" + name + "跑跑跑");
            catCome();
        }
    }

  4. 主程式
    class Program {
        static void Main(string[] args) {
            Cat cat = new Cat("CatA", "Yellow");
            Mouse mouse1 = new Mouse("MouseA", "Black");
            cat.catCome += mouse1.RunAway;  //極重要,讓別的觀察者老鼠的function註冊(添加到)這個委託
            Mouse mouse2 = new Mouse("MouseB", "Red");
            cat.catCome += mouse1.RunAway;  
            Mouse mouse3 = new Mouse("MouseC", "Yellow");
            cat.catCome += mouse1.RunAway;  
            Mouse mouse4 = new Mouse("MouseD", "Black");
            cat.catCome += mouse1.RunAway;

            cat.CatComing();
 */

/*
Code area 4: 觀察者模式(上方Code area 3)的優化,加上事件
  1. Ref: https://www.youtube.com/watch?v=D0BDLrWsX6k&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=24
   說明: 貓(被觀察者)和老鼠(觀察者), 在被觀察者(貓)裡提供一個委託,讓別的觀察者註冊(添加到)這個委託
     4:56 ppt說明 (5:51 事件不能在類別的外部觸發)
     6:13 UML圖 (但不完全相同)
     7:45 事件,委托的區別 
        使用中,委托常用來表達回調(callback),事件表達外發的接口

  2. 貓(被觀察者)
    class Cat
    {
        private string name;
        private string color;

        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public void CatComing()
        {
            Console.WriteLine(color + "的貓" + name + "過來了");
            if(catCome != null)
                catCome();
        }

        public event Action catCome;  //重要: 聲明一個事件, 發布一個消息
        // 2:57 如果只是 delegate,那可在 Main 裡直接使用 cat.catCome(); 但不建議這樣用,較建議直接在Cat類別裡呼叫自身的delegate
        // 4:11 事件不能在類的外部觸發,只能在類的內部觸發, 所以使用事件會比 delegate 好
    }

  3. 老鼠
    class Mouse
    {
        private string name;
        private string color;

        public Mouse(string name, string color, Cat cat)    //新增一個Cat
        {
            this.name = name;
            this.color = color;
            cat.catCome += this.RunAway;    //把自身的逃跑方法,註冊到貓裡面 訂閱一個消息
        }

        public void RunAway()
        {
            Console.WriteLine(color + "的老鼠" + name + "跑跑跑");
        }
    }

  4. 主程式
    class Program {
        static void Main(string[] args) {
            Cat cat = new Cat("CatA", "Yellow");
            Mouse mouse1 = new Mouse("MouseA", "Black", cat);   //把貓加進去
            Mouse mouse2 = new Mouse("MouseB", "Red", cat); 
            Mouse mouse3 = new Mouse("MouseC", "Yellow", cat); 
            Mouse mouse4 = new Mouse("MouseD", "Black", cat);

            cat.CatComing();
        }
    }
*/  