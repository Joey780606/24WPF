/*
1. Function: Abstract factory design pattern
2. Detail: Find some documents and related code.
3. Keyword:
4. 
 */

/*
1. 中文說明:
  https://www.youtube.com/watch?v=L4TD6psvGn4
  說明內容: 
  1. 情境: 有個辨識產品的Library(有分跑CPU和GPU),如何設計可臨時互換成跑CPU或GPU呢?
    Joey心得: 像是二層(或多層) interface, 一個interface是為了 Product檢查器
  2. 程式:
    //3:13
    var product = new Product() { Name = "C300" };

    IProductInspectorFactory factory = new CPUProductInspectorFactory();    //如果想換回GPU, 就改成 GPUProductInspectorFactory
    ProductService productService = new ProductService(factory);

    productService.Inspect(product);    

    class Product   //0:26
    {
        public string Name { get; set; }
    }

    interface IProductInspector //0:33
    {
        string Inspector(Product product);
    }

    class CPUProductInspector: IProductInspector    //0:45
    {
        public string Inspector(Product product)
        {
            return $"product name: {product.Name}, result by cpu";
        }
    }

    class GPUProductInspector: IProductInspector    //1:02
    {
        public string Inspector(Product product)
        {
            return $"product name: {product.Name}, result by gpu";
        }
    }

    interface IProductInspectorFactory //1:20, 建立抽象工廠
    {
        IProductInspector CreateProductInspector(); // IProductInspector 是在前面宣告的 interface
    }

    class CPUProductInspectorFactory: IProductInspectorFactory  //2:28
    {
        public IProductInspector CreateProductInspector()
        {
            return new CPUProductInspector();   //這是CPU
        }
    }

    class GPUProductInspectorFactory: IProductInspectorFactory  //2:47
    {
        public IProductInspector CreateProductInspector()
        {
            return new GPUProductInspector();   //這是GPU
        }
    }

    class ProductService // 1:38 建立給其他工程師使用的模組
    {
        private readonly IProductInspectorFactory _productInspectorFactory;
        // 1:48 右鍵選DI進來,不是很懂

        public ProductService(IProductInspectorFactory productInspectoryFactory)
        {
            _productInspectorFactory = productInspectoryFactory;
        }

        public void Inspect(Product product)   //1:48 辨識的方法
        {
            var result = _productInspectorFactory.CreateProductInspector().Inspector(product);
            Console.WriteLine("save result to db ...");
            Console.WriteLine(result);
        }
    }
*/