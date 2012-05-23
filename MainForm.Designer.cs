namespace SpaceExplorerXNAWF
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonGenColors = new System.Windows.Forms.Button();
            this.buttonGenGalaxy = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.starNameListBox = new System.Windows.Forms.ListBox();
            this.starNameListBoxLabel = new System.Windows.Forms.Label();
            this.buttonExamineStar = new System.Windows.Forms.Button();
            this.gameControl = new SpaceExplorerXNAWF.GameControl();
            this.transparentPictureBox1 = new TransparentPictureBox();
            this.galaxyControl1 = new SpaceExplorerXNAWF.GalaxyControl();
            this.starControl = new SpaceExplorerXNAWF.StarSystemControl();
            this.planetControl1 = new SpaceExplorerXNAWF.PlanetControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenColors
            // 
            this.buttonGenColors.Location = new System.Drawing.Point(363, 27);
            this.buttonGenColors.Name = "buttonGenColors";
            this.buttonGenColors.Size = new System.Drawing.Size(131, 23);
            this.buttonGenColors.TabIndex = 0;
            this.buttonGenColors.Text = "Generate New Colors";
            this.buttonGenColors.UseVisualStyleBackColor = true;
            this.buttonGenColors.Click += new System.EventHandler(this.buttonGenColors_Click);
            // 
            // buttonGenGalaxy
            // 
            this.buttonGenGalaxy.Location = new System.Drawing.Point(1170, 27);
            this.buttonGenGalaxy.Name = "buttonGenGalaxy";
            this.buttonGenGalaxy.Size = new System.Drawing.Size(131, 23);
            this.buttonGenGalaxy.TabIndex = 0;
            this.buttonGenGalaxy.Text = "Generate New Galaxy";
            this.buttonGenGalaxy.UseVisualStyleBackColor = true;
            this.buttonGenGalaxy.Click += new System.EventHandler(this.buttonGenGalaxy_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1680, 1050);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // starNameListBox
            // 
            this.starNameListBox.FormattingEnabled = true;
            this.starNameListBox.Location = new System.Drawing.Point(1346, 96);
            this.starNameListBox.Name = "starNameListBox";
            this.starNameListBox.Size = new System.Drawing.Size(130, 225);
            this.starNameListBox.TabIndex = 6;
            this.starNameListBox.SelectedIndexChanged += new System.EventHandler(this.starNameListBox_SelectedIndexChanged);
            // 
            // starNameListBoxLabel
            // 
            this.starNameListBoxLabel.AutoSize = true;
            this.starNameListBoxLabel.Location = new System.Drawing.Point(1346, 80);
            this.starNameListBoxLabel.Name = "starNameListBoxLabel";
            this.starNameListBoxLabel.Size = new System.Drawing.Size(34, 13);
            this.starNameListBoxLabel.TabIndex = 7;
            this.starNameListBoxLabel.Text = "Stars:";
            // 
            // buttonExamineStar
            // 
            this.buttonExamineStar.Location = new System.Drawing.Point(1346, 327);
            this.buttonExamineStar.Name = "buttonExamineStar";
            this.buttonExamineStar.Size = new System.Drawing.Size(130, 23);
            this.buttonExamineStar.TabIndex = 8;
            this.buttonExamineStar.Text = "Examine Star";
            this.buttonExamineStar.UseVisualStyleBackColor = true;
            this.buttonExamineStar.Click += new System.EventHandler(this.buttonExamineStar_Click);
            // 
            // gameControl
            // 
            this.gameControl.Location = new System.Drawing.Point(340, 75);
            this.gameControl.Name = "gameControl";
            this.gameControl.Size = new System.Drawing.Size(1000, 800);
            this.gameControl.TabIndex = 0;
            this.gameControl.Text = "Game Control";
            // 
            // transparentPictureBox1
            // 
            this.transparentPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("transparentPictureBox1.Image")));
            this.transparentPictureBox1.Location = new System.Drawing.Point(582, 12);
            this.transparentPictureBox1.Name = "transparentPictureBox1";
            this.transparentPictureBox1.Size = new System.Drawing.Size(500, 50);
            this.transparentPictureBox1.TabIndex = 5;
            this.transparentPictureBox1.Text = "transparentPictureBox1";
            // 
            // galaxyControl1
            // 
            this.galaxyControl1.Location = new System.Drawing.Point(340, 75);
            this.galaxyControl1.Name = "galaxyControl1";
            this.galaxyControl1.Size = new System.Drawing.Size(1000, 800);
            this.galaxyControl1.TabIndex = 0;
            this.galaxyControl1.Text = "galaxyControl1";
            // 
            // starControl
            // 
            this.starControl.Location = new System.Drawing.Point(340, 75);
            this.starControl.Name = "starControl";
            this.starControl.Size = new System.Drawing.Size(1000, 800);
            this.starControl.TabIndex = 0;
            this.starControl.Visible = false;
            // 
            // planetControl1
            // 
            this.planetControl1.Location = new System.Drawing.Point(340, 75);
            this.planetControl1.Name = "planetControl1";
            this.planetControl1.Size = new System.Drawing.Size(1000, 800);
            this.planetControl1.TabIndex = 9;
            this.planetControl1.Text = "planetControl1";
            this.planetControl1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1680, 1028);
            this.Controls.Add(this.gameControl);
            this.Controls.Add(this.buttonExamineStar);
            this.Controls.Add(this.starNameListBoxLabel);
            this.Controls.Add(this.starNameListBox);
            this.Controls.Add(this.transparentPictureBox1);
            this.Controls.Add(this.buttonGenGalaxy);
            this.Controls.Add(this.buttonGenColors);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.galaxyControl1); 
            this.Controls.Add(this.starControl);
            this.Controls.Add(this.planetControl1);
            this.starControl.planetControl = this.planetControl1;
            this.Name = "MainForm";
            this.Text = "Space Explorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameControl gameControl;
        private GalaxyControl galaxyControl1;
        private StarSystemControl starControl;
        private TransparentPictureBox transparentPictureBox1;
        private System.Windows.Forms.Button buttonGenColors;
        private System.Windows.Forms.Button buttonGenGalaxy;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.ListBox starNameListBox;
        private System.Windows.Forms.Label starNameListBoxLabel;
        private System.Windows.Forms.Button buttonExamineStar;
        private PlanetControl planetControl1;
    }
}

