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
            this.TagTB = new System.Windows.Forms.TextBox();
            this.TagWP = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // TagTB
            // 
            this.TagTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.TagTB.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TagTB.Location = new System.Drawing.Point(6, 6);
            this.TagTB.Multiline = true;
            this.TagTB.Name = "TagTB";
            this.TagTB.Size = new System.Drawing.Size(440, 26);
            this.TagTB.TabIndex = 1;
            this.TagTB.TextChanged += new System.EventHandler(this.TagTB_TextChanged);
            // 
            // TagWP
            // 
            this.TagWP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagWP.Location = new System.Drawing.Point(6, 32);
            this.TagWP.Name = "TagWP";
            this.TagWP.Size = new System.Drawing.Size(440, 309);
            this.TagWP.TabIndex = 5;
            // 
            // DocTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 347);
            this.Controls.Add(this.TagWP);
            this.Controls.Add(this.TagTB);
            this.Name = "DocTag";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加标签";
            this.Load += new System.EventHandler(this.DocTagWin_Loaded);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TagTB;
        private System.Windows.Forms.FlowLayoutPanel TagWP;
    }
}