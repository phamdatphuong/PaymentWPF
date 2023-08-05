using Payment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Payment.Commands
{
    public class ShowQrCodeCommand : ICommand
    {
        OrderStatusViewModel _viewModel;
        public ShowQrCodeCommand(OrderStatusViewModel viewModel)
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
            _viewModel.mainViewModel.SelectedViewModel = new QrCodeViewModel(_viewModel.mainViewModel);
        }
    }
}
