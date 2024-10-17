/*
1. Function: Linq
2. Detail: Find some useful code about how to use linq
3. Keyword: [linq], [Action]
4. 
 */

/*
Code area 1:
  1. Ref: https://www.youtube.com/watch?v=84KsfXozui8&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=25
  2. MartialArtsMaster.cs
  class MartialArtsMaster {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Menpai { get; set; }
    public string Kongfu { get; set; }
    public int Level { get; set; }

    public override string ToString() {
    {
        return string.Format("Id:{0} , Name:{1} , Age:{2} , Menpai:{3} , Kongfu:{4} , Level:{5}", Id, Name, Age, Menpai, Kongfu, Level);
    }
  }

  3. Kongfu.cs
  class Kongfu {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Power { get; set; }

    public override string ToString() {
    {
        return string.Format("Id:{0} , Name:{1} , Age:{2}", Id, Name, Power);
    }
  }

  4. Program.cs
  class Program {
    static void Main(string[] args) {
        var masterList = new List<MartialArtsMaster> () 
        {
            new MartialArtsMaster() {Id = 1, Name = "AA", Age = 18, Menpai = "AAA", Kongfu = "AAAA", Level = 9},
            new MartialArtsMaster() {Id = 2, Name = "BB", Age = 70, Menpai = "AAA", Kongfu = "AAAA", Level = 10}
        };

        var kongfu = new List<Kongfu>()
        {
            new Kongfu() {Id = 1, Name = "AAAA", Age = 18, Power = 90},
            new Kongfu() {Id = 2, Name = "BBBB", Age = 18, Power = 95}
        };

        // 傳統做法: 查詢所有武學級別>8的武林高手 
        var res = new List<MartialArtsMaster>();
        foreach (var temp in masterList)
        {
            if(temp.Level > 8)
                res.Add(temp);
        }

        foreach (var temp in res)
        {
            Debug.WriteLine(temp);
        }
        
        // 用LINQ來做查詢
        var res = from m in masterList  //from後設定查詢的集合
            where m.Level > 8   //where後跟上查詢的條件
            select m;   //返回m的結果, 若純要名字,也可寫 select m.Name;
        foreach (var temp in res)
        {
            Debug.WriteLine(temp);
        }
    }
  }
*/

/*
Code area 2: 擴展方法,表達式寫法 (where)
  1. Ref: https://www.youtube.com/watch?v=yjIrcCtPukg&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=26
  2. MartialArtsMaster.cs, Kongfu.cs 皆與上方 Code area 1 一致
  3. Program.cs
  class Program {
    static void Main(string[] args) {
        var masterList = new List<MartialArtsMaster> () 
        {
            new MartialArtsMaster() {Id = 1, Name = "AA", Age = 18, Menpai = "AAA", Kongfu = "AAAA", Level = 9},
            new MartialArtsMaster() {Id = 2, Name = "BB", Age = 70, Menpai = "AAA", Kongfu = "AAAA", Level = 10}
        };

        var kongfu = new List<Kongfu>()
        {
            new Kongfu() {Id = 1, Name = "AAAA", Age = 18, Power = 90},
            new Kongfu() {Id = 2, Name = "BBBB", Age = 18, Power = 95}
        };

        // 1. 擴展方式寫法
        var res = masterList.Where(Test1);  
        // where ref: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where?view=net-8.0
        // Where<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)  //後面的Func 是 delegate, 可指定一個函式,其參數是TSource,回傳值是Boolean值

        // 2. 把他變成Lambda表達式
        var res = masterList.Where(m => m.Level > 8);

        // 3. 多個判斷式
        // a. 用LINQ來做查詢
        var res = from m in masterList  //from後設定查詢的集合
            where m.Level > 8 && m.Menpai=="AAA"  //where後跟上查詢的條件,利用 && 添加多樣條件
            select m;   //返回m的結果, 若純要名字,也可寫 select m.Name;
        // b. 並列表達式
        var res = masterList.Where(m => m.Level > 8 && m.Menpai=="AAA");

        foreach (var temp in res)
        {
            Debug.WriteLine(temp);
        }
    }
  }

    static bool Test1(MartialArtsMaster master) //回傳bool是過濾方法,檢查有無符合需求
    {
        if(master.Level > 8) 
            return true;
        return false;
    }
*/

/*
Code area 3: 集合聯合查詢 (二個list整合在一起做比較)
  1. Ref: https://www.youtube.com/watch?v=t1_qSTEJ6gI&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=27
  2. MartialArtsMaster.cs, Kongfu.cs 皆與上方 Code area 1 一致
  3. Program.cs
  class Program {
    static void Main(string[] args) {
        var masterList = new List<MartialArtsMaster> () 
        {
            new MartialArtsMaster() {Id = 1, Name = "AA", Age = 18, Menpai = "AAA", Kongfu = "AAAA", Level = 9},
            new MartialArtsMaster() {Id = 2, Name = "BB", Age = 70, Menpai = "AAA", Kongfu = "AAAA", Level = 10}
        };

        var kongfu = new List<Kongfu>()
        {
            new Kongfu() {Id = 1, Name = "AAAA", Age = 18, Power = 90},
            new Kongfu() {Id = 2, Name = "BBBB", Age = 18, Power = 95}
        };

        // 1. (影片3:30) LINQ 聯合查詢
        var res = from m in masterList
            from k in kongfuList
            select new {master = m, kongfu = k);    //這樣會列出二個list合併的所有的資料

        // 2. (影片6:20) 加入二個 list 相同名稱的判斷,這樣可以減少輸出的資料
        var res = from m in masterList
            from k in kongfuList
            where m.Kongfu == k.Name
            select new {master = m, kongfu = k);   

        // 3. (影片7:00)  
        // 取得所學功夫的殺傷力, > 90的武林高手
        var res = from m in masterList
            from k in kongfuList
            where m.Kongfu == k.Name && k.Power > 90
            select m;

        foreach (var temp in res)
        {
            Debug.WriteLine(temp);
        }
    }
  }
*/