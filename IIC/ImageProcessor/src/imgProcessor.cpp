#include <iostream>

using namespace std;

extern "C"
{
    int getStringForPixelBytes(unsigned char *imageBytes, int length, int xLength, float factor, char *outputString, char *charForPixels, int charLength)
    {
        int outputWidth = (xLength)*factor + 1;
        int outputHeight = ((length / xLength) * factor) / 2;
        int outputSize = outputWidth * outputHeight;
        int charRange = 255 / charLength;

        int offset = 0;
        int nearestPosition = 0;
        int position = 0;
        
        for (int y = 0; y < outputHeight; y++)
        {
            for (int x = 0; x < outputWidth; x++)
            {
                int nearestX = int(x / factor);
                int nearestY = int(y / factor) * 2;

                nearestPosition = (nearestY * xLength + nearestX) * 3;
                position = (y * outputWidth) + x;

                int pixelValue = ((int)imageBytes[nearestPosition + 0] + (int)imageBytes[nearestPosition + 1] + (int)imageBytes[nearestPosition + 2]) / 3;

                outputString[position] = charForPixels[pixelValue / charRange];
            }
            offset++;
            outputString[position] = '\n';
        }
        outputString[outputSize] = '\0';
        return 0;
    }
}