using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;


namespace GifInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) return;

            // This should be the pathname of the gif that one wants to view in the console
            string path = args[0];

            Image image = Image.FromFile(path);
            FrameDimension dimension = new FrameDimension(image.FrameDimensionsList.First());
            var count = image.GetFrameCount(dimension);
            new ImageViewer(image).View();
        }
    }
}
