using Payment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Payment.Commands
{
    public class DetailOrderCommand : ICommand
    {
        private QrCodeViewModel _viewModel;

        public DetailOrderCommand(QrCodeViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.mainViewModel.SelectedViewModel = new PaidOrderViewModel(_viewModel.mainViewModel, _viewModel.DataOrder);
        }
    }
}
