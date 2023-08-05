using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Payment.Views
{
    public class BaseUserControl: UserControl
    {
        private Window _currentWindow = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseUserControl"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public BaseUserControl()
        {
            _currentWindow = Window.GetWindow(this);
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        protected void CloseWindow()
        {
            _currentWindow = Window.GetWindow(this);
            _currentWindow.Close();
        }
    }
}
