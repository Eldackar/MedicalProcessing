using Accord.Imaging.Converters;
using Accord.Imaging.Filters;
using Accord.MachineLearning;
using Accord.Math;
using Accord.Math.Distances;
using Accord.Math.Wavelets;
using FuzzyCMeansClustering;
using ShearletTransform;
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

        public static Bitmap treshSauvola(this Bitmap bmp)
        {
            var sauvola = new SauvolaThreshold();
            // Compute the filter
            Bitmap sauvolaResult = sauvola.Apply(bmp);
            return sauvolaResult;
        }

        public static Bitmap treshOtsu(this Bitmap bmp)
        {
            var otsu = new OtsuThreshold();
            Bitmap otsuResult = otsu.Apply(bmp);
            return otsuResult;
        }

        public static Bitmap applyWaveletFilter(this Bitmap bmp, int haarCoeff)
        {
            WaveletTransform wavelet = new WaveletTransform(new Haar(haarCoeff));
            Bitmap waveletResult = wavelet.Apply(bmp);
            return waveletResult;

        }

        public static Bitmap applyKuwaharaFilter(this Bitmap bmp)
        {
            Kuwahara kuwahara = new Kuwahara();
            Bitmap kuwaharaResult = kuwahara.Apply(bmp);
            return kuwaharaResult;

        }
        public static Bitmap applyResizeBilinear(this Bitmap bmp, int size)
        {

            ResizeBilinear filter = new ResizeBilinear(size, size);
            // apply the filter
            Bitmap newImage = filter.Apply(bmp);
            return newImage;

        }

        /*public static Bitmap applyFuzzyCmean(this Bitmap bmp, int numClusters,    )
        {
            
        }


         public static Bitmap applyKmeanFilter(this Bitmap bmp, int k, int tolerance)
         {
             // Create converters to convert between Bitmap images and double[] arrays
             var imageToArray = new ImageToArray(min: -1, max: +1);
             var arrayToImage = new ArrayToImage(image.Width, image.Height, min: -1, max: +1);

             // Transform the image into an array of pixel values
             double[][] pixels; imageToArray.Convert(image, out pixels);


             // Create a K-Means algorithm using given k and a
             //  square Euclidean distance as distance metric.
             KMeans kmeans = new KMeans(k: 5)
             {
                 Distance = new SquareEuclidean(),

                 // We will compute the K-Means algorithm until cluster centroids
                 // change less than 0.5 between two iterations of the algorithm
                 Tolerance = 0.05
             };


             // Learn the clusters from the data
             var clusters = kmeans.Learn(pixels);

             // Use clusters to decide class labels
             int[] labels = clusters.Decide(pixels);

             // Replace every pixel with its corresponding centroid
             double[][] replaced = pixels.Apply((x, i) => clusters.Centroids[labels[i]]);

             // Retrieve the resulting image (shown in a picture box)
             Bitmap result; arrayToImage.Convert(replaced, out result);
         }*/

        public static Bitmap applyFuzzyCMean(this Bitmap image, int clusters, int maxit, double accuracy)
        {
            List<ClusterPoint> points = new List<ClusterPoint>();


            for (int row = 0; row < image.Width; ++row)
            {
                for (int col = 0; col < image.Height; ++col)
                {

                    System.Drawing.Color c2 = image.GetPixel(row, col);
                    points.Add(new ClusterPoint(row, col, c2));

                }
            }



            List<ClusterCentroid> centroids = new List<ClusterCentroid>();

            //Create random points to use a the cluster centroids
            Random random = new Random();
            for (int i = 0; i < clusters; i++)
            {
                int randomNumber1 = random.Next(image.Width);
                int randomNumber2 = random.Next(image.Height);
                centroids.Add(new ClusterCentroid(randomNumber1, randomNumber2, image.GetPixel(randomNumber1, randomNumber2)));
            }
            FCM alg = new FCM(points, centroids, 2, image, clusters);
            int k = 0;
            do
            {
                k++;
                alg.J = alg.CalculateObjectiveFunction();
                alg.CalculateClusterCentroids();
                alg.Step();
                double Jnew = alg.CalculateObjectiveFunction();



                image = (Bitmap)alg.getProcessedImage.Clone();

                if (Math.Abs(alg.J - Jnew) < accuracy) break;
            } while (maxit > k);
            return image;
        }

        public static Bitmap applyKMean(this Bitmap image, int paramCluster)
        {

            // Create converters to convert between Bitmap images and double[] arrays
            var imageToArray = new ImageToArray(min: -1, max: +1);
            var arrayToImage = new ArrayToImage(image.Width, image.Height, min: -1, max: +1);

            // Transform the image into an array of pixel values
            double[][] pixels; imageToArray.Convert(image, out pixels);


            // Create a K-Means algorithm using given k and a
            //  square Euclidean distance as distance metric.
            KMeans kmeans = new KMeans(k: paramCluster)
            {
                Distance = new SquareEuclidean(),

                // We will compute the K-Means algorithm until cluster centroids
                // change less than 0.5 between two iterations of the algorithm
                Tolerance = 0.05
            };


            // Learn the clusters from the data
            var clusters = kmeans.Learn(pixels);

            // Use clusters to decide class labels
            int[] labels = clusters.Decide(pixels);

            // Replace every pixel with its corresponding centroid
            double[][] replaced = pixels.Apply((x, i) => clusters.Centroids[labels[i]]);

            // Retrieve the resulting image (shown in a picture box)
            Bitmap result; arrayToImage.Convert(replaced, out result);

            return result;
        }

        public static Bitmap applyShearlet(this Bitmap image)
        {
            CalculShearlet calcul = new CalculShearlet(image);
            return calcul.Resultimage;
        }
    } 
}
