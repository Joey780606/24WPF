/*
1. Function: UI design in the office
2. Detail: Watch more samples, record the points to accumulated the experiences.
3. Keyword: [XAML] [UI]
 */

/*
Code area 1: (看完一遍)
  1. Ref: https://www.youtube.com/watch?v=pZGcRHgmn8k (他後面還有三堂課)
  2. 課程重點:
    0:59 加入圖片(我沒有他的圖)
    1:13 建立Model, View, ViewModel目錄; 1:25 View目錄建LoginView.xaml的Window; 1:37 App.xaml改成 StartupUri="View/LoginView.xaml
    3:04~3:48 
    4:03 StackPanel,DockPanel, Grid, WrapPanel, Canvas
    5:20 Border, Window
    6:59 有用Auto Color Picker的工具
    9:00 設定背景圖(Background Image)
    12:50 視窗最小化的處理 WindowState = WindowState.Minimized;
    13:37 關閉app: Application.Current.Shutdown();
    14:46 <Style.Triggers> 對控制元件的UI行為, ex: Mouse滑過(IsMouseOver),
  3. 分項重點
    a. XAML: Border: 5:20, 6:08~9:17,可設定某區域的背景,變成半圓邊角
    b. XAML: Window: 5:50~6:00
    c. XAML: LinearGradientBrush: 6:27~8:16, 非常好的說明
    d. XAML: ImageBrush: 9:17, 20:28
    e. XAML: Grid: 10:00~11:13, 有一樣重要
    f. XAML: TextBlock: 11:13~11:56, 17:25~18:53 (18:06 TextWrapping 重要)
    g. XAML: Button: 11:56~14:00
    h. XAML: Style: 14:13
    i. XAML: Template (ControlTemplate, TemplateBinding, ContentPresenter): 15:08~16:20 極重要
    j. XAML: StackPanel 16:38
    k. XAML: Image 17:19
    l. XAML: TextBox 18:57~19:25 (19:25 CaretBrush, 19:37 BorderThickness="0,0,0,5", 19:50 VerticalContentAlignment="Center"), 24:12 (Cursor="Hand")
        20:24 TextBox.Background, 21:00,重要,若太複雜的設計,可以直接拉出來改
    m. XAML: PasswordBox 21:51
*/

/*
Code area 2: 
  1. Ref: https://www.youtube.com/watch?v=FGqj4q09NtA 
  2. 課程重點:
  3. 分項重點
*/

/*
Code area 3: 
  1. Ref: https://www.youtube.com/watch?v=kxhvwGEqvcs
  2. 課程重點:
  3. 分項重點:
*/

/*
Code area 4: 
  1. Ref: https://www.youtube.com/watch?v=76JLBZJR5gE
  2. 課程重點:
  3. 分項重點:
*/

/*
Code area 5: 
  Adoptive UI with ExpressionBlend in UWP Windows 10
  1. Ref: https://www.youtube.com/watch?v=Yp8gKEKSISw
  2. 課程重點:
  3. 分項重點:
 看到1:24
*/

/*
Code area 6: 
  WPF - Responsive UI Design
  1. Ref: https://www.youtube.com/watch?v=EfXz4C5cSVI
  2. 課程重點:
    2:01 建立專案
    5:31~5:50 建Assets目錄,放圖
    6:00 將寫好的 DataTemplate.xaml, Styles.xaml放入 (重要,需要下載)
    6:18 建立ViewModel目錄,並放入預設好的檔案
    6:42~11:40 建立Helper目錄,並新增Converter class (小於,大於的判斷)
  3. 分項重點: (X: 表示XAML)
    a. 2:38~3:47 X: 設定Window值, WindowsStyle="None", AllowsTransparency="True", ResizeMode="CanResizeWithGrip"
      WindowStartupLocation="CenterScreen", Background="Transparent"
       4:50 設定 MinWidth (這樣畫面寬度只能縮到此值)
    b. 3:50~4:39 X: Border
    c. 重要的class
      1. 8:16 IValueConverter
      2. 9:29 CultureInfo
 看到2:46
*/

/*
Code area 7: 
    1.https://www.youtube.com/watch?v=ptvAfFZm4BE
    完整的範例(MVVM data binding),但有用到外部dll, 只是在github有放此檔
    0:50 UML圖(金錢抽屜)
    1:58 加入 CashRegister.dll(有附github位址)(加入Reference)
    3:20 建立View, ViewModel
      3:36 建立CashRegisterModelView.cs
      4:01 INotifyPropertyChanged interface (語法: using System.ComponentModel;)
    5:00 使用 CashRegister.dll
    6:55 簡易寫法, (重要)
       public double TotalValue => drawer.TotalValue;
    相同於
        public double TotalValue
    {
        get
        {
            return TotalValue;
        }
    }
    7:50 如上述方式, 設定 Pennies,
    11:40 任何錢的改變, 都可能會影響到總現金金額, 所以作者加了函式:
       Joey猜是呼喚值的變化, 比方Pennies值改變, 總現金也改變, 就要Invoke這二個改變的event handler
       void InvokePropertyChanged(string denomination) {   //這在13:55 會呼叫到,重要
       }
    14:17 如上述7: 50 Pennies方式, 設定像Fiftys, Hundreds等各值
    14:56~16:37 介紹 UI畫面, 作者想要的 (紙鈔, 硬幣的圖案)
    16:53 加入User control UI (新元件) CoinControl
      18:08 dependency property
        20:41 第四個參數, metadata, 他是用 PropertyMetadata(Coins.Penny_
        21:16 backing variable(有聽過, 但要查是什麼)
        22:44 GetValue 時回傳的屬性是object, 所以要轉成想要的型態
        23:00~24:00 的描述很重要
          23:20 使用 dependency property的好處(我們可以查google找詳細原因)..
        24:09 建另一個 DependencyProperty QualityProperty
          25:03 第四個參數設為: new FrameworkPropertyMetaData(0, FrameworkPropertyMetadataOptions.BindsTwoWaybyDefault)  //要研究第四個參數,作者說是雙向綁定
        26:44~27:10 set => 的用法也要學, get
    21:02 解決Coins的錯誤,(因沒有using CoinRegister 命名空間
    27:51 設定User control的前端UI
        Border (Padding) 28:48~29:38, 31:46~(為了畫圓)
        29:55 Grid, ColumnDefinition
        Binding: 33:32~35:20(RelativeSource, FindAncestor, AncestorType(很重要)
           36:25 RelativeSource, FindAncestor, AncestorType
        Button: 35:23~36:00, 37:06~37:28
        TextBox: 36:01
        CoinControl.xaml.cs(UserControl) 37:36(建立按鍵callback, + , -)
        38:37 編譯
    39:30 建另一個UserControl, CashRegisterControl.xaml.cs
        Grid: 41:15
        StackPanel: 41:25
        42:30~44:22  加入多個 CoinControl
        Binding 43:00 將 CoinControl 新參數都加入(Denomination, Quantity)(UI有將整個元件加入)
          43:14 發現CoinControl UI有錯, 再去修改
    44:41 MainWindow.xaml
        45:12 設定DataContext, 設定ViewModel
*/