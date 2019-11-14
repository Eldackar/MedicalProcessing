using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using Accord.Math.Transforms;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearRegression;

namespace ShearletTransform
{
    class CalculShearlet
    {
        public Bitmap Resultimage { get; set; }
        private string maxscale = "max";
        //private string shearletarg = "meyeraux";
        private Matrix<double> C_hor;
        private Matrix<double> C_ver;
        private Matrix<double>[] Psi;
        private bool realCoefficients = true;
        public CalculShearlet(Bitmap image)
        {
            Resultimage = image;
            double x = Math.Max(image.Height, image.Width);
            int numOfScales = Convert.ToInt32(Math.Floor(0.5 * Math.Log(x, 2)));

            //compute spectra
            scalesShearsAndSpectra(numOfScales);

            //shearlet transform
            var tmp = BitmapToComplex2D(image);



            FourierTransform2.FFT2(tmp, FourierTransform.Direction.Forward);
            tmp = circshift(tmp, (int)Math.Floor((double)image.Height / 2), (int)Math.Floor((double)image.Width / 2));
            /*
            var tmp2 = ComplexToMatrix(tmp);
            
            Matrix<double>[] Ust = new Matrix<double>[Psi.Length];
            Ust.Apply(i => Matrix<double>.Build.Dense(image.Width, image.Height,0),Ust);
            for (int i = 0; i < Ust.Length; i++)
            {
                Ust[i]=tmp2.PointwiseMultiply(Psi[i]);
            }*/


            Complex[][][] Ust = new Complex[Psi.Length][][];
            for (int i = 0; i < Ust.Length; i++)
            {
                Ust[i] = complexXmatrix(tmp, (Psi[i].PointwisePower(2)));
                //FourierTransform2.FFT2(Ust[i], FourierTransform.Direction.Backward);
            }

            //var sumPsi = Psi[0];
            var sumUst = (Ust[0]);
            for (var k = 1; k < Psi.Length; k++)
            {
                //sumPsi += Psi[k];
                sumUst = addcomplex(sumUst, Ust[k]);
                //sumUst += (Ust[k]);
            }
            var result = (sumUst);
            result = circshift(result, (int)Math.Floor((double)image.Height / 2), (int)Math.Floor((double)image.Width / 2));
            FourierTransform2.FFT2(result, FourierTransform.Direction.Backward);

            //Resultimage = MatrixtoBmp(ComplexToMatrix(Ust[10]).PointwiseAbs());
            Resultimage = MatrixtoBmp(ComplexToMatrix(result));
            //Resultimage = MatrixtoBmp(tmp2);
            //Resultimage = Ust;

        }
        double nfmod(double a, double b)
        {
            return a - b * Math.Floor(a / b);
        }
        private Complex[][] addcomplex(Complex[][] a, Complex[][] b)
        {
            var c = new Complex[a.Length][];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = new Complex[a[i].Length];
                for (int j = 0; j < c[i].Length; j++)
                {
                    c[i][j] = a[i][j] + b[i][j];
                }
            }
            return c;
        }
        private Complex[][] multiplycomplex(Complex[][] a, Complex[][] b)
        {
            var c = new Complex[a.Length][];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = new Complex[a[i].Length];
                for (int j = 0; j < c[i].Length; j++)
                {
                    c[i][j] = a[i][j] * b[i][j];
                }
            }
            return c;

        }
        private Complex[][] complexXmatrix(Complex[][] a, Matrix<double> b)
        {
            var c = new Complex[a.Length][];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = new Complex[a[i].Length];
                for (int j = 0; j < c[i].Length; j++)
                {
                    c[i][j] = new Complex(a[i][j].Real * b[i, j], a[i][j].Imaginary * b[i, j]);
                }
            }
            return c;
        }
        private Matrix<double> ComplexToMatrix(Complex[][] m)
        {
            Matrix<double> d = Matrix<double>.Build.Dense(m.Length, m[0].Length, 0);
            for (int i = 0; i < m.Length; i++)
            {
                for (int j = 0; j < m[i].Length; j++)
                {
                    d[i, j] = m[i][j].Real;
                }
            }
            Console.WriteLine("complex to matrix : {0}", d[0, 0]);
            return d;
        }
        private Complex[][] MatrixtoComplex(Matrix<double> m)
        {
            Complex[][] d = new Complex[m.RowCount][];
            for (int i = 0; i < m.RowCount; i++)
            {
                d[i] = new Complex[m.ColumnCount];
                for (int j = 0; j < m.ColumnCount; j++)
                {
                    d[i][j] = m[i, j];
                }
            }
            return d;
        }
        private Complex[][] circshift(Complex[][] m, int down = 0, int right = 0)
        {
            var msave = (Complex[][])m.Clone();
            for (int i = 0; i < m.Length; i++)
            {
                if (right != 0)
                {
                    m[(i + right) % m.Length] = (Complex[])msave[i].Clone();
                }
                if (down != 0)
                {
                    for (int j = 0; j < m[i].Length; j++)
                    {
                        m[(i + right) % m.Length][(j + down) % m[i].Length] = msave[i][j];
                    }
                }
            }
            return m;
        }

        private Bitmap MatrixtoBmp(Matrix<double> m)
        {
            Bitmap newBmp = new Bitmap(m.RowCount, m.ColumnCount, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var min = m.Enumerate().Min();
            var max = m.Enumerate().Max();
            Console.WriteLine(min);
            Console.WriteLine(max);
            for (int i = 0; i <= m.RowCount - 1; i++)
            {
                for (int j = 0; j <= m.ColumnCount - 1; j++)
                {
                    var tmp = m[i, j];
                    if ((max - min) != 0)
                    {
                        tmp = (tmp - min) / (max - min) * 255;
                    }
                    else
                    {
                        tmp = 0;
                    }
                    newBmp.SetPixel(i, j, Color.FromArgb((int)tmp, (int)tmp, (int)tmp));
                }
            }
            return newBmp;
        }
        private Complex[][] BitmapToComplex2D(Bitmap bmp)
        {
            // Halve the width, each complex is stored in 2 pixels.
            Complex[][] comp = new Complex[bmp.Width][];

            //Console.WriteLine("pixel : {0}r{1}g{2}b",bmp.GetPixel(0, 0).R, bmp.GetPixel(0, 0).G, bmp.GetPixel(0, 0).B);
            for (int i = 0; i <= bmp.Width - 1; i++)
            {
                comp[i] = new Complex[bmp.Height];
                for (int j = 0; j <= bmp.Height - 1; j++)
                {

                    comp[i][j] = bmp.GetPixel(i, j).R;
                }
            }
            Console.WriteLine("complex bmp : {0}", comp[0][0]);
            return comp;
        }
        private void scalesShearsAndSpectra(int numOfScales)
        {
            //rectangular
            bool rectangular = (Resultimage.Height != Resultimage.Width);

            //computation of the shearlets
            int newheight = Resultimage.Height;
            int newwidth = Resultimage.Width;

            //create meshgrid
            double X = Math.Pow(2, 2 * numOfScales - (maxscale == "max" ? 1 : 2));

            IEnumerable<double> xi_x_init = LinSpace(-X, X - 1 / newwidth * 2 * X, newwidth);
            IEnumerable<double> xi_y_init = rectangular ? LinSpace(-X, X - 1 / newheight * 2 * X, newheight) : xi_x_init;
            double[] array = xi_y_init.ToArray();
            Array.Reverse(array);

            //create grid, from left to right, bottom to top
            var xi = Accord.Math.Matrix.MeshGrid(xi_x_init.ToArray(), array);
            var xi_x = DenseMatrix.OfArray(xi.Item1);
            var xi_y = DenseMatrix.OfArray(xi.Item2);

            var xi_x_abs = xi_x.Map(i => Math.Abs(i));
            var xi_y_abs = xi_y.Map(i => Math.Abs(i));

            //cones
            C_hor = DenseMatrix.OfArray(new double[xi_x.RowCount, xi_x.ColumnCount]);
            C_ver = DenseMatrix.OfArray(new double[xi_x.RowCount, xi_x.ColumnCount]);
            for (var k = 0; k < xi_x.RowCount; k++)
            {
                for (var i = 0; i < xi_x.ColumnCount; i++)
                {
                    C_hor[k, i] = (xi_x_abs[k, i]) >= (xi_y_abs[k, i]) ? 1 : 0;
                    C_ver[k, i] = (xi_x_abs[k, i]) < (xi_y_abs[k, i]) ? 1 : 0;
                }
            }



            /*number of shears: | -2 ^ j,...,0,...,2 ^ j | = 2 * 2 ^ j + 1
            now: inner shears for both cones: 

            | -(2 ^ j - 1), ..., 0, ..., 2 ^ j - 1 |
   
             = 2 * (2 ^ j - 1) + 1
             = 2 ^ (j + 1) - 2 + 1 = 2 ^ (j + 1) - 1
             outer scales: 2("one" for each cone)

             shears for each scale: hor: 2 ^ (j + 1) - 1, ver: 2 ^ (j + 1) - 1, diag: 2
              ->hor + ver + diag = 2 * (2 ^ (j + 1) - 1) + 2 = 2 ^ (j + 2)
             +1 for low - pass*/

            List<double> shearsPerScale = new List<double>();
            for (var k = 0; k < numOfScales; k++)
            {
                shearsPerScale.Add(Math.Pow(2, k + 2));
            }
            var numOfAllShears = 1 + shearsPerScale.Sum();

            Matrix<double>[] test = new Matrix<double>[(int)numOfAllShears];
            test.Apply(i => Matrix<double>.Build.Dense(xi_x.RowCount, xi_x.ColumnCount), test);
            Psi = test;
            //lowpass
            var tmp = shearletSpect(xi_x, xi_y, "scaling");
            Psi[0] = tmp;

            //loop for each scale
            Parallel.For(0, numOfScales, (j) =>
            {
                //starting index
                int idx = (int)Math.Pow(2, j) + 1;
                int start_index = 1 + (int)shearsPerScale.GetRange(0, j).Sum();
                int shift = 1;

                for (var k = -(int)Math.Pow(2, j); k <= (int)Math.Pow(2, j); k++)
                {
                    //shearlet spectrum
                    var P_hor = shearletSpect(xi_x, xi_y, "", Math.Pow(2, (-2 * j)), k * Math.Pow(2, (-j)));
                    Matrix<double> P_ver;
                    if (rectangular)
                    {
                        P_ver = shearletSpect(xi_y, xi_x, "", Math.Pow(2, (-2 * j)), k * Math.Pow(2, (-j)));

                    }
                    else
                    {
                        P_ver = (Degree90Matrix(Degree90Matrix(P_hor))).Transpose();

                    }
                    if (!realCoefficients)
                    {
                        P_ver = (Degree90Matrix(Degree90Matrix(P_hor)));
                    }
                    if (k == -(int)Math.Pow(2, j))
                    {
                        Psi[start_index + idx - 1] = P_hor.PointwiseMultiply(C_hor) + (P_ver.PointwiseMultiply(C_ver));
                    }
                    else if (k == (int)Math.Pow(2, j))
                    {
                        Psi[start_index + idx + shift - 1] = P_hor.PointwiseMultiply(C_hor) + (P_ver.PointwiseMultiply(C_ver));
                    }
                    else
                    {

                        int new_pos = (int)nfmod((idx - shift), shearsPerScale[j]);
                        if (new_pos == 0)
                        {
                            new_pos = (int)shearsPerScale[j];
                        }
                        Psi[start_index + new_pos - 1] = P_hor;
                        Psi[start_index + idx + shift - 1] = P_ver;

                        // update shift
                        shift = shift + 1;


                    }
                }
            }
            );

        }

        private Matrix<double> meyerbump(Matrix<double> x)
        {
            var int1 = meyeraux(x);
            int1 = int1.PointwiseMultiply(x.Map(i => (i >= 0) ? 1.0 : 0)).PointwiseMultiply(x.Map(i => (i <= 1) ? 1.0 : 0)) + x.Map(i => (i > 1) ? 1.0 : 0);
            return int1;
        }
        private Matrix<double> bump(Matrix<double> x)
        {
            Matrix<double> y = meyerbump(x + 1.0).PointwiseMultiply(x.Map(i => (i <= 0) ? 1.0 : 0)) + (meyerbump(x.Map(i => 1 - i)).PointwiseMultiply(x.Map(i => (i > 0) ? 1.0 : 0)));
            y.PointwiseSqrt(y);
            return y;
        }
        private Matrix<double> meyerWavelet(Matrix<double> x)
        {
            //compute Meyer Wavelet
            var xm = meyerHelper(x).Map(i => Math.Pow(Math.Abs(i), 2));
            var xm2 = meyerHelper(x * 2).Map(i => Math.Pow(Math.Abs(i), 2));
            xm += xm2;
            xm.PointwiseSqrt(xm);
            return xm;
        }
        private Matrix<double> meyerHelper(Matrix<double> x)
        {
            //helper function
            Matrix<double> xa = x.Clone();
            if (realCoefficients)
            {
                x.PointwiseAbs(xa);
            }
            else
            {
                xa = -xa; //consider left and upper part of the image due to first row and column
            }
            Matrix<double> int1 = xa.Map(i => ((i >= 1) && (i < 2)) ? 1.0 : 0);
            Matrix<double> int2 = xa.Map(i => ((i >= 2) && (i < 4)) ? 1.0 : 0);

            Matrix<double> xm = meyeraux(xa - 1);
            Matrix<double> xm2 = meyeraux(0.5 * xa - 1);

            Matrix<double> psihat = int1.PointwiseMultiply(xm.Map(i => Math.Sin(Math.PI / 2 * i)));
            Matrix<double> tmp = int2.PointwiseMultiply(xm2.Map(i => Math.Cos(Math.PI / 2 * i)));
            psihat += (tmp);

            return psihat;
        }
        private Matrix<double> meyerScaling(Matrix<double> y)
        {
            //MEYERSCALING compute Meyer scaling function
            // Compute mother scaling function for meyer shearlet
            var x = y.PointwiseAbs();

            //Compute support of Fourier transform of phi.
            Matrix<double> int1 = x.Map(i => (i < 1 / 2) ? 1.0 : 0);
            Matrix<double> int2 = x.Map(i => (i < 1 && i >= 1 / 2) ? 1.0 : 0);

            //Compute Fourier transform of phi.
            Matrix<double> phihat = DenseMatrix.OfMatrix(int1);
            Matrix<double> xa = x.Map(i => 2 * i - 1);
            var polyfit = meyeraux(xa);
            polyfit.Map(i => Math.Cos(Math.PI / 2 * i), polyfit);
            phihat = phihat + int2.PointwiseMultiply(polyfit);
            return phihat;
        }
        private Matrix<double> polyFit(double[] p, Matrix<double> xi)
        {
            var nc = p.Count();
            Matrix<double> y = Matrix<double>.Build.Dense(xi.RowCount, xi.ColumnCount, p[nc - 1]); ;
            for (int i = 1; i < nc; i++)
            {
                y += xi.PointwisePower(i) * p[nc - i - 1];


            }
            return y;
        }
        private Matrix<double> meyeraux(Matrix<double> x)
        {
            // MEYERAUX auxiliary Meyer function
            // Compute Meyer wavelet auxiliary function
            // v(x) = 35 * x ^ 4 - 84 * x ^ 5 + 70 * x ^ 6 - 20 * x ^ 7
            double[] tmp = new double[] { -20, 70, -84, 35, 0, 0, 0, 0 };
            var polyfit = polyFit(tmp, x);


            polyfit = polyfit.PointwiseMultiply(x.Map(i => (i >= 0) ? 1.0 : 0)).PointwiseMultiply(x.Map(i => (i <= 1) ? 1.0 : 0)) + x.Map(i => (i > 1) ? 1.0 : 0);

            return polyfit;
        }

        private Matrix<double> shearletSpect(Matrix<double> xi, Matrix<double> yi, string scaling = "", double a = double.NaN, double s = double.NaN)
        {
            var x = xi.Clone();
            var y = yi.Clone();
            Matrix<double> tmp;
            if (scaling == "scaling")
            {
                //compute scaling function
                tmp = meyerScaling(x).PointwiseMultiply(C_hor) + meyerScaling(y).PointwiseMultiply(C_ver);

            }
            else
            {


                //compute scaling and shearing
                if (!double.IsNaN(a))
                {
                    y = y * (Math.Sqrt(a));
                    if (!double.IsNaN(s))
                    {
                        y = y + (x * (Math.Sqrt(a) * s));
                    }
                    x.Multiply(a, x);
                }

                //set values with x=0 to 1 (for division)
                Matrix<double> xx = x.Map(i => (i == 0) ? 1 : i);
                //compute spectrum
                tmp = meyerWavelet(x).PointwiseMultiply(bump(y.PointwiseMultiply(xx.Map(i => 1 / i))));
            }
            return tmp;
        }


        // func for linspace
        public static IEnumerable<double> Arange(double start, int count)
        {
            return Enumerable.Range((int)start, count).Select(v => (double)v);
        }
        public static IEnumerable<double> LinSpace(double start, double stop, int num, bool endpoint = true)
        {
            var result = new List<double>();
            if (num <= 0)
            {
                return result;
            }

            if (endpoint)
            {
                if (num == 1)
                {
                    return new List<double>() { start };
                }

                var step = (stop - start) / ((double)num - 1.0d);
                result = Arange(0, num).Select(v => (v * step) + start).ToList();
            }
            else
            {
                var step = (stop - start) / (double)num;
                result = Arange(0, num).Select(v => (v * step) + start).ToList();
            }

            return result;
        }
        public double[,] Transpose(double[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            double[,] result = new double[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }
        public Matrix<double> Degree90Matrix(Matrix<double> arry)
        {
            var m = arry.RowCount;
            var n = arry.ColumnCount;
            int j = 0;
            int p = 0;
            int q = 0;
            int i = m - 1;
            Matrix<double> rotatedArr = DenseMatrix.OfArray(new double[m, n]);

            //for (int i = m-1; i >= 0; i--)
            for (int k = 0; k < m; k++)
            {

                while (i >= 0)
                {
                    rotatedArr[p, q] = arry[i, j];
                    q++;
                    i--;
                }
                j++;
                i = m - 1;
                q = 0;
                p++;

            }

            return rotatedArr;

        }

        private void printmatrix(Matrix<double> m)
        {
            var str = String.Join(" ", m.EnumerateRows().SelectMany(x => x.Enumerate()));
            Console.Write(m);
        }
    }

}
