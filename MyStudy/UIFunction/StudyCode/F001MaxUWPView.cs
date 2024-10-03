/*
1. Function: Maximum UWP form at first.
2. Detail: Normally, UWP can't maximum UI at first, Frank use fulltrust (WPF) to filter the windows,
   find UWP form and maximum it.
3. Keyword: [UWP], [WPF], [Full trust]
4. The code is implement in whe fulltrust (WPF) file.
 */

/*
 Code area:
    public class WinStruct
    {
        public string WinTitle { get; set; } = string.Empty;

        public string WinClassName { get; set; } = string.Empty;
        public int MainWindowHandle { get; set;}
    }

    private delegate bool CallBackPtr(int hwnd, int lParam);    // 建立delegate
    private static CallBackPtr callBackPtr = Callback;          // 宣告delegate變數,在下方有 Callback function
    private static List<WinStruct> _WinStructList = new List<WinStruct>();
    private const int SW_MAXIMIZE = 3;

    [DllImport("User32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool EnumWindows(CallBackPtr lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern int GetClassName(int hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    public static extern bool ShowWindowAsync(nint hWnd, int nCmdShow);

    private const string LAUNCHER_WINDOW_CLASSNAME = "ApplicationFrameWindow";
    private const string LAUNCHER_WINDOW_TITLE = "ONE Launcher";
    private static bool Callback(int hWnd, int lparam)
    {
        StringBuilder windowText = new StringBuilder(256);
        int res = GetWindowText((IntPtr)hWnd, windowText, windowText.Capacity);

        var className = new StringBuilder(512);
        GetClassName(hWnd, className, className.Capacity);

        if (windowText.ToString().Equals(LAUNCHER_WINDOW_TITLE) &&
            className.ToString().Equals(LAUNCHER_WINDOW_CLASSNAME))
        {
            _WinStructList.Add(new WinStruct
            {
                MainWindowHandle = hWnd,
                WinTitle = windowText.ToString(),
                WinClassName = className.ToString(),
            });
        }

        return true;
    }

    private void setLauncherMaxmize()
    {
        _WinStructList = new List<WinStruct>();
        EnumWindows(callBackPtr, IntPtr.Zero);

        if (_WinStructList.Count != 0)
        {
            var w = _WinStructList.FirstOrDefault();
            if (w != null)
            {
                ShowWindowAsync(w.MainWindowHandle, SW_MAXIMIZE);
            }                
        }
    }
 */