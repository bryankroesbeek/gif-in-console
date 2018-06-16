using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GifInConsole
{
    class ImageViewer
    {
        private string[] Image { get; set; }

        public ImageViewer(string[] i)
        {
            this.Image = i;
        }

        public void View(float framerate)
        {
            new Task(CheckForExit).Start();

            var length = this.Image.Length;

            while (true)
            {
                Console.Clear();
                foreach (string image in this.Image)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(image);
                    Thread.Sleep((int) ((1f / framerate) * 1000));
                }
            }
        }

        public void CheckForExit()
        {
            bool shouldExit = false;
            while (!shouldExit)
            {
                var input = Console.ReadLine();
                if (input == "q" || input == "quit" || input == "exit") shouldExit = true;
            }
            Environment.Exit(0);
        }
    }
}