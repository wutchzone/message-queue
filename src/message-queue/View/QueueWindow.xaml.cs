using message_queue.ViewModel;
using System.Windows;

namespace message_queue.View
{
    /// <summary>
    /// Interaction logic for QueueWindow.xaml
    /// </summary>
    public partial class QueueWindow : Window
    {
        public QueueWindow()
        {
            InitializeComponent();
            (this.DataContext as QueueViewModel).NumberOfElements = int.Parse(FindResource("NumberOfElements").ToString());
        }
    }
}
