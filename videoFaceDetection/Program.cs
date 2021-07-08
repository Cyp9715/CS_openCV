using System;
using OpenCvSharp;

namespace videoFaceDectection
{
    class Program
    {
        private static void changeResolution(ref Mat src, int widthSize, int heightSize)
        {
            Cv2.Resize(src, src, new Size(widthSize, heightSize));
        }

        private static void startFrame(ref VideoCapture capture, int startFrameNumber)
        {
            capture.Set(VideoCaptureProperties.PosFrames, startFrameNumber);
        }

        static void Main(string[] args)
        {
            VideoCapture videoCapture = new VideoCapture();
            CascadeClassifier classifier = new CascadeClassifier();

            if (!videoCapture.Open(@"..\..\..\..\data\video\izone_clear.mkv") 
                || !classifier.Load(@"..\..\..\..\data\xml\face.xml"))
            {
                return;
            }

            int videoSleepTime = (int)Math.Round(1000 / videoCapture.Fps * 0.75);
            startFrame(ref videoCapture, 10500);

            Mat mat = new Mat();

            using (Window window = new Window())
            {
                while (true)
                {
                    videoCapture.Read(mat);

                    if (mat.Empty())
                    {
                        Console.WriteLine("video End");
                        break;
                    }

                    changeResolution(ref mat, 1980, 1080);

                    Rect[] faces = classifier.DetectMultiScale(mat);

                    foreach (var iter in faces)
                    {
                        Cv2.Rectangle(mat, iter, Scalar.Yellow);
                    }

                    //windowResize, only change window resolution.
                    //window.Resize(640, 480);
                    window.ShowImage(mat);
                    Cv2.WaitKey(videoSleepTime);
                }
            }
        }
    }
}
