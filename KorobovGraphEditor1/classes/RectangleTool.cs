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
    public class RectangleTool : DrawingTool
    {
        private Rectangle _currentRectangle;
        private Point _startPoint;

        public override void OnMouseDown(Point position)
        {
            _startPoint = position;
            _currentRectangle = new Rectangle
            {
                Stroke = Stroke,
                StrokeThickness = StrokeThickness,
                Fill = Brushes.Transparent
            };
            Canvas.SetLeft(_currentRectangle, position.X);
            Canvas.SetTop(_currentRectangle, position.Y);
        }

        public override void OnMouseMove(Point position)
        {
            if (_currentRectangle != null)
            {
                double width = position.X - _startPoint.X;
                double height = position.Y - _startPoint.Y;

                Canvas.SetLeft(_currentRectangle, width < 0 ? position.X : _startPoint.X);
                Canvas.SetTop(_currentRectangle, height < 0 ? position.Y : _startPoint.Y);

                _currentRectangle.Width = Math.Abs(width);
                _currentRectangle.Height = Math.Abs(height);
            }
        }

        public override void OnMouseUp(Point position)
        {
        }
        public override Shape GetShape()
        {
            return _currentRectangle;
        }
    }
}
