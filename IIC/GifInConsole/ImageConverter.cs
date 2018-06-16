using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GifInConsole
{
    public static class ImageConverter
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

        public static char[,] ConvertToConsoleImage(this Color[,] greyInput)
        {
            var chars = Program.WhiteToBlack.ToArray();

            int width = greyInput.GetLength(0);
            int height = greyInput.GetLength(1);

            var newImage = new char[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var grey = greyInput[x, y].G;

                    int asciiTokenNumber = (grey * 10) % 255;
                    newImage[x, y] = chars[asciiTokenNumber];
                }
            }
            return newImage;
        }
    }
}