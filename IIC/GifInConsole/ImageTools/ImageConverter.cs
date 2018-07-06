using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GifInConsole.ImageTools
{
    public static class ImageConverter
    {
        public static Color[,] GetColorsFromImage(Image input)
        {
            Bitmap image = new Bitmap(input);

            Color[,] pixels = new Color[image.Height, image.Width];
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    pixels[y, x] = image.GetPixel(x, y);
                }
            }
            return pixels;
        }
    }
}