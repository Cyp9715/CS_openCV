using System;
using OpenCvSharp;

namespace imageRead
{
    class Program
    {
        static void Main(string[] args)
        {
            // nature is 4K image.
            Mat mat = Cv2.ImRead(@"..\..\..\..\data\image\nature.jpg");
            Cv2.Resize(mat, mat, new Size(1920, 1080));

            using (Window window = new Window())
            {
                window.ShowImage(mat);
                Cv2.WaitKey();
            }

        }
    }
}
