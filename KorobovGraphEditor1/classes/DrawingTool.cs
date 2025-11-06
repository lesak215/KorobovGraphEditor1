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
    public abstract class DrawingTool
    {
        public Brush Stroke { get; set; } = Brushes.Black;
        public double StrokeThickness { get; set; } = 2;

        public abstract void OnMouseDown(Point position);
        public abstract void OnMouseMove(Point position);
        public abstract void OnMouseUp(Point position);
        public abstract Shape GetShape();
    }
}