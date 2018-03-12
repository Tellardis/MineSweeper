namespace MinerByAlexForms
{
    partial class Template
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
            this.Mine = new System.Windows.Forms.Button();
            this.btn_exploded = new System.Windows.Forms.Button();
            this.MineMarkAsMine = new System.Windows.Forms.Button();
            this.btn_suspicious = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_deactivated = new System.Windows.Forms.Button();
            this.btn_exploded_pressed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Mine
            // 
            this.Mine.Location = new System.Drawing.Point(12, 12);
            this.Mine.Name = "Mine";
            this.Mine.Size = new System.Drawing.Size(37, 36);
            this.Mine.TabIndex = 0;
            this.Mine.UseVisualStyleBackColor = true;
            // 
            // btn_exploded
            // 
            this.btn_exploded.Location = new System.Drawing.Point(66, 12);
            this.btn_exploded.Name = "btn_exploded";
            this.btn_exploded.Size = new System.Drawing.Size(48, 43);
            this.btn_exploded.TabIndex = 1;
            this.btn_exploded.Text = "EXP";
            this.btn_exploded.UseVisualStyleBackColor = true;
            // 
            // MineMarkAsMine
            // 
            this.MineMarkAsMine.Location = new System.Drawing.Point(12, 61);
            this.MineMarkAsMine.Name = "MineMarkAsMine";
            this.MineMarkAsMine.Size = new System.Drawing.Size(48, 43);
            this.MineMarkAsMine.TabIndex = 2;
            this.MineMarkAsMine.Text = "M";
            this.MineMarkAsMine.UseVisualStyleBackColor = true;
            // 
            // btn_suspicious
            // 
            this.btn_suspicious.Location = new System.Drawing.Point(66, 61);
            this.btn_suspicious.Name = "btn_suspicious";
            this.btn_suspicious.Size = new System.Drawing.Size(48, 43);
            this.btn_suspicious.TabIndex = 3;
            this.btn_suspicious.Text = "?";
            this.btn_suspicious.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(66, 110);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 43);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btn_deactivated
            // 
            this.btn_deactivated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_deactivated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deactivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_deactivated.Location = new System.Drawing.Point(12, 110);
            this.btn_deactivated.Name = "btn_deactivated";
            this.btn_deactivated.Size = new System.Drawing.Size(48, 43);
            this.btn_deactivated.TabIndex = 6;
            this.btn_deactivated.Text = "1";
            this.btn_deactivated.UseVisualStyleBackColor = false;
            // 
            // btn_exploded_pressed
            // 
            this.btn_exploded_pressed.BackColor = System.Drawing.Color.Red;
            this.btn_exploded_pressed.Location = new System.Drawing.Point(120, 12);
            this.btn_exploded_pressed.Name = "btn_exploded_pressed";
            this.btn_exploded_pressed.Size = new System.Drawing.Size(48, 43);
            this.btn_exploded_pressed.TabIndex = 7;
            this.btn_exploded_pressed.Text = "EXP";
            this.btn_exploded_pressed.UseVisualStyleBackColor = false;
            // 
            // Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 459);
            this.Controls.Add(this.btn_exploded_pressed);
            this.Controls.Add(this.btn_deactivated);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_suspicious);
            this.Controls.Add(this.MineMarkAsMine);
            this.Controls.Add(this.btn_exploded);
            this.Controls.Add(this.Mine);
            this.Name = "Template";
            this.Text = "Template";
            this.Load += new System.EventHandler(this.Template_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Mine;
        private System.Windows.Forms.Button btn_exploded;
        private System.Windows.Forms.Button MineMarkAsMine;
        private System.Windows.Forms.Button btn_suspicious;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_deactivated;
        private System.Windows.Forms.Button btn_exploded_pressed;
    }
}