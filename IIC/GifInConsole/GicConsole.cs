﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace GifInConsole
{
    class GicConsole
    {
        Image Image { get; set; }
        FrameDimension Dimension { get; set; }
        Color[,] ImageData { get; set; }

        public GicConsole(string imagePath)
        {
            this.Image = Image.FromFile(imagePath);
            this.Dimension = new FrameDimension(this.Image.FrameDimensionsList.First());
        }

        public void Run()
        {
            int horizontalSizeChoice = GetInput();

            var count = this.Image.GetFrameCount(this.Dimension);

            List<Image> images = new List<Image>();

            for (int i = 0; i < count; i++)
            {
                this.Image.SelectActiveFrame(this.Dimension, 50);

                var pixels = ImageConverter.GetColorsFromImage(this.Image);
                pixels = ImageToolbox.ToGrey(pixels);
                var size = 25f / pixels.GetLength(0);

                pixels = pixels.ResizeByFactor(size);
                images.Add(ImageConverter.GetBitmapFromPixels(pixels));
            }
            this.Image.FrameDimensionsList[0] = this.Dimension.Guid;

            new ImageViewer(images.ToArray()).View();
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