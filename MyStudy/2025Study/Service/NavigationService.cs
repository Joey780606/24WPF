using _2025Study.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025Study.Service
{

    public interface INavigationService  //9:37:00
    {
        ViewModel CurrentView {  get; } //這是專案的 Core > ViewModel
        void NavigateTo<T>() where T : ViewModel;
    }

    public class NavigationService : ObservableObject, INavigationService   //在Core裡面的 ObservableObject
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;
        private ViewModel _currentView;
        public ViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel  //12:00
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel)); //Delegate可用Invoke的方式處理
            CurrentView = viewModel;
        }
    }
}
