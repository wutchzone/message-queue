using message_queue.ViewModel;
using System.Windows;

namespace message_queue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindowName_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var _viewModel = (MainViewModel)DataContext;
            if (_viewModel.ClosingCommand.CanExecute(null))
            {
                _viewModel.ClosingCommand.Execute(null);
            }
        }
    }
}
