using Payment.ViewModels;
using System;
using System.Windows.Input;

namespace Payment.Commands
{
    public class GeneratePaymentCommand : ICommand
    {
        GeneratePaymentViewModel _viewModel;
        QrCodeViewModel qrCodeViewModel;
        public GeneratePaymentCommand(GeneratePaymentViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public GeneratePaymentCommand(QrCodeViewModel qrCodeViewModel)
        {
            this.qrCodeViewModel = qrCodeViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter.ToString() == "view")
            {
                _viewModel.mainViewModel.SelectedViewModel = new OrderStatusViewModel(_viewModel.mainViewModel, "", "");
            }
            else if (parameter.ToString() == "QrCode")
            {
                qrCodeViewModel.mainViewModel.SelectedViewModel = new OrderStatusViewModel(qrCodeViewModel.mainViewModel, "", "");
            }
            else
            {
                _viewModel.mainViewModel.SelectedViewModel = new OrderStatusViewModel(_viewModel.mainViewModel, _viewModel.RequestNumber, _viewModel.Amount);
            }
        }
    }
}
