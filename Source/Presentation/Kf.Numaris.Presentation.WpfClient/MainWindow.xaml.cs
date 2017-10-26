using System.Windows;
using Kf.Numaris.Presentation.WpfClient.ViewModel;

namespace Kf.Numaris.Presentation.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationInfoViewModel _applicationInfo;

        public MainWindow(ApplicationInfoViewModel applicationInfo)
        {
            _applicationInfo = applicationInfo;
            InitializeComponent();
        }
    }
}
