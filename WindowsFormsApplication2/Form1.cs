using DraggableControls;
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

        private void importPicButton_Click(object sender, EventArgs e) //IMPORT PICTURE
        {
            OpenFileDialog ofd = new OpenFileDialog();
            // image filters  
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                originalBitmap = originalBitmap.applyResizeBilinear(512);
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
                kuwaharaBar.Enabled = true;
                string[] blackWhite = new string[] { "blackWhite", "1" };
                fltobj.filterList.Add(blackWhite);
                bwButton.Enabled = false;
                treshGuiDisable(pictureBoxOtsu, labelOtsu);
                treshGuiDisable(pictureBoxSauvola, labelSauvola);
                fltobj.findAndReplace("blackWhite", "1");

            }
            catch
            {
                MessageBox.Show("There is no image imported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ApplyFilter(bool preview)
        {

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
            
            if (fltobj.findElement("median") == true)
            {
                fltobj.findAndReplace("median", medianBar.Value.ToString());
                setImport(false);
                if(medianBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "median")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "median")
                        {
                            o.Text = "Median Filter : " + medianBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                currentResultBitmap = currentResultBitmap.applyMedianFilter(medianBar.Value);
                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("median", medianBar.Value.ToString());
                String buttonText = "Median Filter : " + medianBar.Value.ToString();
                addButton(countButton, buttonText, "median");
            }
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

            if (fltobj.findElement("gaussian") == true)
            {
                fltobj.findAndReplace("gaussian", gaussianBar.Value.ToString());
                setImport(false);
                if (gaussianBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "gaussian")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "gaussian")
                        {
                            o.Text = "Gaussian Filter : " + gaussianBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                currentResultBitmap = currentResultBitmap.applyGaussianFilter(gaussianBar.Value);
                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("gaussian", gaussianBar.Value.ToString());
                String buttonText = "Gaussian Filter : " + gaussianBar.Value.ToString();
                addButton(countButton, buttonText, "gaussian");
            }
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

            if (fltobj.findElement("mean") == true)
            {
                fltobj.findAndReplace("mean", meanBar.Value.ToString());
                setImport(false);
                if (meanBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "mean")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "mean")
                        {
                            o.Text = "Mean Filter : " + meanBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < meanBar.Value; i++)
                {
                    currentResultBitmap = currentResultBitmap.applyMeanFilter();
                }

                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("mean", meanBar.Value.ToString());
                String buttonText = "Mean Filter : " + meanBar.Value.ToString();
                addButton(countButton, buttonText, "mean");
            }
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
            fltobj.findAndReplace("brightness", brightBar.Value.ToString());
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
            fltobj.findAndReplace("contrast", contBar.Value.ToString());
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

            if (fltobj.findElement("homogenity") == true)
            {
                fltobj.findAndReplace("homogenity", homogenityBar.Value.ToString());
                setImport(false);
                if (homogenityBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "homogenity")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "homogenity")
                        {
                            o.Text = "Homogenity Filter : " + homogenityBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < homogenityBar.Value; i++)
                {
                    currentResultBitmap = currentResultBitmap.homogenityDetection();
                }

                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("homogenity", homogenityBar.Value.ToString());
                String buttonText = "Homogenity Filter : " + homogenityBar.Value.ToString();
                addButton(countButton, buttonText, "homogenity");
            }
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

            if (fltobj.findElement("difference") == true)
            {
                fltobj.findAndReplace("difference", differenceBar.Value.ToString());
                setImport(false);
                if (differenceBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "difference")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "difference")
                        {
                            o.Text = "Difference Filter : " + differenceBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < differenceBar.Value; i++)
                {
                    currentResultBitmap = currentResultBitmap.differenceDetection();
                }

                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("difference", differenceBar.Value.ToString());
                String buttonText = "Difference Filter : " + differenceBar.Value.ToString();
                addButton(countButton, buttonText, "difference");
            }
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


            if (fltobj.findElement("sobel") == true)
            {
                fltobj.findAndReplace("sobel", sobelBar.Value.ToString());
                setImport(false);
                if (sobelBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "sobel")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "sobel")
                        {
                            o.Text = "Sobel Filter : " + sobelBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < sobelBar.Value; i++)
                {
                    currentResultBitmap = currentResultBitmap.sobelDetection();
                }

                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("sobel", sobelBar.Value.ToString());
                String buttonText = "Sobel Filter : " + sobelBar.Value.ToString();
                addButton(countButton, buttonText, "sobel");
            }
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


            if (fltobj.findElement("canny") == true)
            {
                fltobj.findAndReplace("canny", cannyBar.Value.ToString());
                setImport(false);
                if (cannyBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "canny")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "canny")
                        {
                            o.Text = "Canny Filter : " + cannyBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < cannyBar.Value; i++)
                {
                    currentResultBitmap = currentResultBitmap.cannyDetection();
                }

                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("canny", cannyBar.Value.ToString());
                String buttonText = "Canny Filter : " + cannyBar.Value.ToString();
                addButton(countButton, buttonText, "canny");
            }
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
            kuwaharaLabel.Text = "No filter";
            waveletLabel.Text = "No filter";
            kuwaharaBar.Value = 0;
            waveletBar.Value = 0;
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
            kuwaharaBar.Enabled = false;
            pictureBoxOtsu.Image = Properties.Resources.cancel_gray;
            pictureBoxSauvola.Image = Properties.Resources.cancel_gray;
            labelOtsu.Text = "Disable";
            labelOtsu.ForeColor = Color.FromArgb(132, 132, 132);
            labelSauvola.Text = "Disable";
            labelSauvola.ForeColor = Color.FromArgb(132, 132, 132);
            fltobj.filterList.Clear();

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
        /*
         * *
         * *
         * *
         * * BUTTON CLICKED TIMELINE
         * *
         * *
         * *
         */
       /* bool isDragged = false;
        Point ptOffset;
        private void bt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragged = true;
                Point ptStartPosition = importP.PointToScreen(new Point(e.X, e.Y));

                ptOffset = new Point();
                ptOffset.X = importPicButton.Location.X - ptStartPosition.X;
                ptOffset.Y = importPicButton.Location.Y - ptStartPosition.Y;
            }
            else
            {
                isDragged = false;
            }
        }

        private void bt_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragged)
            {
                Point newPoint = importPicButton.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(ptOffset);
                importPicButton.Location = newPoint;
            }
        }

        private void bt_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragged)
            {
                Point newPoint = importPicButton.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(ptOffset);
                importPicButton.Location = newPoint;
            }
            isDragged = false;
        }*/

        protected void bt_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if ((sender as Control).IsDragging()) return;
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
                case "otsu":
                    pictureBoxOtsu.Image = Properties.Resources.cancel1;
                    labelOtsu.Text = "Disable";
                    labelOtsu.ForeColor = Color.FromArgb(240, 82, 40);
                    break;
                case "sauvola":
                    pictureBoxSauvola.Image = Properties.Resources.cancel1;
                    labelSauvola.Text = "Disable";
                    labelSauvola.ForeColor = Color.FromArgb(240, 82, 40);
                    break;
                case "kuwahara":
                    kuwaharaBar.Value = 0;
                    kuwaharaLabel.Text = "No filter";
                    break;
                case "wavelet":
                    waveletBar.Value = 0;
                    waveletLabel.Text = "No filter";
                    break;
                case "kmean":
                    kmeanBar.Value = 0;
                    kmeanLabel.Text = "No filter";
                    break;
                case "cmean":
                    cmeanBar.Value = 0;
                    cmeanLabel.Text = "No filter";
                    break;
            }
            groupBox9.Controls.Remove(btn);
            readjustButton();



            foreach (string[] tab in fltobj.filterList)
            {
                if (btn.Tag.ToString() == tab[0])
                {
                    fltobj.filterList.Remove(tab);
                    break;
                }
            }
            deleteAllButton();
            setImport(true);
        }


        /*
         * *
         * *
         * *
         * * ADD BUTTON FUNCTION
         * *
         * *
         * *
         */
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
            bt.Click += new EventHandler(bt_click);
            /* bt.MouseMove += new MouseEventHandler(bt_MouseMove);
             bt.MouseUp += new MouseEventHandler(bt_MouseUp);
             bt.MouseDown += new MouseEventHandler(bt_MouseDown);*/
            bt.Name = "timeline" + id.ToString();
            bt.Location = new Point(newPosition, 33);
            bt.Size = new Size(newWidthButton, buttonHeight);
            bt.Text = TextButton;
            bt.Tag = typebutton;
            bt.Image = Properties.Resources.cancel_small_;
            bt.ImageAlign = ContentAlignment.TopRight;
            groupBox9.Controls.Add(bt);
            if (countButton != 0)
            {
                bt.Draggable(true);
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
            setImport(true);
            Console.WriteLine(fltobj.filterList);
        }

        private void setImport(bool withButton)
        {
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
                        if(withButton == true)
                        {
                            addButton(countButton, "Black and White", "blackWhite");
                        }
                        break;
                    case "mean":
                        meanBar.Value = int.Parse(a[1]);
                        kernelLabel1.Text = meanBar.Value.ToString();
                        for(int i = 0; i < meanBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.applyMeanFilter();
                        }
                        if (withButton == true)
                        {
                            buttonText = "Mean Filter : " + meanBar.Value.ToString();
                            addButton(countButton, buttonText, "mean");
                        }
                        break;
                    case "median":
                        medianBar.Value = int.Parse(a[1]);
                        kernelLabel2.Text = medianBar.Value.ToString();
                        resultBitmap = resultBitmap.applyMedianFilter(int.Parse(a[1]));

                        if (withButton == true)
                        {
                            buttonText = "Median Filter : " + medianBar.Value.ToString();
                            addButton(countButton, buttonText, "median");
                        }
                        break;
                    case "gaussian":
                        gaussianBar.Value = int.Parse(a[1]);
                        kernelLabel3.Text = gaussianBar.Value.ToString();
                        resultBitmap = resultBitmap.applyGaussianFilter(int.Parse(a[1]));

                        if (withButton == true)
                        {
                            buttonText = "Gaussian Filter : " + gaussianBar.Value.ToString();
                            addButton(countButton, buttonText, "gaussian");
                        }
                        break;
                    case "brightness":
                        brightBar.Value = int.Parse(a[1]);
                        brightLabel.Text = brightBar.Value.ToString();
                        resultBitmap = resultBitmap.brightnessEnhancement(brightBar.Value);

                        if (withButton == true)
                        {
                            buttonText = "Brightness level : " + brightBar.Value.ToString();
                            addButton(countButton, buttonText, "brightness");
                        }
                        break;
                    case "contrast":
                        contBar.Value = int.Parse(a[1]);
                        contrastLabel.Text = contBar.Value.ToString();
                        resultBitmap = resultBitmap.contrastEnhancement(contBar.Value);

                        if (withButton == true)
                        {
                            buttonText = "Contrast level: " + contBar.Value.ToString();
                            addButton(countButton, buttonText, "contrast");
                        }
                        break;
                    case "difference":
                        differenceBar.Value = int.Parse(a[1]);
                        differenceLabel.Text = differenceBar.Value.ToString();
                        for (int i = 0; i < differenceBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.differenceDetection();
                        }

                        if (withButton == true)
                        {
                            buttonText = "Difference Filter : " + differenceBar.Value.ToString();
                            addButton(countButton, buttonText, "difference");
                        }
                        break;
                    case "homogenity":
                        homogenityBar.Value = int.Parse(a[1]);
                        homogenityLabel.Text = homogenityBar.Value.ToString();
                        for (int i = 0; i < homogenityBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.homogenityDetection();
                        }

                        if (withButton == true)
                        {
                            buttonText = "Homogenity Filter : " + homogenityBar.Value.ToString();
                            addButton(countButton, buttonText, "homogenity");
                        }
                        break;
                    case "sobel":
                        sobelBar.Value = int.Parse(a[1]);
                        sobelLabel.Text = sobelBar.Value.ToString();
                        for (int i = 0; i < sobelBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.sobelDetection();
                        }

                        if (withButton == true)
                        {
                            buttonText = "Sobel Filter : " + sobelBar.Value.ToString();
                            addButton(countButton, buttonText, "sobel");
                        }
                        break;
                    case "canny":
                        cannyBar.Value = int.Parse(a[1]);
                        cannyLabel.Text = cannyBar.Value.ToString();
                        for (int i = 0; i < cannyBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.cannyDetection();
                        }

                        if (withButton == true)
                        {
                            buttonText = "Canny Filter : " + cannyBar.Value.ToString();
                            addButton(countButton, buttonText, "canny");
                        }
                        break;
                    case "sauvola":
                        treshGuiEnable(pictureBoxSauvola, labelSauvola);
                        resultBitmap = resultBitmap.treshSauvola();
                        pictureBox1.Image = resultBitmap;

                        if (withButton == true)
                        {
                            buttonText = "Treshold Sauvola";
                            addButton(countButton, buttonText, "sauvola");
                        }
                        break;
                    case "otsu":
                        treshGuiEnable(pictureBoxOtsu, labelOtsu);
                        resultBitmap = resultBitmap.treshOtsu();
                        pictureBox1.Image = resultBitmap;

                        if (withButton == true)
                        {
                            buttonText = "Treshold Otsu";
                            addButton(countButton, buttonText, "otsu");
                        }
                        break;
                    case "kuwahara":
                        kuwaharaBar.Value = int.Parse(a[1]);
                        kuwaharaLabel.Text = kuwaharaBar.Value.ToString();
                        for (int i = 0; i < kuwaharaBar.Value; i++)
                        {
                            resultBitmap = resultBitmap.applyKuwaharaFilter();
                        }
                        if (withButton == true)
                        {
                            buttonText = "Kuwahara Filter : " + kuwaharaBar.Value.ToString();
                            addButton(countButton, buttonText, "kuwahara");
                        }
                        break;
                    case "wavelet":
                        waveletBar.Value = int.Parse(a[1]);
                        waveletLabel.Text = waveletBar.Value.ToString();
                        resultBitmap = resultBitmap.applyWaveletFilter(int.Parse(a[1]));

                        if (withButton == true)
                        {
                            buttonText = "Wavelet Filter : " + waveletBar.Value.ToString();
                            addButton(countButton, buttonText, "wavelet");
                        }
                        break;
                    case "cmean":
                        cmeanBar.Value = int.Parse(a[1]);
                        kernelLabel3.Text = cmeanBar.Value.ToString();
                        resultBitmap = resultBitmap.applyFuzzyCMean(int.Parse(a[1]), 20, 0.0001);

                        if (withButton == true)
                        {
                            buttonText = "Fuzzy-C-Mean : " + cmeanBar.Value.ToString();
                            addButton(countButton, buttonText, "cmean");
                        }
                        break;
                    case "kmean":
                        kmeanBar.Value = int.Parse(a[1]);
                        kernelLabel3.Text = kmeanBar.Value.ToString();
                        resultBitmap = resultBitmap.applyKMean(int.Parse(a[1]));

                        if (withButton == true)
                        {
                            buttonText = "K-Mean Filter : " + kmeanBar.Value.ToString();
                            addButton(countButton, buttonText, "kmean");
                        }
                        break;
                    case "shearlet":
                        treshGuiEnable(pictureBoxShearlet, labelShearlet);
                        resultBitmap = resultBitmap.applyShearlet();
                        pictureBox1.Image = resultBitmap;

                        if (withButton == true)
                        {
                            buttonText = "Shearlet Transform";
                            addButton(countButton, buttonText, "shearlet");
                        }
                        break;
                }
            }
            previewBitmap = resultBitmap;
            pictureBox1.Image = previewBitmap;    
        }

        private void treshGuiEnable(PictureBox pic, Label lab)
        {
            pic.Image = Properties.Resources._checked;
            lab.Text = "Enable";
            lab.ForeColor = Color.FromArgb(105, 193, 87);
        }

        private void treshGuiDisable(PictureBox pic, Label lab)
        {
            pic.Image = Properties.Resources.cancel1;
            lab.Text = "Disable";
            lab.ForeColor = Color.FromArgb(240, 82, 40);
        }

        private void pictureBoxOtsu_Click(object sender, EventArgs e)
        {
            if(bwButton.Enabled == false && resetButton.Enabled == true)
            {
                if(labelOtsu.Text == "Disable")
                {
                    treshGuiEnable(pictureBoxOtsu, labelOtsu);
                    resultBitmap = resultBitmap.treshOtsu();
                    pictureBox1.Image = resultBitmap;
                    String buttonText = "Treshold Otsu";
                    addButton(countButton, buttonText, "otsu");
                    fltobj.findAndReplace("otsu", "1");
                }
                else
                {
                    treshGuiDisable(pictureBoxOtsu, labelOtsu);
                }
            }
            else
            {
                return;
            }
        }

        private void labelOtsu_Click(object sender, EventArgs e)
        {
            if (bwButton.Enabled == false && resetButton.Enabled == true)
            {
                if (labelOtsu.Text == "Disable")
                {
                    treshGuiEnable(pictureBoxOtsu, labelOtsu);
                    resultBitmap = resultBitmap.treshOtsu();
                    pictureBox1.Image = resultBitmap;
                    String buttonText = "Treshold Otsu";
                    addButton(countButton, buttonText, "otsu");
                    fltobj.findAndReplace("otsu", "1");

                }
                else
                {
                    treshGuiDisable(pictureBoxOtsu, labelOtsu);
                }
            }
            else
            {
                return;
            }
        }

        private void pictureBoxSauvola_Click(object sender, EventArgs e)
        {
            if (bwButton.Enabled == false && resetButton.Enabled == true)
            {
                if (labelSauvola.Text == "Disable")
                {
                    treshGuiEnable(pictureBoxSauvola, labelSauvola);
                    resultBitmap = resultBitmap.treshSauvola();
                    pictureBox1.Image = resultBitmap;
                    String buttonText = "Treshold Sauvola";
                    addButton(countButton, buttonText, "sauvola");
                    fltobj.findAndReplace("sauvola", "1");
                }
                else
                {
                    treshGuiDisable(pictureBoxSauvola, labelSauvola);
                }
            }
            else
            {
                return;
            }
        }

        private void labelSauvola_Click(object sender, EventArgs e)
        {
            if (bwButton.Enabled == false && resetButton.Enabled == true)
            {
                if (labelSauvola.Text == "Disable")
                {
                    treshGuiEnable(pictureBoxSauvola, labelSauvola);
                    resultBitmap = resultBitmap.treshSauvola();
                    pictureBox1.Image = resultBitmap;
                    String buttonText = "Treshold Sauvola";
                    addButton(countButton, buttonText, "sauvola");
                    fltobj.findAndReplace("sauvola", "1");
                }
                else
                {
                    treshGuiDisable(pictureBoxSauvola, labelSauvola);
                }
            }
            else
            {
                return;
            }
        }

        private void kuwaharaBar_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap currentResultBitmap = resultBitmap;
            if (kuwaharaBar.Value == 0)
            {
                kuwaharaLabel.Text = "No filter";
            }
            else
            {
                kuwaharaLabel.Text = kuwaharaBar.Value.ToString();
            }

            if (fltobj.findElement("kuwahara") == true)
            {
                fltobj.findAndReplace("kuwahara", kuwaharaBar.Value.ToString());
                setImport(false);
                if (kuwaharaBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "kuwahara")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "kuwahara")
                        {
                            o.Text = "Kuwahara Filter : " + kuwaharaBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < kuwaharaBar.Value; i++)
                {
                    currentResultBitmap = currentResultBitmap.applyKuwaharaFilter();
                }

                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("kuwahara", kuwaharaBar.Value.ToString());
                String buttonText = "Kuwahara Filter : " + kuwaharaBar.Value.ToString();
                addButton(countButton, buttonText, "kuwahara");
            }
        }

        private void readjustButton()
        {
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
            if (deleteCountButton != -1)
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
        }

        private void waveletBar_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap currentResultBitmap = resultBitmap;
            if (waveletBar.Value == 0)
            {
                waveletLabel.Text = "No filter";
            }
            else
            {
                waveletLabel.Text = waveletBar.Value.ToString();
            }

            if (fltobj.findElement("wavelet") == true)
            {
                fltobj.findAndReplace("wavelet", waveletBar.Value.ToString());
                setImport(false);
                if (waveletBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "wavelet")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "wavelet")
                        {
                            o.Text = "Wavelet Filter : " + waveletBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                currentResultBitmap = currentResultBitmap.applyWaveletFilter(waveletBar.Value);
                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("wavelet", waveletBar.Value.ToString());
                String buttonText = "Wavelet Filter : " + waveletBar.Value.ToString();
                addButton(countButton, buttonText, "wavelet");
            }
        }

        private void cmeanBar_MouseUp(object sender, MouseEventArgs e)
        {

            Bitmap currentResultBitmap = resultBitmap;
            if (cmeanBar.Value == 0)
            {
                cmeanLabel.Text = "No filter";
            }
            else
            {
                cmeanLabel.Text = cmeanBar.Value.ToString();
            }

            if (fltobj.findElement("cmean") == true)
            {
                fltobj.findAndReplace("cmean", cmeanBar.Value.ToString());
                setImport(false);
                if (cmeanBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "cmean")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "cmean")
                        {
                            o.Text = "Fuzzy-C-Mean Filter : " + cmeanBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                currentResultBitmap = currentResultBitmap.applyFuzzyCMean(cmeanBar.Value, 20, 0.0001);
                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("cmean", cmeanBar.Value.ToString());
                String buttonText = "Fuzzy-C-Mean : " + cmeanBar.Value.ToString();
                addButton(countButton, buttonText, "cmean");
            }
        }

        private void kmeanBar_MouseUp(object sender, MouseEventArgs e)
        {

            Bitmap currentResultBitmap = resultBitmap;
            if (kmeanBar.Value == 0)
            {
                kmeanLabel.Text = "No filter";
            }
            else
            {
                kmeanLabel.Text = kmeanBar.Value.ToString();
            }

            if (fltobj.findElement("kmean") == true)
            {
                fltobj.findAndReplace("kmean", kmeanBar.Value.ToString());
                setImport(false);
                if (kmeanBar.Value == 0)
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        Console.WriteLine(o.Tag);
                        if (o.Tag.ToString() == "kmean")
                        {
                            groupBox9.Controls.Remove(o);
                        }
                    }
                    readjustButton();
                }
                else
                {
                    foreach (Control o in groupBox9.Controls)
                    {
                        if (o.Tag.ToString() == "kmean")
                        {
                            o.Text = "K-Mean Filter : " + kmeanBar.Value.ToString();
                        }
                    }
                }
            }
            else
            {
                currentResultBitmap = currentResultBitmap.applyKMean(kmeanBar.Value);
                previewBitmap = currentResultBitmap;
                pictureBox1.Image = previewBitmap;
                resultBitmap = currentResultBitmap;
                fltobj.findAndReplace("kmean", kmeanBar.Value.ToString());
                String buttonText = "K-mean Filter : " + kmeanBar.Value.ToString();
                addButton(countButton, buttonText, "kmean");
            }
        }

        private void pictureBoxShearlet_Click(object sender, EventArgs e)
        {
            if (bwButton.Enabled == false && resetButton.Enabled == true)
            {
                if (labelSauvola.Text == "Disable")
                {
                    treshGuiEnable(pictureBoxShearlet, labelShearlet);
                    resultBitmap = resultBitmap.applyShearlet();
                    pictureBox1.Image = resultBitmap;
                    String buttonText = "Shearlet Transform";
                    addButton(countButton, buttonText, "shearlet");
                    fltobj.findAndReplace("shearlet", "1");
                }
                else
                {
                    treshGuiDisable(pictureBoxShearlet, labelShearlet);
                }
            }
            else
            {
                return;
            }
        }

        private void labelShearlet_Click(object sender, EventArgs e)
        {
            if (bwButton.Enabled == false && resetButton.Enabled == true)
            {
                if (labelSauvola.Text == "Disable")
                {
                    treshGuiEnable(pictureBoxShearlet, labelShearlet);
                    resultBitmap = resultBitmap.applyShearlet();
                    pictureBox1.Image = resultBitmap;
                    String buttonText = "Shearlet Transform";
                    addButton(countButton, buttonText, "shearlet");
                    fltobj.findAndReplace("shearlet", "1");
                }
                else
                {
                    treshGuiDisable(pictureBoxShearlet, labelShearlet);
                }
            }
            else
            {
                return;
            }
        }
    }
}
