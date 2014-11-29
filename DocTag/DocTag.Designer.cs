namespace DocTag
{
    partial class DocTag
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.TagTB = new System.Windows.Forms.TextBox();
            this.TagWP = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TagTB);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 26);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(365, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "增加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveTagBtn_Click);
            // 
            // TagTB
            // 
            this.TagTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagTB.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TagTB.Location = new System.Drawing.Point(0, 0);
            this.TagTB.Multiline = true;
            this.TagTB.Name = "TagTB";
            this.TagTB.Size = new System.Drawing.Size(365, 26);
            this.TagTB.TabIndex = 3;
            this.TagTB.TextChanged += new System.EventHandler(this.TagTB_TextChanged);
            // 
            // TagWP
            // 
            this.TagWP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagWP.Location = new System.Drawing.Point(6, 32);
            this.TagWP.Name = "TagWP";
            this.TagWP.Size = new System.Drawing.Size(440, 309);
            this.TagWP.TabIndex = 4;
            // 
            // DocTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 347);
            this.Controls.Add(this.TagWP);
            this.Controls.Add(this.panel1);
            this.Name = "DocTag";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加标签";
            this.Load += new System.EventHandler(this.DocTagWin_Loaded);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TagTB;
        private System.Windows.Forms.FlowLayoutPanel TagWP;
    }
}