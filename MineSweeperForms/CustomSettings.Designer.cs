namespace MinerByAlexForms
{
    partial class CustomSettings
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
            this.npd_SizeX = new System.Windows.Forms.NumericUpDown();
            this.npd_MinesCount = new System.Windows.Forms.NumericUpDown();
            this.npd_SizeY = new System.Windows.Forms.NumericUpDown();
            this.lb_SizeX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.npd_SizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_MinesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_SizeY)).BeginInit();
            this.SuspendLayout();
            // 
            // npd_SizeX
            // 
            this.npd_SizeX.Location = new System.Drawing.Point(12, 27);
            this.npd_SizeX.Name = "npd_SizeX";
            this.npd_SizeX.Size = new System.Drawing.Size(120, 20);
            this.npd_SizeX.TabIndex = 0;
            // 
            // npd_MinesCount
            // 
            this.npd_MinesCount.Location = new System.Drawing.Point(12, 108);
            this.npd_MinesCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.npd_MinesCount.Name = "npd_MinesCount";
            this.npd_MinesCount.Size = new System.Drawing.Size(120, 20);
            this.npd_MinesCount.TabIndex = 1;
            // 
            // npd_SizeY
            // 
            this.npd_SizeY.Location = new System.Drawing.Point(12, 69);
            this.npd_SizeY.Name = "npd_SizeY";
            this.npd_SizeY.Size = new System.Drawing.Size(120, 20);
            this.npd_SizeY.TabIndex = 2;
            // 
            // lb_SizeX
            // 
            this.lb_SizeX.AutoSize = true;
            this.lb_SizeX.Location = new System.Drawing.Point(9, 11);
            this.lb_SizeX.Name = "lb_SizeX";
            this.lb_SizeX.Size = new System.Drawing.Size(34, 13);
            this.lb_SizeX.TabIndex = 3;
            this.lb_SizeX.Text = "SizeX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SizeY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "MinesCount";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CustomSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(145, 192);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_SizeX);
            this.Controls.Add(this.npd_SizeY);
            this.Controls.Add(this.npd_MinesCount);
            this.Controls.Add(this.npd_SizeX);
            this.Name = "CustomSettings";
            ((System.ComponentModel.ISupportInitialize)(this.npd_SizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_MinesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_SizeY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown npd_SizeX;
        private System.Windows.Forms.NumericUpDown npd_MinesCount;
        private System.Windows.Forms.NumericUpDown npd_SizeY;
        private System.Windows.Forms.Label lb_SizeX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}