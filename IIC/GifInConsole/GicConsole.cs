using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using GifInConsole.ImageTools;
using GifInConsole.ImageTypes;

namespace GifInConsole
{
    class GicConsole
    {
        Bitmap InputImage { get; set; }
        FrameDimension Dimension { get; set; }
        Pixel[][] ImageData { get; set; }

        public GicConsole(string imagePath)
        {
            this.InputImage = (Bitmap)Image.FromFile(imagePath);
            this.Dimension = new FrameDimension(this.InputImage.FrameDimensionsList.First());

            var count = this.InputImage.GetFrameCount(this.Dimension);
            this.ImageData = new Pixel[count][];

            var ImageRectangle = new Rectangle(0, 0, this.InputImage.Width, this.InputImage.Height);
            var length = this.InputImage.Width * this.InputImage.Height;

            for (int i = 0; i < count; i++)
            {
                this.InputImage.SelectActiveFrame(this.Dimension, i);
                var locked = this.InputImage.LockBits(ImageRectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                var bitmapDataAddress = locked.Scan0;
                var pixels = new Pixel[this.InputImage.Width * this.InputImage.Height];

                for (int pI = 0; pI < length; pI += 1)
                {
                    pixels[pI] = CppWrapper.getPixels(bitmapDataAddress, pI * 3);
                }

                this.ImageData[i] = pixels;//ImageConverter.GetColorsFromImage(this.InputImage).Cast<Pixel>().ToArray();
            }
        }

        public void Run()
        {
            int horizontalSizeChoice = GetInput();

            var count = this.InputImage.GetFrameCount(this.Dimension);

            int width = InputImage.Width;
            int height = InputImage.Height;

            List<string> images = new List<string>();

            var imgs = this.ImageData.Select((imges, i) =>
            {
                var size = ((float)horizontalSizeChoice) / width;
                int stringSize = CppWrapper.newSize(this.ImageData[i].Length, width, size);
                StringBuilder stringImage = new StringBuilder(stringSize);

                CppWrapper.getStringForPixels(this.ImageData[i], this.ImageData[i].Length, width, stringImage, Program.WhiteToBlack, Program.WhiteToBlack.Length, size);
                return stringImage.ToString();
            }).ToArray();

            new ImageViewer(imgs).View(20);
        }

        private int GetInput()
        {
            int choice = 0;
            bool HasChosenSize = false;
            int wrongInputs = 0;

            while (!HasChosenSize)
            {
                if (wrongInputs == 0)
                {
                    Console.WriteLine("Please choose a the amount of horzontal character you want this image to be drawm with...");
                    Console.WriteLine("It is suggested to choose a size that fits in the console, unless you want some ugly shit");
                    Console.WriteLine("I mean, I don't really care. Everyone has their own preferences :)");
                }
                var input = Console.ReadLine();

                HasChosenSize = int.TryParse(input, out choice);
                if (!HasChosenSize)
                {
                    wrongInputs++;
                    Errors.DisplayReaction(wrongInputs);
                }
            }

            return choice;
        }
    }
}