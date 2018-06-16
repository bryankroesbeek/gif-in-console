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

        public static string ConvertToConsoleImage(this Color[,] greyInput)
        {
            var chars = Program.WhiteToBlack.ToArray();

            int width = greyInput.GetLength(0);
            int height = greyInput.GetLength(1);

            float range = (255f / (Program.WhiteToBlack.Length - 1));

            var newImage = "";

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var grey = greyInput[x, y].G;
                    
                    newImage += chars[(int)(grey / range)];
                }
            }
            return newImage;
        }
    }
}