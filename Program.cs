using System;
using System.Drawing;

var asciiChars = " .,:ilwW@@";
Bitmap img = new("lowtaperfade.jpg");

int consoleWidth = Console.WindowWidth; 
int consoleHeight = Console.WindowHeight;

var maxWidth = consoleWidth - 1;
var maxHeight = consoleHeight - 1;

int targetWidth = Math.Min(img.Width, maxWidth);
int targetHeight = Math.Min(img.Height, maxHeight);

var widthFactor = (double)img.Width / targetWidth;
var heightFactor = (double)img.Height / targetHeight;
var factor = Math.Min(widthFactor, heightFactor); 

factor *= 1;

img = new(img, new Size((int)(img.Width / factor), (int)(img.Height / factor)));

var aspectRatioAdjustment = 2;

img = new(img, new Size(img.Width, img.Height / aspectRatioAdjustment));

for (int i = 0; i < img.Height; i++)
{
    for (int j = 0; j < img.Width; j++)
    {
        var pixel = img.GetPixel(j, i);
        var avg = (pixel.R + pixel.G + pixel.B) / 3;

        Console.Write(asciiChars[avg * asciiChars.Length / 255]);
    }
    Console.WriteLine();
}
