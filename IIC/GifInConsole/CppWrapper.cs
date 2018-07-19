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
        public static extern int getStringForPixels(Pixel[] pixels, int length, int horizontalLength, StringBuilder outputString, string asciiToken, int aLength, float factor);

        [DllImport("lib/imgProcessor.dll")]
        public static extern int newSize(int length, int horizontalLength, float factor);
    }
}