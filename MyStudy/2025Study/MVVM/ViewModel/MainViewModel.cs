using _2025Study.Core;
using _2025Study.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025Study.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToPage002Command { get; set; }


        public MainViewModel(INavigationService newService)
        {
            Navigation = newService;
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>(); }, o => true);  //RelayCommand在 Core/RelayCommand.cs
            NavigateToPage002Command = new RelayCommand(o => { Navigation.NavigateTo<Page002ViewModel>(); }, o => true);

            //NavigateToHomeCommand = new RelayCommand(execute: o:object => { Navigation.NavigateTo<MainViewModel>(); }, canExecute: o:object => true);
            //NavigateToPage002Command = new RelayCommand(execute: o:object => { Navigation.NavigateTo<Page002ViewModel>(); }, canExecute: o:object => true);
        }
    }
}
