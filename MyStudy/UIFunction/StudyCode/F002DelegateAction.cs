/*
1. Function: Delegate Action sample code
2. Detail: Find some useful code about how to use Delegate Action.
3. Keyword: [Delegate], [Action]
4. Action是不會回傳值的.
 */

/*
 Code area 1:

    public int FanSpeed
    {
        get => SelectedFanMode.Speed;
        set
        {
            //重點1: Action + Lambda表示法, 把函式當參數放進去
            //會這樣做是因為有很多地方會用到delegate Action,只有部分處理會不一樣,所以可用些方式,把不同處放在function裡,相同處在此處理,可以省code (猜測)
            CheckFanSpeedSetting(value, SelectedFanMode.Speed, (int newValue) =>
            {
                SelectedFanMode.Speed = newValue;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FanSpeedString));
                _database.UpdateFanMode(SelectedFanMode);
                ApplyFanControl();
            });                
        }
    }

    //重點2: CheckFanSpeedSetting, 注意 Action的使用法,和setFanSpeedAction 的使用
    private async void CheckFanSpeedSetting(int newValue,int oldValue, Action<int> setFanSpeedAction)
    {
        int valueToSet = newValue;

        if (valueToSet < minFanSpeed)
        {
            var zotacSettings = ServiceProviderHelper.GetZotacSettings();
            ...//中間省略                          
        }

        setFanSpeedAction(valueToSet);
    }
*/