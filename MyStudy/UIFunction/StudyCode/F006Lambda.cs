/*
1. Function: Lambda sample code
2. Detail: Find some useful code about how to use lambda.
3. Keyword: [Lambda]
4. Lambda用來代替匿名方法,故 Lambda表達式也是定義一個方法
   => 左邊列出所需參數,一個參數可直接寫 "參數名 =>" ,多參數就用 括號括起來
   => 右邊的函數體語句只有一句時,可不加上大括號,也可不加上return語句
 */

/*
Code area 1: Lambda表達式
  1. Ref: https://www.youtube.com/watch?v=G9DNrr9Mih0&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=21
    a. 匿名方法 改為 lambda表達式 (影片 4:30說明)
    //Func<int, int, int> plus = delegate(int arg1, int arg2)
    //{
    //    return arg1 + arg2;
    //};
    
    // Lambda表達式
    // 不用加方法名,變數不用帶型態,
    Func<int, int, int> plus = (arg1, arg2) =>
    {
        return arg1 + arg2;
    }
    Debug.WriteLine(plus(90,60));   //結果是150

    b.一變數,函數體語句只有一句,不用加 return 語
    Func<int, int> test2 = a => a+1;    //a是一個變數,回傳是a+1;

    c.使用外部變數 (但不建議這樣做,容易被修改)
    int somVal = 5;
    Func<int, int> f = x => x + somVal;
    Debug.WriteLine(f(3)); //結果是8
    somVal = 7;
    Debug.WriteLine(f(3)); //結果是10
*/