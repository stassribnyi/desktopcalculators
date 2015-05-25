using System.ComponentModel;
using FirstFloor.ModernUI.Windows.Controls;
using Serializator.Containers;
using Serializator.Serializators;

namespace Octagon.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        private const string Path = @"..\..\data.dat";
        private BinarySerializator<HistoryAndMemoryContainer> _serializator;

        public MainWindow()
        {
            _serializator = new BinarySerializator<HistoryAndMemoryContainer>();
            Manager.HistoryAndMemoryContainer = _serializator.Deserialize(Path);

            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _serializator = _serializator ?? new BinarySerializator<HistoryAndMemoryContainer>();

            if (Manager.HistoryAndMemoryContainer != null)
            {
                _serializator.Serialize(Path, Manager.HistoryAndMemoryContainer);
            }
        }
    }
}
