namespace DocTag
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleBarPanel = new System.Windows.Forms.Panel();
            this.TagFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TagSearchPanel = new System.Windows.Forms.Panel();
            this.TagSearchBtn = new System.Windows.Forms.Button();
            this.TagSearchTB = new System.Windows.Forms.TextBox();
            this.DocSearchPanel = new System.Windows.Forms.Panel();
            this.DocSearchBtn = new System.Windows.Forms.Button();
            this.DocSearchTB = new System.Windows.Forms.TextBox();
            this.TagAreaPanel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.DocAreaPanel = new System.Windows.Forms.Panel();
            this.DocFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TagSearchPanel.SuspendLayout();
            this.DocSearchPanel.SuspendLayout();
            this.TagAreaPanel.SuspendLayout();
            this.DocAreaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleBarPanel
            // 
            this.TitleBarPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.TitleBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBarPanel.Location = new System.Drawing.Point(0, 0);
            this.TitleBarPanel.Name = "TitleBarPanel";
            this.TitleBarPanel.Size = new System.Drawing.Size(1088, 41);
            this.TitleBarPanel.TabIndex = 0;
            // 
            // TagFlowPanel
            // 
            this.TagFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagFlowPanel.Location = new System.Drawing.Point(0, 40);
            this.TagFlowPanel.Name = "TagFlowPanel";
            this.TagFlowPanel.Size = new System.Drawing.Size(514, 465);
            this.TagFlowPanel.TabIndex = 1;
            // 
            // TagSearchPanel
            // 
            this.TagSearchPanel.Controls.Add(this.TagSearchBtn);
            this.TagSearchPanel.Controls.Add(this.TagSearchTB);
            this.TagSearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TagSearchPanel.Location = new System.Drawing.Point(0, 0);
            this.TagSearchPanel.Name = "TagSearchPanel";
            this.TagSearchPanel.Padding = new System.Windows.Forms.Padding(6);
            this.TagSearchPanel.Size = new System.Drawing.Size(514, 40);
            this.TagSearchPanel.TabIndex = 0;
            // 
            // TagSearchBtn
            // 
            this.TagSearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TagSearchBtn.Location = new System.Drawing.Point(429, 6);
            this.TagSearchBtn.Name = "TagSearchBtn";
            this.TagSearchBtn.Size = new System.Drawing.Size(80, 26);
            this.TagSearchBtn.TabIndex = 1;
            this.TagSearchBtn.Text = "搜索标签";
            this.TagSearchBtn.UseVisualStyleBackColor = true;
            // 
            // TagSearchTB
            // 
            this.TagSearchTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TagSearchTB.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TagSearchTB.Location = new System.Drawing.Point(6, 6);
            this.TagSearchTB.Multiline = true;
            this.TagSearchTB.Name = "TagSearchTB";
            this.TagSearchTB.Size = new System.Drawing.Size(417, 26);
            this.TagSearchTB.TabIndex = 0;
            // 
            // DocSearchPanel
            // 
            this.DocSearchPanel.Controls.Add(this.DocSearchBtn);
            this.DocSearchPanel.Controls.Add(this.DocSearchTB);
            this.DocSearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DocSearchPanel.Location = new System.Drawing.Point(0, 0);
            this.DocSearchPanel.Name = "DocSearchPanel";
            this.DocSearchPanel.Size = new System.Drawing.Size(570, 40);
            this.DocSearchPanel.TabIndex = 0;
            // 
            // DocSearchBtn
            // 
            this.DocSearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DocSearchBtn.Location = new System.Drawing.Point(485, 6);
            this.DocSearchBtn.Name = "DocSearchBtn";
            this.DocSearchBtn.Size = new System.Drawing.Size(80, 26);
            this.DocSearchBtn.TabIndex = 1;
            this.DocSearchBtn.Text = "搜索文档";
            this.DocSearchBtn.UseVisualStyleBackColor = true;
            // 
            // DocSearchTB
            // 
            this.DocSearchTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DocSearchTB.Location = new System.Drawing.Point(6, 6);
            this.DocSearchTB.Multiline = true;
            this.DocSearchTB.Name = "DocSearchTB";
            this.DocSearchTB.Size = new System.Drawing.Size(471, 26);
            this.DocSearchTB.TabIndex = 0;
            // 
            // TagAreaPanel
            // 
            this.TagAreaPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TagAreaPanel.Controls.Add(this.TagFlowPanel);
            this.TagAreaPanel.Controls.Add(this.TagSearchPanel);
            this.TagAreaPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TagAreaPanel.Location = new System.Drawing.Point(0, 41);
            this.TagAreaPanel.Name = "TagAreaPanel";
            this.TagAreaPanel.Size = new System.Drawing.Size(514, 505);
            this.TagAreaPanel.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Info;
            this.splitter1.Location = new System.Drawing.Point(514, 41);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 505);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // DocAreaPanel
            // 
            this.DocAreaPanel.BackColor = System.Drawing.SystemColors.Control;
            this.DocAreaPanel.Controls.Add(this.DocFlowPanel);
            this.DocAreaPanel.Controls.Add(this.DocSearchPanel);
            this.DocAreaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocAreaPanel.Location = new System.Drawing.Point(518, 41);
            this.DocAreaPanel.Name = "DocAreaPanel";
            this.DocAreaPanel.Size = new System.Drawing.Size(570, 505);
            this.DocAreaPanel.TabIndex = 6;
            // 
            // DocFlowPanel
            // 
            this.DocFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocFlowPanel.Location = new System.Drawing.Point(0, 40);
            this.DocFlowPanel.Name = "DocFlowPanel";
            this.DocFlowPanel.Size = new System.Drawing.Size(570, 465);
            this.DocFlowPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1088, 546);
            this.Controls.Add(this.DocAreaPanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.TagAreaPanel);
            this.Controls.Add(this.TitleBarPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标签管理工具";
            this.TagSearchPanel.ResumeLayout(false);
            this.TagSearchPanel.PerformLayout();
            this.DocSearchPanel.ResumeLayout(false);
            this.DocSearchPanel.PerformLayout();
            this.TagAreaPanel.ResumeLayout(false);
            this.DocAreaPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBarPanel;
        private System.Windows.Forms.Panel TagSearchPanel;
        private System.Windows.Forms.FlowLayoutPanel TagFlowPanel;
        private System.Windows.Forms.Button TagSearchBtn;
        private System.Windows.Forms.TextBox TagSearchTB;
        private System.Windows.Forms.Panel DocSearchPanel;
        private System.Windows.Forms.Button DocSearchBtn;
        private System.Windows.Forms.TextBox DocSearchTB;
        private System.Windows.Forms.Panel TagAreaPanel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel DocAreaPanel;
        private System.Windows.Forms.FlowLayoutPanel DocFlowPanel;

    }
}

