#include <iostream>

using namespace std;

struct Pixel
{
    int R;
    int G;
    int B;
};

extern "C"
{
    Pixel getPixels(unsigned char *imageBytes, int pixelIndex)
    {
        Pixel p = Pixel();
        p.R = (int)imageBytes[pixelIndex + 0];
        p.G = (int)imageBytes[pixelIndex + 1];
        p.B = (int)imageBytes[pixelIndex + 2];
        return p;
    }

    int newSize(int length, int horizontalLength, float factor)
    {
        int width = horizontalLength * factor;
        int height = (length / horizontalLength) * factor / 2;
        return (width * height) + height;
    }

    int getStringForPixels(Pixel *pixels, int length, int horizontalLength, char *outputString, char *asciiToken, int aLength, float factor)
    {
        int width = horizontalLength * factor;
        int height = (length / horizontalLength) * factor / 2;
        int outSize = width * height;
        int range = 255 / aLength;

        int offset = 0;

        for (int i = 0; i < outSize; i++)
        {
            int nX = int((i % width) / factor);
            int nY = int((i / width) / factor * 2);
            int nE = (nY * horizontalLength) + nX;
            int greyColor = (pixels[nE].R + pixels[nE].G + pixels[nE].B) / 3;
            outputString[i + offset] = asciiToken[greyColor / range];

            if (i % width == 0)
            {
                offset++;
                outputString[i + offset] = '\n';
            }
        }
        outputString[outSize] = '\0';
        return 0;
    }
}