using Payment.ViewModels;
using System;
using System.Windows.Input;

namespace Payment.Commands
{
    public class GeneratePaymentCommand : ICommand
    {
        GeneratePaymentViewModel _viewModel;
        public GeneratePaymentCommand(GeneratePaymentViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.mainViewModel.SelectedViewModel = new OrderStatusViewModel(_viewModel.mainViewModel);
        }
    }
}
