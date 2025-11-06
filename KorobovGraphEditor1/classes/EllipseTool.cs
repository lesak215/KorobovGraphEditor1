using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KorobovGraphEditor1.classes
{
    public class EllipseTool : DrawingTool
    {
        private Ellipse _currentEllipse;
        private Point _startPoint;

        public override void OnMouseDown(Point position)
        {
            _startPoint = position;
            _currentEllipse = new Ellipse
            {
                Stroke = Stroke,
                StrokeThickness = StrokeThickness,
                Fill = Brushes.Transparent
            };
            Canvas.SetLeft(_currentEllipse, position.X);
            Canvas.SetTop(_currentEllipse, position.Y);
        }

        public override void OnMouseMove(Point position)
        {
            if (_currentEllipse != null)
            {
                double width = position.X - _startPoint.X;
                double height = position.Y - _startPoint.Y;

                Canvas.SetLeft(_currentEllipse, width < 0 ? position.X : _startPoint.X);
                Canvas.SetTop(_currentEllipse, height < 0 ? position.Y : _startPoint.Y);

                _currentEllipse.Width = Math.Abs(width);
                _currentEllipse.Height = Math.Abs(height);
            }
        }

        public override void OnMouseUp(Point position)
        {
        }

        public override Shape GetShape()
        {
            return _currentEllipse;
        }
    }

}
