namespace Maze
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
            this.White = new System.Windows.Forms.PictureBox();
            this.Black = new System.Windows.Forms.PictureBox();
            this.Solve = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.White)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Black)).BeginInit();
            this.SuspendLayout();
            // 
            // White
            // 
            this.White.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.White.Location = new System.Drawing.Point(112, 10);
            this.White.Margin = new System.Windows.Forms.Padding(2);
            this.White.Name = "White";
            this.White.Size = new System.Drawing.Size(42, 19);
            this.White.TabIndex = 0;
            this.White.TabStop = false;
            this.White.Click += new System.EventHandler(this.White_Click);
            // 
            // Black
            // 
            this.Black.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Black.Location = new System.Drawing.Point(159, 10);
            this.Black.Margin = new System.Windows.Forms.Padding(2);
            this.Black.Name = "Black";
            this.Black.Size = new System.Drawing.Size(44, 19);
            this.Black.TabIndex = 1;
            this.Black.TabStop = false;
            this.Black.Click += new System.EventHandler(this.Black_Click);
            // 
            // Solve
            // 
            this.Solve.Location = new System.Drawing.Point(10, 10);
            this.Solve.Margin = new System.Windows.Forms.Padding(2);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(48, 19);
            this.Solve.TabIndex = 2;
            this.Solve.Text = "Solve";
            this.Solve.UseVisualStyleBackColor = true;
            this.Solve.Click += new System.EventHandler(this.Solve_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(62, 10);
            this.Reset.Margin = new System.Windows.Forms.Padding(2);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(46, 19);
            this.Reset.TabIndex = 3;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 352);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Solve);
            this.Controls.Add(this.Black);
            this.Controls.Add(this.White);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.White)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Black)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox White;
        private System.Windows.Forms.PictureBox Black;
        private System.Windows.Forms.Button Solve;
        private System.Windows.Forms.Button Reset;
    }
}

