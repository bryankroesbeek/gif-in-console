using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GifInConsole
{
    class ImageConverter
    {
        public static Color[,] GetColorsFromImage(Image input)
        {
            Bitmap image = new Bitmap(input);

            Color[,] pixels = new Color[image.Width, image.Height];
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    pixels[x, y] = image.GetPixel(x, y);
                }
            }
            return pixels;
        }

        public static Bitmap GetBitmapFromPixels(Color[,] pixels)
        {
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            Bitmap b = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    b.SetPixel(x, y, pixels[x, y]);
                }
            }
            return b;
        }
    }
}