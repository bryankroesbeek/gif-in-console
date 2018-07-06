using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GifInConsole.ImageTools
{
    static class ImageToolbox
    {
        public static string ConvertToConsoleImage(this Color[,] input, float factor)
        {
            int width = input.GetLength(1);
            int height = input.GetLength(0);

            int newWidth = (int)(width * factor - factor);
            int newHeight = (int)(height * factor - factor);

            float range = (255f / (Program.WhiteToBlack.Length - 1));
            var chars = Program.WhiteToBlack.ToArray();

            var asciiImage = "";

            for (int y = 0; y < newHeight; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                    int nearestX = (int)(x / factor);
                    int nearestY = (int)(y / factor);

                    byte r = input[nearestY, nearestX].R;
                    byte g = input[nearestY, nearestX].G;
                    byte b = input[nearestY, nearestX].B;

                    byte ac = (byte)((r + g + b) / 3);

                    asciiImage += chars[(int)(ac / range)];
                    asciiImage += chars[(int)(ac / range)];
                }
                asciiImage += "\n";
            }
            return asciiImage;
        }
    }
}