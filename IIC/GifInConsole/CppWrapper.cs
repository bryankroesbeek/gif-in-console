using System;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using GifInConsole.ImageTools;
using GifInConsole.ImageTypes;

namespace GifInConsole
{
    public class CppWrapper
    {
        [DllImport("lib/imgProcessor.dll")]
        public static extern int getStringForPixelBytes(IntPtr PixelsAddress, int length, int xLength, float factor, StringBuilder output, string charForPixels, int charLength);
    }
}