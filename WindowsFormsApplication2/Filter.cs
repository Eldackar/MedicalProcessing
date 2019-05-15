using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public static class Filter
    {

        public static Bitmap CopyToSquareCanvas(this Bitmap sourceBitmap, int canvasWidthLenght)
        {
            float ratio = 1.0f;
            int maxSide = sourceBitmap.Width > sourceBitmap.Height ?
                          sourceBitmap.Width : sourceBitmap.Height;

            ratio = (float)maxSide / (float)canvasWidthLenght;

            Bitmap bitmapResult = (sourceBitmap.Width > sourceBitmap.Height ?
                                    new Bitmap(canvasWidthLenght, (int)(sourceBitmap.Height / ratio))
                                    : new Bitmap((int)(sourceBitmap.Width / ratio), canvasWidthLenght));

            using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(sourceBitmap,
                                        new Rectangle(0, 0,
                                            bitmapResult.Width, bitmapResult.Height),
                                        new Rectangle(0, 0,
                                            sourceBitmap.Width, sourceBitmap.Height),
                                            GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return bitmapResult;
        }

        public static Bitmap brightnessEnhancement(this Bitmap bmp, int level)
        {
            // create grayscale filter (BT709)
            BrightnessCorrection filter = new BrightnessCorrection(level);
            Bitmap brightnessImage = filter.Apply(bmp);
            return brightnessImage;
        }

        public static Bitmap applyGaussianFilter(this Bitmap sourceBitmap, int kernel)
        {
            // and Gaussia sigma value equal to 4.0
            GaussianBlur filter = new GaussianBlur(4, kernel);
            // apply the filter
            Bitmap gaussianImage = filter.Apply(sourceBitmap);
            return gaussianImage;
        }

        public static Bitmap applyMeanFilter(this Bitmap sourceBitmap)
        {

            Mean filter = new Mean();
            // apply the filter
            Bitmap meanImage = filter.Apply(sourceBitmap);
            return meanImage;
        }

        public static Bitmap applyMedianFilter(this Bitmap sourceBitmap, int kernel)
        {
            Median filter = new Median(kernel);
            // apply the filter
            Bitmap medianImage = filter.Apply(sourceBitmap);
            return medianImage;
        }

        public static Bitmap ToGrayScale(Bitmap bmp)
        {
            // create grayscale filter (BT709)
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(bmp);
            return grayImage;
        }

        public static Bitmap contrastEnhancement(this Bitmap bmp, int level)
        {
            ContrastCorrection filter = new ContrastCorrection(level);
            Bitmap contrastImage = filter.Apply(bmp);
            return contrastImage;
        }


        public static Bitmap homogenityDetection(this Bitmap bmp)
        {
            // create filter
            HomogenityEdgeDetector filter = new HomogenityEdgeDetector();
            // apply the filter
            Bitmap homoImage = filter.Apply(bmp);
            return homoImage;
        }

        public static Bitmap differenceDetection(this Bitmap bmp)
        {
            // create filter
            DifferenceEdgeDetector filter = new DifferenceEdgeDetector();
            // apply the filter
            Bitmap diffImage = filter.Apply(bmp);
            return diffImage;
        }

        public static Bitmap cannyDetection(this Bitmap bmp)
        {

            CannyEdgeDetector filter = new CannyEdgeDetector();
            Bitmap cannyImage = filter.Apply(bmp);
            return cannyImage;

        }

        public static Bitmap sobelDetection(this Bitmap bmp)
        {
            SobelEdgeDetector filter = new SobelEdgeDetector();
            Bitmap sobelImage = filter.Apply(bmp);
            return sobelImage;
        }
    }
}
