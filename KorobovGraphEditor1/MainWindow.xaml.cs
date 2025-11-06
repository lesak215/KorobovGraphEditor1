using KorobovGraphEditor1.classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KorobovGraphEditor1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToolManager _toolManager;
        private void InitializeToolManager()
        {
            _toolManager = new ToolManager();

            _toolManager.RegisterToolButton(PencilToolButton, ToolManager.Tools.Pencil);
            _toolManager.RegisterToolButton(LineToolButton, ToolManager.Tools.Line);
            _toolManager.RegisterToolButton(RectangleToolButton, ToolManager.Tools.Rectangle);
            _toolManager.RegisterToolButton(EllipseToolButton, ToolManager.Tools.Ellipse);

            _toolManager.SetDefaultTool();
        }
        public MainWindow()
        {
            InitializeComponent();
            InitializeToolManager();
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Реализация в процессе.");
        }
    }
}
    

