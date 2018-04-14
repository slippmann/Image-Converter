namespace Image2Bin
{
    partial class Form1
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
            this.Convert = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Browse = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.ImgFile = new System.Windows.Forms.TextBox();
            this.SaveName = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.EndianCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Convert
            // 
            this.Convert.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Convert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Convert.Location = new System.Drawing.Point(0, 253);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(471, 60);
            this.Convert.TabIndex = 0;
            this.Convert.Text = "Convert";
            this.Convert.UseVisualStyleBackColor = true;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(298, 54);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(112, 45);
            this.Browse.TabIndex = 1;
            this.Browse.Text = "Browse...";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(13, 13);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(95, 20);
            this.Title.TabIndex = 2;
            this.Title.Text = "Image2Bin";
            // 
            // ImgFile
            // 
            this.ImgFile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ImgFile.Location = new System.Drawing.Point(40, 63);
            this.ImgFile.Name = "ImgFile";
            this.ImgFile.ReadOnly = true;
            this.ImgFile.Size = new System.Drawing.Size(222, 26);
            this.ImgFile.TabIndex = 3;
            this.ImgFile.Text = "File to convert...";
            // 
            // SaveName
            // 
            this.SaveName.Location = new System.Drawing.Point(40, 133);
            this.SaveName.Name = "SaveName";
            this.SaveName.ReadOnly = true;
            this.SaveName.Size = new System.Drawing.Size(222, 26);
            this.SaveName.TabIndex = 4;
            this.SaveName.Text = "Save binary as...";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(298, 124);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(112, 45);
            this.Save.TabIndex = 6;
            this.Save.Text = "Save As...";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // EndianCheckBox
            // 
            this.EndianCheckBox.AutoSize = true;
            this.EndianCheckBox.Location = new System.Drawing.Point(298, 200);
            this.EndianCheckBox.Name = "EndianCheckBox";
            this.EndianCheckBox.Size = new System.Drawing.Size(121, 24);
            this.EndianCheckBox.TabIndex = 7;
            this.EndianCheckBox.Text = "Big Endian?";
            this.EndianCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 313);
            this.Controls.Add(this.EndianCheckBox);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.SaveName);
            this.Controls.Add(this.ImgFile);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.Convert);
            this.Name = "Form1";
            this.Text = "Image Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Convert;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox ImgFile;
        private System.Windows.Forms.TextBox SaveName;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox EndianCheckBox;
    }
}

