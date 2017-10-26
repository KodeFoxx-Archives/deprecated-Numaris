using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Kf.Numaris.Api.Specifications.Numbers;
using Kf.Numaris.Presentation.WpfClient.ViewModel;

namespace Kf.Numaris.Presentation.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
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
                Header = "ApplicationInfo",
                Content = new Label { Content = "ApplicationInfo todo..." }
            });

            AddNumberSpecificationTabs(applicationInfo.NumberSpecifications);

            this.Content = _tabControl;
        }

        private void AddNumberSpecificationTabs(IEnumerable<INumberSpecification> numberSpecifications)
        {
            numberSpecifications.ToList().ForEach(numberSpecification =>
            {
                _tabControl.Items.Add(new TabItem
                {
                    Header = numberSpecification.Identifier.Name,
                    Content = new Label { Content = $"'{numberSpecification.Identifier.Id}' todo..." }
                });
            });
        }
    }
}
