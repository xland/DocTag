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
            this.SaveTagBtn = new System.Windows.Forms.Button();
            this.TagAddArea = new System.Windows.Forms.Panel();
            this.TagWP = new System.Windows.Forms.FlowLayoutPanel();
            this.TagAddArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // TagTB
            // 
            this.TagTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TagTB.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TagTB.Location = new System.Drawing.Point(8, 5);
            this.TagTB.Multiline = true;
            this.TagTB.Name = "TagTB";
            this.TagTB.Size = new System.Drawing.Size(346, 26);
            this.TagTB.TabIndex = 1;
            // 
            // SaveTagBtn
            // 
            this.SaveTagBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveTagBtn.Location = new System.Drawing.Point(364, 5);
            this.SaveTagBtn.Name = "SaveTagBtn";
            this.SaveTagBtn.Size = new System.Drawing.Size(80, 26);
            this.SaveTagBtn.TabIndex = 2;
            this.SaveTagBtn.Text = "添加标签";
            this.SaveTagBtn.UseVisualStyleBackColor = true;
            this.SaveTagBtn.Click += new System.EventHandler(this.SaveTagBtn_Click);
            // 
            // TagAddArea
            // 
            this.TagAddArea.Controls.Add(this.TagTB);
            this.TagAddArea.Controls.Add(this.SaveTagBtn);
            this.TagAddArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.TagAddArea.Location = new System.Drawing.Point(0, 0);
            this.TagAddArea.Name = "TagAddArea";
            this.TagAddArea.Size = new System.Drawing.Size(452, 36);
            this.TagAddArea.TabIndex = 3;
            // 
            // TagWP
            // 
            this.TagWP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagWP.Location = new System.Drawing.Point(0, 36);
            this.TagWP.Name = "TagWP";
            this.TagWP.Size = new System.Drawing.Size(452, 311);
            this.TagWP.TabIndex = 4;
            // 
            // DocTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 347);
            this.Controls.Add(this.TagWP);
            this.Controls.Add(this.TagAddArea);
            this.Name = "DocTag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加标签";
            this.Load += new System.EventHandler(this.DocTagWin_Loaded);
            this.TagAddArea.ResumeLayout(false);
            this.TagAddArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TagTB;
        private System.Windows.Forms.Button SaveTagBtn;
        private System.Windows.Forms.Panel TagAddArea;
        private System.Windows.Forms.FlowLayoutPanel TagWP;
    }
}