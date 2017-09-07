using System.Threading;
using System.Windows;
using System.Windows.Threading;
using DispatcherFrame = System.Windows.Threading.DispatcherFrame;

namespace Dispatcher_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _counter = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Wait(this.Dispatcher, 10000);
            //Thread.Sleep(5000);
            //await Task.Delay(2000);
            statusLabel.Content = "Button was clicked " + _counter++ + " times!";
        }

        public static void Wait(System.Windows.Threading.Dispatcher Dispatcher, int Milliseconds)
        {
            var Frame = new DispatcherFrame();

            ThreadPool.QueueUserWorkItem(State =>
            {
                Thread.Sleep(Milliseconds);
                Frame.Continue = false;
            });

            MessageBox.Show("Complete!");
            Dispatcher.PushFrame(Frame);
            MessageBox.Show("Complete 2!");

        }

    }
}
