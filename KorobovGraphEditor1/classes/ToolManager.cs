using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace KorobovGraphEditor1.classes
{
    public class ToolManager
    {
        private readonly List<ToggleButton> _toolButtons;
        private Tools _currentTool;

        public enum Tools
        {
            Pencil,
            Line,
            Rectangle,
            Ellipse
        }
        public ToolManager()
        {
            _toolButtons = new List<ToggleButton>();
            _currentTool = Tools.Pencil;
        }
        public Tools CurrentTool => _currentTool;

        public void RegisterToolButton(ToggleButton button, Tools toolType)
        {
            _toolButtons.Add(button);
            button.Checked += (sender, eventargs) => OnToolButtonCheked(button, toolType);
        }
        private void OnToolButtonCheked(ToggleButton checkedButton, Tools toolType)
        {
            foreach (var button in _toolButtons)
            {
                if (button != checkedButton && button.IsChecked == true)
                {
                    button.IsChecked = false;
                }
            }
            _currentTool = toolType;
        }
        public void SetDefaultTool()
        {
            foreach(var button in _toolButtons)
            {
                if(button.Tag.ToString() == Tools.Pencil.ToString())
                {
                    button.IsChecked = true;
                    break;
                }
            }
        }
    }
}
