using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2025Study.Core
{
    public class ObservableObject : INotifyPropertyChanged  //參1: 8:29
    {
        public event PropertyChangedEventHandler? PropertyChanged;  //INotifyPropertyChanged 本身有的 EventHandler

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)    //這個需要用 virtual 
        {
            PropertyChanged?.Invoke(this , e:new PropertyChangedEventArgs(propertyName));
        }

        //protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        //{
        //    if(EqualityComparer<T>.Default.Equals(x:field, y:value))
        //        return false;
        //    field = value;
        //    OnPropertyChanged(propertyName);
        //    return true;
        //}
    }
}
