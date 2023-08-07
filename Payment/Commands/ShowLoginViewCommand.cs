using Payment.ViewModels;
using System;
using System.Windows.Input;

namespace Payment.Commands
{
    public class ShowLoginViewCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        MainViewModel mainViewModel;
        public ShowLoginViewCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            mainViewModel.SelectedViewModel = new LoginViewModel(mainViewModel);
        }
    }
}
