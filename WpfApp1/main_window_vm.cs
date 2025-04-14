using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class MainViewModel
    {
        public ICommand ClickCommand { get; }

        public MainViewModel()
        {
            // 初始化命令
            ClickCommand = new RelayCommand(ExecuteClick, CanExecuteClick);
        }

        private void ExecuteClick(object parameter)
        {
            // 执行的逻辑
            System.Windows.MessageBox.Show("Button clicked! "+ parameter);
        }

        private bool CanExecuteClick(object parameter)
        {
            // 决定命令是否可以执行
            return true; // 返回 false 时，按钮会被禁用
        }
    }


}
