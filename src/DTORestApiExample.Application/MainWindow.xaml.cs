using DTORestApiExample.Application.ViewModels;
using System.Windows;

namespace DTORestApiExample.Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        public MainWindow()
        {
            this.Close();
        }
    }
}
