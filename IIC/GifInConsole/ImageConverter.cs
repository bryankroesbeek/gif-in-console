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

        public static Bitmap GetBitmapFromPixels(Color[,] pixels)
        {
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            Bitmap b = new Bitmap(height, width);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    b.SetPixel(x, y, pixels[y, x]);
                }
            }
            return b;
        }

        public static char[,] ConvertToConsoleImage(this Color[,] greyInput)
        {
            var chars = Program.WhiteToBlack.ToArray();

            int width = greyInput.GetLength(0);
            int height = greyInput.GetLength(1);

            float range = (255f / (Program.WhiteToBlack.Length - 1));

            var newImage = new char[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var grey = greyInput[x, y].G;
                    
                    newImage[y, x] = chars[(int)(grey / range)];
                }
            }
            return newImage;
        }

        public static string AsciiImageToString(this char[,] greyInput)
        {
            int width = greyInput.GetLength(0);
            int height = greyInput.GetLength(1);

            string newImage = "";

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    newImage += greyInput[x, y];
                    newImage += greyInput[x, y];
                }
                newImage += "\n";
            }
            return newImage;
        }
    }
}