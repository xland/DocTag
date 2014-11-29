namespace DocTag
{
    partial class TagSuggestionCtl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseSuggestionBtn = new System.Windows.Forms.Button();
            this.TagSuggestionFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Moccasin;
            this.panel1.Controls.Add(this.CloseSuggestionBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 26);
            this.panel1.TabIndex = 0;
            // 
            // CloseSuggestionBtn
            // 
            this.CloseSuggestionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseSuggestionBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseSuggestionBtn.Location = new System.Drawing.Point(491, 3);
            this.CloseSuggestionBtn.Name = "CloseSuggestionBtn";
            this.CloseSuggestionBtn.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.CloseSuggestionBtn.Size = new System.Drawing.Size(20, 20);
            this.CloseSuggestionBtn.TabIndex = 1;
            this.CloseSuggestionBtn.Text = "×";
            this.CloseSuggestionBtn.UseVisualStyleBackColor = true;
            this.CloseSuggestionBtn.Click += new System.EventHandler(this.CloseSuggestionBtn_Click);
            // 
            // TagSuggestionFLP
            // 
            this.TagSuggestionFLP.BackColor = System.Drawing.Color.White;
            this.TagSuggestionFLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagSuggestionFLP.Location = new System.Drawing.Point(0, 0);
            this.TagSuggestionFLP.Name = "TagSuggestionFLP";
            this.TagSuggestionFLP.Size = new System.Drawing.Size(514, 122);
            this.TagSuggestionFLP.TabIndex = 1;
            // 
            // TagSuggestionCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.TagSuggestionFLP);
            this.Controls.Add(this.panel1);
            this.Name = "TagSuggestionCtl";
            this.Size = new System.Drawing.Size(514, 148);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseSuggestionBtn;
        private System.Windows.Forms.FlowLayoutPanel TagSuggestionFLP;
    }
}
