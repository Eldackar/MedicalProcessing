using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {


        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
        private int countButton = 0;
        public static filterObject fltobj = new filterObject();


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e) //IMPORT PICTURE
        {
            OpenFileDialog ofd = new OpenFileDialog();
            // image filters  
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                resultBitmap = originalBitmap;
                streamReader.Close();

                previewBitmap = originalBitmap;
                pictureBox1.Image = previewBitmap;
                pictureBox1.Image = new Bitmap(ofd.FileName);
                button2.Enabled = true;
                importButton.Enabled = true;
                exportButton.Enabled = true;
                bwButton.Enabled = true;
                resetButton.Enabled = true;
                meanBar.Enabled = true;
                medianBar.Enabled = true;
                gaussianBar.Enabled = true;
                brightBar.Enabled = true;
                contBar.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e) // EXPORT P
        {
            /*SaveFileDialog savePic = new SaveFileDialog();
            savePic.Title = "Save Dialog";
            savePic.Filter = "Bitmap Images (*.bmp)|*.bmp|All files(*.*)|*.*";
            if (savePic.ShowDialog(this) == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                bmp.Save(savePic.FileName);
                MessageBox.Show("Save Successfully !", "Image saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/

            ApplyFilter(false);

            if (resultBitmap != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Specify a file name and file path";
                sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    resultBitmap.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();

                    resultBitmap = null;
                }
            }


        }

        private void bwButton_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap newImage = new Bitmap(pictureBox1.Image);
                resultBitmap = Filter.ToGrayScale(resultBitmap);
                pictureBox1.Image = Filter.ToGrayScale(newImage);
                previewBitmap = (Bitmap)pictureBox1.Image;
                addButton(countButton, "Black and White", "blackWhite");
                homogenityBar.Enabled = true;
                differenceBar.Enabled = true;
                cannyBar.Enabled = true;
                sobelBar.Enabled = true;
                string[] blackWhite = new string[] { "blackWhite", "1" };
                fltobj.filterList.Add(blackWhite);
                bwButton.Enabled = false;

            }
            catch
            {
                MessageBox.Show("There is no image imported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ApplyFilter(bool preview)
        {

        }

        private void medianBar_Scroll(object sender, EventArgs e)
        {
            // ApplyFilter(true);
        }

        private void medianBar_MouseUp(object sender, MouseEventArgs e)
        {

            Bitmap currentResultBitmap = resultBitmap;
            if (medianBar.Value == 0)
            {
                kernelLabel2.Text = "No filter";
            }
            else
            {
                kernelLabel2.Text = medianBar.Value.ToString();
            }
            currentResultBitmap = currentResultBitmap.applyMedianFilter(medianBar.Value);
            previewBitmap = currentResultBitmap;
            pictureBox1.Image = previewBitmap;
            resultBitmap = currentResultBitmap;
            String buttonText = "Median Filter : " + medianBar.Value.ToString();
            addButton(countButton, buttonText, "median");
            string[] median = new string[] { "median", medianBar.Value.ToString() };
            fltobj.filterList.Add(median);
        }

        private void gaussianBar_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap currentResultBitmap = resultBitmap;
            if (gaussianBar.Value == 0)
            {
                kernelLabel3.Text = "No filter";
            }
            else
            {
                kernelLabel3.Text = gaussianBar.Value.ToString();
            }
            currentResultBitmap = currentResultBitmap.applyGaussianFilter(gaussianBar.Value);
            previewBitmap = currentResultBitmap;
            pictureBox1.Image = previewBitmap;
            resultBitmap = currentResultBitmap;
            string buttonText = "Gaussian Filter : " + gaussianBar.Value.ToString();
            addButton(countButton, buttonText, "gaussian");
            string[] gaussian = new string[] { "gaussian", gaussianBar.Value.ToString() };
            fltobj.filterList.Add(gaussian);
        }

        private void meanBar_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap currentResultBitmap = resultBitmap;
            if (meanBar.Value == 0)
            {
                kernelLabel1.Text = "No filter";
            }
            else
            {
                kernelLabel1.Text = meanBar.Value.ToString();
            }
            for (int i = 0; i < meanBar.Value; i++)
            {
                currentResultBitmap = currentResultBitmap.applyMeanFilter();
            }
            previewBitmap = currentResultBitmap;
            pictureBox1.Image = previewBitmap;
            resultBitmap = currentResultBitmap;
            String buttonText = "Mean Filter : " + meanBar.Value.ToString();
            addButton(countButton, buttonText, "mean");
            string[] mean = new string[] { "mean", meanBar.Value.ToString() };
            fltobj.filterList.Add(mean);
        }

        private void brightBar_mouseUp(object sender, MouseEventArgs e)
        {
            Bitmap currentResultBitmap = resultBitmap;
            currentResultBitmap = currentResultBitmap.brightnessEnhancement(brightBar.Value);
            previewBitmap = currentResultBitmap;
            pictureBox1.Image = previewBitmap;
            resultBitmap = currentResultBitmap;
            brightLabel.Text = brightBar.Value.ToString();
            String buttonText = "Brightness : " + brightBar.Value.ToString();
            addButton(countButton, buttonText, "brightness");
            string[] brightness = new string[] { "brightness", brightBar.Value.ToString() };
            fltobj.filterList.Add(brightness);
        }

        private void contrastBar_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap currentResultBitmap = resultBitmap;
            currentResultBitmap = currentResultBitmap.contrastEnhancement(contBar.Value);
            previewBitmap = currentResultBitmap;
            pictureBox1.Image = previewBitmap;
            resultBitmap = currentResultBitmap;
            contrastLabel.Text = contBar.Value.ToString();
            String buttonText = "Contrast : " + contBar.Value.ToString();
            addButton(countButton, buttonText, "contrast");
            string[] contrast = new string[] { "contrast", contBar.Value.ToString() };
            fltobj.filterList.Add(contrast);
        }

        private void homogenityBar_MousUp(object sender, MouseEventArgs e)
        {
            Bitmap currentResultBitmap = resultBitmap;
            if (homogenityBar.Value == 0)
            {
                homogenityLabel.Text = "No filter";
            }
            else
            {
                homogenityLabel.Text = homogenityBar.Value.ToString();
            }
            for (int i = 0; i < homogenityBar.Value; i++)
            {
                currentResultBitmap = currentResultBitmap.homogenityDetection();
            }
            previewBitmap = currentResultBitmap;
            pictureBox1.Image = previewBitmap;
            resultBitmap = currentResultBitmap;
            String buttonText = "Homogenity Filter : " + homogenityBar.Value.ToString();
            addButton(countButton, buttonText, "homogenity");
            string[] homogenity = new string[] { "homogenity", homogenityBar.Value.ToString() };
            fltobj.filterList.Add(homogenity);
        }

        private void differenceBar_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap currentResultBitmap = resultBitmap;
            if (differenceBar.Value == 0)
            {
                differenceLabel.Text = "No filter";
            }
            else
            {
                differenceLabel.Text = differenceBar.Value.ToString();
            }
            for (int i = 0; i < differenceBar.Value; i++)
            {
                currentResultBitmap = currentResultBitmap.differenceDetection();
            }
            previewBitmap = currentResultBitmap;
            pictureBox1.Image = previewBitmap;
            resultBitmap = currentResultBitmap;
            String buttonText = "Difference Filter : " + differenceBar.Value.ToString();
            addButton(countButton, buttonText, "difference");
            string[] difference = new string[] { "difference", differenceBar.Value.ToString() };
            fltobj.filterList.Add(difference);
        }

        private void sobelBar_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap currentResultBitmap = resultBitmap;
            if (sobelBar.Value == 0)
            {
                sobelLabel.Text = "No filter";
            }
            else
            {
                sobelLabel.Text = sobelBar.Value.ToString();
            }
            for (int i = 0; i < sobelBar.Value; i++)
            {
                currentResultBitmap = currentResultBitmap.sobelDetection();
            }
            previewBitmap = currentResultBitmap;
            pictureBox1.Image = previewBitmap;
            resultBitmap = currentResultBitmap;
            String buttonText = "Sobel Filter : " + sobelBar.Value.ToString();
            addButton(countButton, buttonText,"sobel");
            string[] sobel = new string[] { "sobel", sobelBar.Value.ToString() };
            fltobj.filterList.Add(sobel);
        }

        private void cannyBar_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap currentResultBitmap = resultBitmap;
            if (cannyBar.Value == 0)
            {
                cannyLabel.Text = "No filter";
            }
            else
            {
                cannyLabel.Text = cannyBar.Value.ToString();
            }
            for (int i = 0; i < cannyBar.Value; i++)
            { 
                currentResultBitmap = currentResultBitmap.cannyDetection();
            }
            previewBitmap = currentResultBitmap;
            pictureBox1.Image = previewBitmap;
            resultBitmap = currentResultBitmap;
            String buttonText = "Canny Filter : " + cannyBar.Value.ToString();
            addButton(countButton, buttonText, "canny");
            string[] canny = new string[] { "canny", cannyBar.Value.ToString() };
            fltobj.filterList.Add(canny);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            deleteAllButton();
            previewBitmap = originalBitmap;
            resultBitmap = originalBitmap;
            pictureBox1.Image = previewBitmap;
            meanBar.Value = 0;
            medianBar.Value = 0;
            gaussianBar.Value = 0;
            brightBar.Value = 0;
            contBar.Value = 0;
            homogenityBar.Value = 0;
            differenceBar.Value = 0;
            sobelBar.Value = 0;
            cannyBar.Value = 0;
            kernelLabel1.Text = "No filter";
            kernelLabel2.Text = "No filter";
            kernelLabel3.Text = "No filter";
            brightLabel.Text = "0";
            contrastLabel.Text = "0";
            homogenityLabel.Text = "No filter";
            differenceLabel.Text = "No filter";
            sobelLabel.Text = "No filter";
            cannyLabel.Text = "No filter";
            bwButton.Enabled = true;
            homogenityBar.Enabled = false;
            differenceBar.Enabled = false;
            cannyBar.Enabled = false;
            sobelBar.Enabled = false;
            /*fltobj.BlackWhite = 0;
            fltobj.Mean = 0;
            fltobj.Median = 0;
            fltobj.Gaussian = 0;
            fltobj.Brightness = 0;
            fltobj.Contrast = 0;
            fltobj.Difference = 0;
            fltobj.Homogenity = 0;
            fltobj.Sobel = 0;
            fltobj.Canny = 0;*/
        }

        private void deleteAllButton()
        {
            foreach (Control o in groupBox9.Controls)
            {
                groupBox9.Controls.Remove(o);
            }
            foreach (Control o in groupBox9.Controls)
            {
                groupBox9.Controls.Remove(o);
            }
            foreach (Control o in groupBox9.Controls)
            {
                groupBox9.Controls.Remove(o);
            }
            foreach (Control o in groupBox9.Controls)
            {
                groupBox9.Controls.Remove(o);
            }
            foreach (Control o in groupBox9.Controls)
            {
                groupBox9.Controls.Remove(o);
            }
        }

        protected void bt_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Tag.ToString())
            {
                case "blackWhite":
                    bwButton.Enabled = true;
                    break;
                case "mean":
                    meanBar.Value = 0;
                    kernelLabel1.Text = "No filter";
                    break;
                case "median":
                    medianBar.Value = 0;
                    kernelLabel2.Text = "No filter";
                    break;
                case "gaussian":
                    gaussianBar.Value = 0;
                    kernelLabel3.Text = "No filter";
                    break;
                case "brightness":
                    brightBar.Value = 0;
                    brightLabel.Text = "0";
                    break;
                case "contrast":
                    contBar.Value = 0;
                    contrastLabel.Text = "0";
                    break;
                case "difference":
                    differenceBar.Value = 0;
                    differenceLabel.Text = "No filter";
                    break;
                case "homogenity":
                    homogenityBar.Value = 0;
                    homogenityLabel.Text = "No filter";
                    break;
                case "sobel":
                    sobelBar.Value = 0;
                    sobelLabel.Text = "No filter"; 
                    break;
                case "canny":
                    cannyBar.Value = 0;
                    cannyLabel.Text = "No filter";
                    break;
            }
            groupBox9.Controls.Remove(btn);
            int totalLenghtAvailable = 1517;
            int buttonHeight = 50;
            int buttonPadding = 15;
            int newWidthButton;
            int newPosition;
            int deleteCountButton = -1;
            foreach (Button o in groupBox9.Controls)
            {
                deleteCountButton += 1; 
            }
            if(deleteCountButton != -1)
            {
                if (deleteCountButton == 0)
                {
                    newWidthButton = totalLenghtAvailable;
                    newPosition = 15;

                }
                else
                {
                    newWidthButton = ((totalLenghtAvailable - (deleteCountButton * buttonPadding))) / (deleteCountButton + 1);
                    newPosition = ((deleteCountButton * buttonPadding) + (deleteCountButton * newWidthButton)) / 2;
                }


                int countEveryButton = 0;
                foreach (Button o in groupBox9.Controls)
                {
                    if (countEveryButton == 0)
                    {
                        o.Location = new Point(buttonPadding, 33);
                    }
                    else
                    {
                        o.Location = new Point(((countEveryButton + 1) * buttonPadding) + (countEveryButton * newWidthButton), 33);
                    }
                    o.Size = new Size(newWidthButton, buttonHeight);
                    countEveryButton += 1;
                }
                countButton -= 1;
            }

            foreach(string[] tab in fltobj.filterList)
            {
                if (btn.Tag.ToString() == tab[0])
                {
                    fltobj.filterList.Remove(tab);
                    break;
                }
            }
            deleteAllButton();
            setImport();
        }


        private void addButton(int id, String TextButton, String typebutton)
        { 
            int totalLenghtAvailable = 1517;
            int buttonHeight = 50;
            int buttonPadding = 15;
            int newWidthButton;
            int newPosition;
            countButton = 0;
            foreach (Button o in groupBox9.Controls)
            {
                countButton += 1;
            }
            if (countButton == 0)
            {
                newWidthButton = totalLenghtAvailable;
                newPosition = 15;

            }
            else
            {
                newWidthButton = ((totalLenghtAvailable - (countButton * buttonPadding))) / (countButton + 1);
                newPosition = ((countButton * buttonPadding) + (countButton * newWidthButton)) / 2;
            }

            Button bt = new Button();
            groupBox9.Controls.Add(bt);
            bt.Click += new EventHandler(bt_click);
            bt.Name = "timeline" + id.ToString();
            bt.Location = new Point(newPosition, 33);
            bt.Size = new Size(newWidthButton, buttonHeight);
            bt.Text = TextButton;
            bt.Tag = typebutton;
            bt.Image = Properties.Resources.cancel_small_;
            bt.ImageAlign = ContentAlignment.TopRight;
            if (countButton != 0)
            {
                int countEveryButton = 0;
                foreach (Button o in groupBox9.Controls)
                {
                    if (countEveryButton == 0)
                    {
                        o.Location = new Point(buttonPadding, 33);
                    }
                    else
                    {
                        o.Location = new Point(((countEveryButton + 1) * buttonPadding) + (countEveryButton * newWidthButton), 33);
                    }
                    o.Size = new Size(newWidthButton, buttonHeight);
                    countEveryButton += 1;
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Specify a file name and file path";
            sfd.Filter = "JSON File(*.json)|*.json";


            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, ImportExportJson.Export());

            }

        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            // image filters  
            ofd.Filter = "JSON Files(*.json)|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                StreamReader streamReader = new StreamReader(ofd.FileName);
                string json = streamReader.ReadToEnd();
                ImportExportJson.Import(json);
                streamReader.Close();
            }
            setImport();
            Console.WriteLine(fltobj.filterList);
        }

        private void setImport()
        {
            /*meanBar.Value = fltobj.Mean;
            medianBar.Value = fltobj.Median;
            gaussianBar.Value = fltobj.Gaussian;
            brightBar.Value = fltobj.Brightness;
            contBar.Value = fltobj.Contrast;
            differenceBar.Value = fltobj.Difference;
            homogenityBar.Value = fltobj.Homogenity;
            sobelBar.Value = fltobj.Sobel;
            cannyBar.Value = fltobj.Canny;*/
            Stopwatch sw = new Stopwatch();
            sw.Start();
            resultBitmap = originalBitmap;

            foreach (string[] a in fltobj.filterList)
            {
                String buttonText;
                switch (a[0])
                {
                    case "blackWhite":
                        resultBitmap = Filter.ToGrayScale(resultBitmap);
                        homogenityBar.Enabled = true;
                        differenceBar.Enabled = true;
                        cannyBar.Enabled = true;
                        sobelBar.Enabled = true;
                        addButton(countButton, "Black and White", "blackWhite");
                        break;
                    case "mean":
                        meanBar.Value = int.Parse(a[1]);
                        kernelLabel1.Text = meanBar.Value.ToString();
                        for(int i = 0; i < meanBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.applyMeanFilter();
                        }
                        buttonText = "Mean Filter : " + meanBar.Value.ToString();
                        addButton(countButton, buttonText, "mean");
                        break;
                    case "median":
                        medianBar.Value = int.Parse(a[1]);
                        kernelLabel2.Text = medianBar.Value.ToString();
                        resultBitmap = resultBitmap.applyMedianFilter(int.Parse(a[1]));
                        buttonText = "Median Filter : " + medianBar.Value.ToString();
                        addButton(countButton, buttonText, "median");
                        break;
                    case "gaussian":
                        gaussianBar.Value = int.Parse(a[1]);
                        kernelLabel3.Text = gaussianBar.Value.ToString();
                        resultBitmap = resultBitmap.applyGaussianFilter(int.Parse(a[1]));
                        buttonText = "Gaussian Filter : " + gaussianBar.Value.ToString();
                        addButton(countButton, buttonText, "gaussian");
                        break;
                    case "brightness":
                        brightBar.Value = int.Parse(a[1]);
                        brightLabel.Text = brightBar.Value.ToString();
                        resultBitmap = resultBitmap.brightnessEnhancement(brightBar.Value);
                        buttonText = "Brightness level : " + brightBar.Value.ToString();
                        addButton(countButton, buttonText, "brightness");
                        break;
                    case "contrast":
                        contBar.Value = int.Parse(a[1]);
                        contrastLabel.Text = contBar.Value.ToString();
                        resultBitmap = resultBitmap.contrastEnhancement(contBar.Value);
                        buttonText = "Contrast level: " + contBar.Value.ToString();
                        addButton(countButton, buttonText, "contrast");
                        break;
                    case "difference":
                        differenceBar.Value = int.Parse(a[1]);
                        differenceLabel.Text = differenceBar.Value.ToString();
                        for (int i = 0; i < differenceBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.differenceDetection();
                        }
                        buttonText = "Difference Filter : " + differenceBar.Value.ToString();
                        addButton(countButton, buttonText, "difference");
                        break;
                    case "homogenity":
                        homogenityBar.Value = int.Parse(a[1]);
                        homogenityLabel.Text = homogenityBar.Value.ToString();
                        for (int i = 0; i < homogenityBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.homogenityDetection();
                        }
                        buttonText = "Homogenity Filter : " + homogenityBar.Value.ToString();
                        addButton(countButton, buttonText, "homogenity");
                        break;
                    case "sobel":
                        sobelBar.Value = int.Parse(a[1]);
                        sobelLabel.Text = sobelBar.Value.ToString();
                        for (int i = 0; i < sobelBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.sobelDetection();
                        }
                        buttonText = "Sobel Filter : " + sobelBar.Value.ToString();
                        addButton(countButton, buttonText,"sobel");
                        break;
                    case "canny":
                        cannyBar.Value = int.Parse(a[1]);
                        cannyLabel.Text = cannyBar.Value.ToString();
                        for (int i = 0; i < cannyBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.cannyDetection();
                        }
                        buttonText = "Canny Filter : " + cannyBar.Value.ToString();
                        addButton(countButton, buttonText, "canny");
                        break;
                }
            }
            previewBitmap = resultBitmap;
            pictureBox1.Image = previewBitmap;
            sw.Stop();
            MessageBox.Show(sw.ElapsedMilliseconds.ToString());       
        }
    }
}
