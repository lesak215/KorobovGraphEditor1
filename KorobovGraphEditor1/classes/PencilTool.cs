using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace KorobovGraphEditor1.classes
{ 
    public class PencilTool : DrawingTool
    {
        private Polyline _currentLine;

        public override void OnMouseDown(Point position)
        {
            _currentLine = new Polyline
            {
                Stroke = Stroke,
                StrokeThickness = StrokeThickness
            };
            _currentLine.Points.Add(position);
        }

        public override void OnMouseMove(Point position)
        {
            if (_currentLine != null)
            {
                _currentLine.Points.Add(position);
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