using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

public class ParallelForEachAsyncDemo
{
    public static async Task Run()
    {
        Console.WriteLine("Starting Parallel.ForEachAsync Demo...");

        // Get all image files from the Images folder
        string imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        string[] imageFiles = Directory.GetFiles(imagesDirectory, "*.png");

        // Destination folder for processed images
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "ProcessedImages");
        Directory.CreateDirectory(outputDirectory);

        // Process images in parallel
        await Parallel.ForEachAsync(imageFiles, async (file, cancellationToken) =>
        {
            Console.WriteLine($"Processing {Path.GetFileName(file)} on Thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() => ProcessImage(file, outputDirectory));
        });

        Console.WriteLine("Parallel.ForEachAsync Demo Completed.");
    }

    // Method to convert image to grayscale and save it
    private static void ProcessImage(string inputFile, string outputDirectory)
    {
        // Load image
        using (var image = new Bitmap(inputFile))
        {
            // Convert to grayscale
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    image.SetPixel(x, y, grayColor);
                }
            }

            // Save processed image
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputFile) + "_grayscale.jpg");
            image.Save(outputFileName);
            Console.WriteLine($"Processed and saved: {outputFileName}");
        }
    }
}
