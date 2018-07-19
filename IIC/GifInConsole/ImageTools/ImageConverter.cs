using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GifInConsole.ImageTypes;

namespace GifInConsole.ImageTools
{
    public static class ImageConverter
    {
        public static Pixel[,] GetColorsFromImage(Image input)
        {
            Bitmap image = new Bitmap(input);

            Pixel[,] pixels = new Pixel[image.Height, image.Width];
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var pixel = image.GetPixel(x, y);
                    pixels[y, x] = new Pixel {
                        R = pixel.R,
                        G = pixel.G,
                        B = pixel.B
                    };
                }
            }
            return pixels;
        }
    }
}