using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kf.Numaris.Presentation.WpfClient.ViewModel;

namespace Kf.Numaris.Presentation.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationInfoViewModel _applicationInfo;
        private TabControl _tabControl;

        public MainWindow(ApplicationInfoViewModel applicationInfo)
        {
            _applicationInfo = applicationInfo;
            InitializeComponent();

            BuildTabControl(applicationInfo);
        }

        private void BuildTabControl(ApplicationInfoViewModel applicationInfo)
        {
            _tabControl = new TabControl();

            _tabControl.Items.Add(new TabItem
            {
                Header = new Label { Content = "ApplicationInfo" }
            });

            applicationInfo.NumberSpecifications.ToList().ForEach(numberSpecification =>
            {
                _tabControl.Items.Add(new TabItem
                {
                    Header = new Label { Content = numberSpecification.Identifier.Name }
                });
            });

            this.Content = _tabControl;
        }
    }
}
