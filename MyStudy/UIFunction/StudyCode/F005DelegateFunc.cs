/*
1. Function: Delegate Func sample code
2. Detail: Find some useful code about how to use delegate func.
3. Keyword: [Delegate] [func]
4. Func 是可以回傳值的 delegate
 */


/*
 Code area 1: Func 委托
  1. Ref: https://www.youtube.com/watch?v=W2EDHXYF8XM&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=77
    0:18 Action, Func委托的樣式
    0:41 Func要有返回值,放在最後面,傳遞0~16個參數類型,和一個返回類型
    7:39 PPT說明

    a. 程式1: Program.cs
    class Program {
        static int Test1()
        {
            return 1;
        }

        static int Test2(string str) {
            Debug.WriteLine(str);
            return 100;
        }

        static int Test3(int i, int j) {
            return i + j;
        }

        static void Main(string[] args) {
            Func<int> a = Test1;    //後面不要加(), Func裡的int是方法的返回值類型
            Console.WriteLine(a());

            Func<string, int> b = Test2;    //Func後可跟很多類型,最後一個類型是返回值類型

            Func<int, int, int> a = Test3;
            int res = a(1,5);
        }
    }
*/

/*
Code area 2: 通用類別的冒泡排序法 [Generic]
  1. Ref: https://www.youtube.com/watch?v=bzw-0k8LbXg&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=17
    a. Employee 類
    class Employee {
        public string Name {get; private set; } //將set設為私有方法
        public int Salary {get; private set; }

        public Employee(string name, int salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public static bool Compare(Employee e1, Employee e2) {   //比較大小
            if(e1.Salary > e2.Salary)
                return true;
            else
                return false;
        }

        public override string ToString() { // override 原有的方法
            return Name + "." + salary;
        }
    }

    b. 排序方法
    static void CommonSort<T> (T[] sortArray, Func<T,T,bool> compareMethod) { 
    //T泛型,要排序的方法, 參1: 要排序的Array, 參2: 比較方法,前二個T是要比較的對象,bool是回傳是否大(小)於的值)
        bool swapped = true;
        do {
            swapped = false;
            for (int i = 0; i < sortArray.Length -1; i++) {
                if(compareMethod(sortArray[i], sortArray[i + 1])) {
                    T temp = sortArray[i];
                    sortArray[i] = sortArray[i + 1];
                    sortArray[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }

    c. Main裡
    static void Main(string[] arrgs) {
        Employee[] employees = new Employee[] {
            new Employee("Joey",999),
            new Employee("Pitt",997),
            new Employee("Max",998)
        };
        CommonSort<Employee>(employees, Employee.Compare);  //重要
        foreach (Employee em in employees)
            Debug.WriteLine(em); //ToString 這是系統默認方法,但我們可以override
        Debug.ReadKey();
    }
*/

/*
Code area 3: 匿名方法
  1. Ref: https://www.youtube.com/watch?v=S-sKhKCkl4g&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=19
    a. 
    static int Test1(int arg1, int arg2)
    {
        return arg1 + arg2;
    }

    static void Main(string[] args)
    {
        // 下方是正常用法
        //Func<int, int, int> plus = Test1; //二個輸入值,一個返回值
        
        // 匿名方法(沒名字的方法) (重要),通常會用來做一些callback
        // 匿名方法 本質上是一個方法,只是沒名字,任何使用委託變量的地方,都可使用匿名方法賦值
        Func<int, int, int> plus = delegate(int arg1, int arg2)
        {
            return arg1 + arg2;
        };
        Console.ReadKey();
    }

*/
