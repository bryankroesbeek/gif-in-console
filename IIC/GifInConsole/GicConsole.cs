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
        Bitmap InputImage { get; }
        FrameDimension Dimension { get; }
        int FrameCount { get; }
        int PixelCount { get; }
        Rectangle ImageRectangle { get; }

        public GicConsole(string imagePath)
        {
            this.InputImage = (Bitmap)Image.FromFile(imagePath);
            this.Dimension = new FrameDimension(this.InputImage.FrameDimensionsList.First());
            this.FrameCount = this.InputImage.GetFrameCount(this.Dimension);
            this.ImageRectangle = new Rectangle(0, 0, this.InputImage.Width, this.InputImage.Height);
            this.PixelCount = this.InputImage.Width * this.InputImage.Height;
        }

        public void Run()
        {
            int horizontalSizeChoice = GetInput();

            int width = InputImage.Width;
            int height = InputImage.Height;

            var factor = ((float)horizontalSizeChoice) / width;

            string[] stringImages = new string[this.FrameCount];

            for (int i = 0; i < this.FrameCount; i++)
            {
                this.InputImage.SelectActiveFrame(this.Dimension, i);
                var lockedPixels = this.InputImage.LockBits(this.ImageRectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                StringBuilder stringImage = new StringBuilder((int)(this.PixelCount / factor + (height / factor)));
                CppWrapper.getStringForPixelBytes(lockedPixels.Scan0, this.PixelCount, width, factor, stringImage, Program.WhiteToBlack, Program.WhiteToBlack.Length - 1);
                stringImages[i] = stringImage.ToString();
                this.InputImage.UnlockBits(lockedPixels);
            }

            new ImageViewer(stringImages).View(15);
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