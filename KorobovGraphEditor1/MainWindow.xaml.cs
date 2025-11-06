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
using static KorobovGraphEditor1.classes.ToolManager;

namespace KorobovGraphEditor1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToolManager _toolManager;
        private DrawingTool _currentDrawingTool;
        private bool _isDrawing = false;
        private FileService _fileService;
        private Brush _currentColor = Brushes.Black;
        
        public MainWindow()
        {
            InitializeComponent();
            InitializeToolManager();
            InitializeDrawingTools();
            InitializeFileService();
            CurrentColorPreview.Fill = _currentColor;
            ColorComboBox.SelectedIndex = 0;
        }

        private void InitializeFileService()
        {
            _fileService = new FileService();
        }
        private void InitializeToolManager()
        {
            _toolManager = new ToolManager();

            _toolManager.RegisterToolButton(PencilToolButton, ToolManager.Tools.Pencil);
            _toolManager.RegisterToolButton(LineToolButton, ToolManager.Tools.Line);
            _toolManager.RegisterToolButton(RectangleToolButton, ToolManager.Tools.Rectangle);
            _toolManager.RegisterToolButton(EllipseToolButton, ToolManager.Tools.Ellipse);

            _toolManager.SetDefaultTool();
        }
        private void InitializeDrawingTools()
        {
            DrawingCanvas.MouseDown += DrawingCanvas_MouseDown;
            DrawingCanvas.MouseMove += DrawingCanvas_MouseMove;
            DrawingCanvas.MouseUp += DrawingCanvas_MouseUp;
        }

        private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _isDrawing = true;
                var position = e.GetPosition(DrawingCanvas);

                _currentDrawingTool = CreateToolFromType(_toolManager.CurrentTool);
                _currentDrawingTool.OnMouseDown(position);

                DrawingCanvas.Children.Add(_currentDrawingTool.GetShape());
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing && _currentDrawingTool != null)
            {
                var position = e.GetPosition(DrawingCanvas);
                _currentDrawingTool.OnMouseMove(position);
            }
        }

        private void DrawingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDrawing && _currentDrawingTool != null)
            {
                var position = e.GetPosition(DrawingCanvas);
                _currentDrawingTool.OnMouseUp(position);
                _isDrawing = false;
                _currentDrawingTool = null;
            }
        }
        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                _currentColor = selectedItem.Background;
                CurrentColorPreview.Fill = _currentColor;
            }
        }

        private DrawingTool CreateToolFromType(ToolManager.Tools toolType)
        {
            DrawingTool tool;

            switch (toolType)
            {
                case ToolManager.Tools.Pencil:
                    tool = new PencilTool();
                    break;
                case ToolManager.Tools.Line:
                    tool = new LineTool();
                    break;
                case ToolManager.Tools.Rectangle:
                    tool = new RectangleTool();
                    break;
                case ToolManager.Tools.Ellipse:
                    tool = new EllipseTool();
                    break;
                default:
                    tool = new PencilTool();
                    break;
            }

            tool.Stroke = _currentColor;
            return tool;
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DrawingCanvas.Children.Count == 0)
            {
                MessageBox.Show("Нет элементов для сохранения", "Информация",
                               MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                _fileService.SaveCanvasToPng(DrawingCanvas);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                               MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
    

