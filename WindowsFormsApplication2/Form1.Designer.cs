namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.kernelLabel3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gaussianBar = new System.Windows.Forms.TrackBar();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.kernelLabel2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.medianBar = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.kernelLabel1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.meanBar = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.contrastLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.contBar = new System.Windows.Forms.TrackBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.brightLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.brightBar = new System.Windows.Forms.TrackBar();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.cannyLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cannyBar = new System.Windows.Forms.TrackBar();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.sobelLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.sobelBar = new System.Windows.Forms.TrackBar();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.differenceLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.differenceBar = new System.Windows.Forms.TrackBar();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.homogenityLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.homogenityBar = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.bwButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaussianBar)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medianBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meanBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contBar)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightBar)).BeginInit();
            this.groupBox.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cannyBar)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sobelBar)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.differenceBar)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homogenityBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Import Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(944, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 161);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Noise Reduction";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.kernelLabel3);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.gaussianBar);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox5.Location = new System.Drawing.Point(423, 37);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(175, 102);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Gaussian Filter";
            // 
            // kernelLabel3
            // 
            this.kernelLabel3.AutoSize = true;
            this.kernelLabel3.Location = new System.Drawing.Point(89, 72);
            this.kernelLabel3.Name = "kernelLabel3";
            this.kernelLabel3.Size = new System.Drawing.Size(49, 15);
            this.kernelLabel3.TabIndex = 0;
            this.kernelLabel3.Text = "No filter";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Level :";
            // 
            // gaussianBar
            // 
            this.gaussianBar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.gaussianBar.Enabled = false;
            this.gaussianBar.Location = new System.Drawing.Point(18, 33);
            this.gaussianBar.Maximum = 5;
            this.gaussianBar.Name = "gaussianBar";
            this.gaussianBar.Size = new System.Drawing.Size(140, 45);
            this.gaussianBar.TabIndex = 0;
            this.gaussianBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gaussianBar_MouseUp);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.kernelLabel2);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.medianBar);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox7.Location = new System.Drawing.Point(221, 37);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(175, 102);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Median Filter";
            // 
            // kernelLabel2
            // 
            this.kernelLabel2.AutoSize = true;
            this.kernelLabel2.Location = new System.Drawing.Point(89, 72);
            this.kernelLabel2.Name = "kernelLabel2";
            this.kernelLabel2.Size = new System.Drawing.Size(49, 15);
            this.kernelLabel2.TabIndex = 0;
            this.kernelLabel2.Text = "No filter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Level :";
            // 
            // medianBar
            // 
            this.medianBar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.medianBar.Enabled = false;
            this.medianBar.Location = new System.Drawing.Point(18, 33);
            this.medianBar.Maximum = 5;
            this.medianBar.Name = "medianBar";
            this.medianBar.Size = new System.Drawing.Size(140, 45);
            this.medianBar.TabIndex = 0;
            this.medianBar.Scroll += new System.EventHandler(this.medianBar_Scroll);
            this.medianBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.medianBar_MouseUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.kernelLabel1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.meanBar);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox4.Location = new System.Drawing.Point(18, 37);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(175, 102);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mean Filter";
            // 
            // kernelLabel1
            // 
            this.kernelLabel1.AutoSize = true;
            this.kernelLabel1.Location = new System.Drawing.Point(82, 72);
            this.kernelLabel1.Name = "kernelLabel1";
            this.kernelLabel1.Size = new System.Drawing.Size(49, 15);
            this.kernelLabel1.TabIndex = 2;
            this.kernelLabel1.Text = "No filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Level :";
            // 
            // meanBar
            // 
            this.meanBar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.meanBar.Enabled = false;
            this.meanBar.Location = new System.Drawing.Point(18, 33);
            this.meanBar.Name = "meanBar";
            this.meanBar.Size = new System.Drawing.Size(140, 45);
            this.meanBar.TabIndex = 2;
            this.meanBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.meanBar_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(943, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 153);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Brightness and Contrast Enhancement";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.contrastLabel);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.contBar);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox8.Location = new System.Drawing.Point(326, 38);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(244, 93);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Contrast";
            // 
            // contrastLabel
            // 
            this.contrastLabel.AutoSize = true;
            this.contrastLabel.Location = new System.Drawing.Point(133, 63);
            this.contrastLabel.Name = "contrastLabel";
            this.contrastLabel.Size = new System.Drawing.Size(14, 15);
            this.contrastLabel.TabIndex = 3;
            this.contrastLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Level :";
            // 
            // contBar
            // 
            this.contBar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.contBar.Enabled = false;
            this.contBar.Location = new System.Drawing.Point(18, 25);
            this.contBar.Maximum = 255;
            this.contBar.Minimum = -255;
            this.contBar.Name = "contBar";
            this.contBar.Size = new System.Drawing.Size(207, 45);
            this.contBar.TabIndex = 0;
            this.contBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.contrastBar_MouseUp);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.brightLabel);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.brightBar);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox6.Location = new System.Drawing.Point(36, 38);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(244, 93);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Brightness";
            // 
            // brightLabel
            // 
            this.brightLabel.AutoSize = true;
            this.brightLabel.Location = new System.Drawing.Point(131, 63);
            this.brightLabel.Name = "brightLabel";
            this.brightLabel.Size = new System.Drawing.Size(14, 15);
            this.brightLabel.TabIndex = 2;
            this.brightLabel.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Level :";
            // 
            // brightBar
            // 
            this.brightBar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.brightBar.Enabled = false;
            this.brightBar.Location = new System.Drawing.Point(18, 25);
            this.brightBar.Maximum = 255;
            this.brightBar.Minimum = -255;
            this.brightBar.Name = "brightBar";
            this.brightBar.Size = new System.Drawing.Size(207, 45);
            this.brightBar.TabIndex = 0;
            this.brightBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.brightBar_mouseUp);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.groupBox13);
            this.groupBox.Controls.Add(this.groupBox12);
            this.groupBox.Controls.Add(this.groupBox11);
            this.groupBox.Controls.Add(this.groupBox10);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox.Location = new System.Drawing.Point(944, 500);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(615, 295);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Contour Representation";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.cannyLabel);
            this.groupBox13.Controls.Add(this.label13);
            this.groupBox13.Controls.Add(this.cannyBar);
            this.groupBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox13.Location = new System.Drawing.Point(321, 166);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(261, 102);
            this.groupBox13.TabIndex = 5;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Canny";
            // 
            // cannyLabel
            // 
            this.cannyLabel.AutoSize = true;
            this.cannyLabel.Location = new System.Drawing.Point(128, 72);
            this.cannyLabel.Name = "cannyLabel";
            this.cannyLabel.Size = new System.Drawing.Size(49, 15);
            this.cannyLabel.TabIndex = 2;
            this.cannyLabel.Text = "No filter";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(85, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 15);
            this.label13.TabIndex = 3;
            this.label13.Text = "Level :";
            // 
            // cannyBar
            // 
            this.cannyBar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.cannyBar.Enabled = false;
            this.cannyBar.Location = new System.Drawing.Point(21, 29);
            this.cannyBar.Maximum = 5;
            this.cannyBar.Name = "cannyBar";
            this.cannyBar.Size = new System.Drawing.Size(221, 45);
            this.cannyBar.TabIndex = 2;
            this.cannyBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cannyBar_MouseUp);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.sobelLabel);
            this.groupBox12.Controls.Add(this.label11);
            this.groupBox12.Controls.Add(this.sobelBar);
            this.groupBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox12.Location = new System.Drawing.Point(29, 166);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(261, 102);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Sobel";
            // 
            // sobelLabel
            // 
            this.sobelLabel.AutoSize = true;
            this.sobelLabel.Location = new System.Drawing.Point(129, 72);
            this.sobelLabel.Name = "sobelLabel";
            this.sobelLabel.Size = new System.Drawing.Size(49, 15);
            this.sobelLabel.TabIndex = 2;
            this.sobelLabel.Text = "No filter";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(86, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "Level :";
            // 
            // sobelBar
            // 
            this.sobelBar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.sobelBar.Enabled = false;
            this.sobelBar.Location = new System.Drawing.Point(21, 29);
            this.sobelBar.Maximum = 5;
            this.sobelBar.Name = "sobelBar";
            this.sobelBar.Size = new System.Drawing.Size(221, 45);
            this.sobelBar.TabIndex = 2;
            this.sobelBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sobelBar_MouseUp);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.differenceLabel);
            this.groupBox11.Controls.Add(this.label9);
            this.groupBox11.Controls.Add(this.differenceBar);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox11.Location = new System.Drawing.Point(321, 36);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(261, 102);
            this.groupBox11.TabIndex = 4;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Difference";
            // 
            // differenceLabel
            // 
            this.differenceLabel.AutoSize = true;
            this.differenceLabel.Location = new System.Drawing.Point(131, 72);
            this.differenceLabel.Name = "differenceLabel";
            this.differenceLabel.Size = new System.Drawing.Size(49, 15);
            this.differenceLabel.TabIndex = 2;
            this.differenceLabel.Text = "No filter";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(88, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Level :";
            // 
            // differenceBar
            // 
            this.differenceBar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.differenceBar.Enabled = false;
            this.differenceBar.Location = new System.Drawing.Point(21, 29);
            this.differenceBar.Maximum = 5;
            this.differenceBar.Name = "differenceBar";
            this.differenceBar.Size = new System.Drawing.Size(221, 45);
            this.differenceBar.TabIndex = 2;
            this.differenceBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.differenceBar_MouseUp);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.homogenityLabel);
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Controls.Add(this.homogenityBar);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox10.Location = new System.Drawing.Point(29, 36);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(261, 102);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Homogenity";
            // 
            // homogenityLabel
            // 
            this.homogenityLabel.AutoSize = true;
            this.homogenityLabel.Location = new System.Drawing.Point(128, 72);
            this.homogenityLabel.Name = "homogenityLabel";
            this.homogenityLabel.Size = new System.Drawing.Size(49, 15);
            this.homogenityLabel.TabIndex = 2;
            this.homogenityLabel.Text = "No filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Level :";
            // 
            // homogenityBar
            // 
            this.homogenityBar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.homogenityBar.Enabled = false;
            this.homogenityBar.Location = new System.Drawing.Point(21, 29);
            this.homogenityBar.Maximum = 5;
            this.homogenityBar.Name = "homogenityBar";
            this.homogenityBar.Size = new System.Drawing.Size(221, 45);
            this.homogenityBar.TabIndex = 2;
            this.homogenityBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.homogenityBar_MousUp);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button2.Location = new System.Drawing.Point(240, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 47);
            this.button2.TabIndex = 5;
            this.button2.Text = "Export Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bwButton
            // 
            this.bwButton.Enabled = false;
            this.bwButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bwButton.Location = new System.Drawing.Point(944, 27);
            this.bwButton.Name = "bwButton";
            this.bwButton.Size = new System.Drawing.Size(275, 47);
            this.bwButton.TabIndex = 6;
            this.bwButton.Text = "Black and White";
            this.bwButton.UseVisualStyleBackColor = true;
            this.bwButton.Click += new System.EventHandler(this.bwButton_Click);
            // 
            // importButton
            // 
            this.importButton.Enabled = false;
            this.importButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.importButton.Location = new System.Drawing.Point(469, 27);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(215, 47);
            this.importButton.TabIndex = 7;
            this.importButton.Text = "Import Config";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.exportButton.Location = new System.Drawing.Point(698, 27);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(215, 47);
            this.exportButton.TabIndex = 8;
            this.exportButton.Text = "Export Config";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.resetButton.Location = new System.Drawing.Point(1283, 27);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(275, 47);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox9.Location = new System.Drawing.Point(12, 821);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1547, 107);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Filters Applied";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(901, 700);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 956);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.bwButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaussianBar)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medianBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meanBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contBar)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightBar)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cannyBar)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sobelBar)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.differenceBar)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homogenityBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label kernelLabel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar medianBar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label kernelLabel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar gaussianBar;
        private System.Windows.Forms.Button bwButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar brightBar;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar contBar;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label kernelLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar meanBar;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label differenceLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar differenceBar;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar homogenityBar;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label cannyLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar cannyBar;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label sobelLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar sobelBar;
        private System.Windows.Forms.Label homogenityLabel;
        private System.Windows.Forms.Label contrastLabel;
        private System.Windows.Forms.Label brightLabel;
    }
}

