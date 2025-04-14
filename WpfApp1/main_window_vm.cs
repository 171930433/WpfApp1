using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand ClickCommand { get; }
        private string _textBoxContent;
        public string TextBoxContent
        {
            get => _textBoxContent;
            set
            {
                _textBoxContent = value;
                OnPropertyChanged();
                // 通知命令状态更新
                (ClickCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


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
            return string.IsNullOrEmpty(TextBoxContent) == false;
        }
    }


}
