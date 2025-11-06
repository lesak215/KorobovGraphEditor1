using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KorobovGraphEditor1.classes
{
    public class FileService
    {
        public void SaveCanvasToPng(Canvas canvas)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "PNG Image|*.png",
                Title = "Сохранить рисунок как PNG"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var renderBitmap = new RenderTargetBitmap(
                    (int)canvas.ActualWidth,
                    (int)canvas.ActualHeight,
                    96d, 96d, PixelFormats.Pbgra32);

                renderBitmap.Render(canvas);

                var pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(renderBitmap));

                using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    pngEncoder.Save(fileStream);
                }

                MessageBox.Show($"Рисунок сохранен: {saveFileDialog.FileName}",
                              "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
