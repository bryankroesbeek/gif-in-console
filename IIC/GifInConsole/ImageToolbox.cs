using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GifInConsole
{
    static class ImageToolbox
    {
        public static Color[,] ToGrey(this Color[,] pixels)
        {
            var newPixels = new Color[pixels.GetLength(1), pixels.GetLength(0)];

            for (int y = 0; y < pixels.GetLength(1); y++)
            {
                for (int x = 0; x < pixels.GetLength(0); x++)
                {
                    Color pixel = pixels[x, y];
                    byte ac = (byte)((pixel.R + pixel.G + pixel.B) / 3);
                    newPixels[y, x] = Color.FromArgb(ac, ac, ac);
                }
            }
            return newPixels;
        }

        public static Color[,] ResizeByFactor(this Color[,] pixels, float factor)
        {
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            int newWidth = (int)(width * factor - factor);
            int newHeight = (int)(height * factor - factor);

            var newPixels = new Color[newHeight, newWidth];

            for (int y = 0; y < newHeight; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                    int nearestX = (int)Math.Round(x / factor);
                    int nearestY = (int)Math.Round(y / factor);

                    byte r = pixels[nearestX, nearestY].R;
                    byte g = pixels[nearestX, nearestY].G;
                    byte b = pixels[nearestX, nearestY].B;

                    newPixels[y, x] = Color.FromArgb(r, g, b);
                }
            }
            return newPixels;
        }
    }
}