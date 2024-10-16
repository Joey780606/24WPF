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
        return string.Format("Id:{0} , Name:{0} , Age:{0} , Menpai:{0} , Kongfu:{0} , Level:{0}", Id, Name, Age, Menpai, Kongfu, Level);
    }
  }

  3. Kongfu.cs
  class Kongfu {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Power { get; set; }
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