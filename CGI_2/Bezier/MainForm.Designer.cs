namespace Bezier
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
            this.pbox = new System.Windows.Forms.PictureBox();
            this.bDraw = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bRotate = new System.Windows.Forms.Button();
            this.bZoom = new System.Windows.Forms.Button();
            this.bMove = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dataX = new System.Windows.Forms.Label();
            this.dataY = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.SuspendLayout();
            // 
            // pbox
            // 
            this.pbox.BackColor = System.Drawing.Color.Black;
            this.pbox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbox.BackgroundImage")));
            this.pbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbox.Location = new System.Drawing.Point(2, 49);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(1204, 543);
            this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbox.TabIndex = 0;
            this.pbox.TabStop = false;
            this.pbox.Click += new System.EventHandler(this.pbox_Click);
            this.pbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbox_MouseMove);
            // 
            // bDraw
            // 
            this.bDraw.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bDraw.BackgroundImage")));
            this.bDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bDraw.ForeColor = System.Drawing.Color.Black;
            this.bDraw.Location = new System.Drawing.Point(1124, 596);
            this.bDraw.Name = "bDraw";
            this.bDraw.Size = new System.Drawing.Size(75, 52);
            this.bDraw.TabIndex = 1;
            this.bDraw.UseVisualStyleBackColor = true;
            this.bDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // bSave
            // 
            this.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSave.ForeColor = System.Drawing.Color.Gainsboro;
            this.bSave.Location = new System.Drawing.Point(23, 633);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(49, 24);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bClear
            // 
            this.bClear.BackColor = System.Drawing.Color.Transparent;
            this.bClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bClear.BackgroundImage")));
            this.bClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bClear.ForeColor = System.Drawing.Color.Black;
            this.bClear.Location = new System.Drawing.Point(1034, 596);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(84, 52);
            this.bClear.TabIndex = 3;
            this.bClear.UseVisualStyleBackColor = false;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bRotate
            // 
            this.bRotate.BackColor = System.Drawing.Color.Transparent;
            this.bRotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRotate.ForeColor = System.Drawing.Color.Gray;
            this.bRotate.Location = new System.Drawing.Point(483, 605);
            this.bRotate.Name = "bRotate";
            this.bRotate.Size = new System.Drawing.Size(75, 52);
            this.bRotate.TabIndex = 4;
            this.bRotate.Text = "Rotate";
            this.bRotate.UseVisualStyleBackColor = false;
            this.bRotate.Click += new System.EventHandler(this.bRotate_Click);
            // 
            // bZoom
            // 
            this.bZoom.BackColor = System.Drawing.Color.Transparent;
            this.bZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bZoom.ForeColor = System.Drawing.Color.Gray;
            this.bZoom.Location = new System.Drawing.Point(564, 605);
            this.bZoom.Name = "bZoom";
            this.bZoom.Size = new System.Drawing.Size(75, 52);
            this.bZoom.TabIndex = 14;
            this.bZoom.Text = "Zoom";
            this.bZoom.UseVisualStyleBackColor = false;
            this.bZoom.Click += new System.EventHandler(this.bZoom_Click);
            // 
            // bMove
            // 
            this.bMove.BackColor = System.Drawing.Color.Transparent;
            this.bMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bMove.ForeColor = System.Drawing.Color.Gray;
            this.bMove.Location = new System.Drawing.Point(645, 605);
            this.bMove.Name = "bMove";
            this.bMove.Size = new System.Drawing.Size(75, 52);
            this.bMove.TabIndex = 20;
            this.bMove.Text = "Move";
            this.bMove.UseVisualStyleBackColor = false;
            this.bMove.Click += new System.EventHandler(this.bMove_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "*.bmp";
            this.saveFileDialog.Filter = "BitMap files (*.bmp)|*.*";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // dataX
            // 
            this.dataX.AutoSize = true;
            this.dataX.BackColor = System.Drawing.Color.Black;
            this.dataX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataX.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataX.ForeColor = System.Drawing.Color.ForestGreen;
            this.dataX.Location = new System.Drawing.Point(20, 549);
            this.dataX.Name = "dataX";
            this.dataX.Size = new System.Drawing.Size(16, 15);
            this.dataX.TabIndex = 26;
            this.dataX.Text = "#";
            // 
            // dataY
            // 
            this.dataY.AutoSize = true;
            this.dataY.BackColor = System.Drawing.Color.Black;
            this.dataY.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F);
            this.dataY.ForeColor = System.Drawing.Color.ForestGreen;
            this.dataY.Location = new System.Drawing.Point(20, 562);
            this.dataY.Name = "dataY";
            this.dataY.Size = new System.Drawing.Size(16, 15);
            this.dataY.TabIndex = 27;
            this.dataY.Text = "#";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(470, 598);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 66);
            this.panel1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(413, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "Bezier curve. Rotating. Moving. Zooming.";
            // 
            // MainForm
            // 
            this.AcceptButton = this.bDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1211, 670);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataY);
            this.Controls.Add(this.dataX);
            this.Controls.Add(this.bMove);
            this.Controls.Add(this.bZoom);
            this.Controls.Add(this.bRotate);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bDraw);
            this.Controls.Add(this.pbox);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bezier";
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.Button bDraw;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bRotate;
        private System.Windows.Forms.Button bZoom;
        private System.Windows.Forms.Button bMove;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label dataX;
        private System.Windows.Forms.Label dataY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

