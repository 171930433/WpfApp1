using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{

    public class MyStudent
    {
        public int MyAge{ get; set; }     



    }

    /// <summary>
    /// MyUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class MyUserControl : UserControl
    {
        public ICommand ClickCommand2 { get; }

        public MyUserControl()
        {
            InitializeComponent();

            ClickCommand2 = new RelayCommand(MyButton_Click1);

            this.DataContext = this;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("MyUserControl click");
        }

        private void MyButton_Click1(object sender)
        {
            MessageBox.Show("MyUserControl click");
        }
    }
}
