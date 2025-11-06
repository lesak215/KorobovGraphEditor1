using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace KorobovGraphEditor1.classes
{
    public class LineTool : DrawingTool
    {
        private Line _currentLine;
        private Point _startPoint;

        public override void OnMouseDown(Point position)
        {
            _startPoint = position;
            _currentLine = new Line
            {
                X1 = position.X,
                Y1 = position.Y,
                X2 = position.X,
                Y2 = position.Y,
                Stroke = Stroke,
                StrokeThickness = StrokeThickness
            };
        }

        public override void OnMouseMove(Point position)
        {
            if (_currentLine != null)
            {
                _currentLine.X2 = position.X;
                _currentLine.Y2 = position.Y;
            }
        }

        public override void OnMouseUp(Point position)
        {
        }

        public override Shape GetShape()
        {
            return _currentLine;
        }
    }
}
