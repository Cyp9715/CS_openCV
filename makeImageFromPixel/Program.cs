using System;
using OpenCvSharp;

namespace makeImageFromPixel
{
    class Program
    {
        static void Main(string[] args)
        {
            // MatType.CV_8U = GrayScale (0-255)
            Mat src = new Mat(new Size(1456, 1456), MatType.CV_8U, Scalar.All(255));
            Mat dst = new Mat();
            var window = new Window("window");

            byte value = 0;

            while(true)
            {
                for (int x = 0; x < 1456; ++x)
                {
                    ++value;

                    for (int y = 0; y < 1456; ++y)
                    {
                        var color = src.Get<Vec3b>(y, x);
                        color.Item0 = value;
                        src.Set(y, x, color);
                    }
                }

                window.ShowImage(src);
                Cv2.WaitKey(10);
            }

        }
    }
}
