using Payment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Payment.Commands
{
    public class ShowGenerateViewCommand : ICommand
    {
        private OrderStatusViewModel _viewModel;
        private PaidOrderViewModel paidOrderViewModel;

        public ShowGenerateViewCommand(OrderStatusViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public ShowGenerateViewCommand(PaidOrderViewModel paidOrderViewModel)
        {
            this.paidOrderViewModel = paidOrderViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter?.ToString() == "PaidView")
            {
                paidOrderViewModel.mainViewModel.SelectedViewModel = new GeneratePaymentViewModel(paidOrderViewModel.mainViewModel);
            }
            else
            {
                _viewModel.mainViewModel.SelectedViewModel = new GeneratePaymentViewModel(_viewModel.mainViewModel);
            }
        }
    }
}
