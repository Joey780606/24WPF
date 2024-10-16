/*
1. Function: Reflection sample code
2. Detail: Find some useful code about how to use Reflection.
3. Keyword: [Reflection]
4. 
 */

/*
Code area 1:
  1. Ref: https://www.youtube.com/watch?v=WwTaK5GJv_k&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=35
    0:50 元數據,反射的說明(1:44)
    2:24 Type類別 (後有例,Type type = my.GetType();)
    3:18 BCL (Base class library)
    3:37 Type是抽象類,無法利用它來實例化對象
    4:17 獲取Type對象
    16:55 通過type對象,可以獲取它對應的類的所有成員 (public)
  2. MyClass.cs
    class MyClass
    {
        private int id;
        private int age;
        public int number;
        public string Name { get; set; }
        public void Test1() {
        }
        public void Test2() {
        }
    }

  3. Program.cs
    class Program {
        static void Main(string[] args) {
            //每一個類,對應一個type對象,此type對象儲存了此類有那些方法,數據,成員
            MyClass my = new MyClass();
            Type type = my.GetType();   //通過對象獲取此對象所屬類別的Type對象, 7:21 可以細看Type裡面有什麼東西
            // Type對象只儲存類的成員,不存類中的數據(比方 MyClass class的 age 值.
            Debug.WriteLine(type.Name); //獲取類的名字
            Debug.WriteLine(type.Namespace); //獲取類的命名空間
            Debug.WriteLine(type.Assembly); //
            
            FieldInfo[] array = type.GetFields();  //只能獲取public字段
            foreach(FieldInfo info in array)
            {
                Debug.WriteLine(info.Name + " ");
            }
            
            Debug.WriteLine("---------------");
            PropertyInfo[] array2 = type.GetProperties();  //獲取 Property
            foreach(PropertyInfo info in array2)
            {
                Debug.WriteLine(info.Name + " ");
            }
            
            Debug.WriteLine("---------------");
            MethodInfo[] array3 = type.GetMethods();  //獲取 Method,會跑出比想像中還多個
            foreach(MethodInfo info in array3)
            {
                Debug.WriteLine(info.Name + " ");
            }
        }
    }
*/