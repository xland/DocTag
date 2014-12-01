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
            this.TagSearchTB = new System.Windows.Forms.TextBox();
            this.DocSearchTB = new System.Windows.Forms.TextBox();
            this.TagAreaPanel = new System.Windows.Forms.Panel();
            this.TagFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.DocAreaPanel = new System.Windows.Forms.Panel();
            this.DocFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
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
            this.TitleBarPanel.Size = new System.Drawing.Size(1088, 15);
            this.TitleBarPanel.TabIndex = 0;
            // 
            // TagSearchTB
            // 
            this.TagSearchTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.TagSearchTB.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TagSearchTB.Location = new System.Drawing.Point(6, 6);
            this.TagSearchTB.Multiline = true;
            this.TagSearchTB.Name = "TagSearchTB";
            this.TagSearchTB.Size = new System.Drawing.Size(502, 26);
            this.TagSearchTB.TabIndex = 0;
            this.TagSearchTB.TextChanged += new System.EventHandler(this.TagSearchTB_TextChanged);
            // 
            // DocSearchTB
            // 
            this.DocSearchTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.DocSearchTB.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.DocSearchTB.Location = new System.Drawing.Point(6, 6);
            this.DocSearchTB.Multiline = true;
            this.DocSearchTB.Name = "DocSearchTB";
            this.DocSearchTB.Size = new System.Drawing.Size(558, 26);
            this.DocSearchTB.TabIndex = 0;
            this.DocSearchTB.TextChanged += new System.EventHandler(this.DocSearchTB_TextChanged);
            // 
            // TagAreaPanel
            // 
            this.TagAreaPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TagAreaPanel.Controls.Add(this.TagFlowPanel);
            this.TagAreaPanel.Controls.Add(this.TagSearchTB);
            this.TagAreaPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TagAreaPanel.Location = new System.Drawing.Point(0, 15);
            this.TagAreaPanel.Name = "TagAreaPanel";
            this.TagAreaPanel.Padding = new System.Windows.Forms.Padding(6);
            this.TagAreaPanel.Size = new System.Drawing.Size(514, 531);
            this.TagAreaPanel.TabIndex = 4;
            // 
            // TagFlowPanel
            // 
            this.TagFlowPanel.AutoScroll = true;
            this.TagFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagFlowPanel.Location = new System.Drawing.Point(6, 32);
            this.TagFlowPanel.Name = "TagFlowPanel";
            this.TagFlowPanel.Size = new System.Drawing.Size(502, 493);
            this.TagFlowPanel.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Info;
            this.splitter1.Location = new System.Drawing.Point(514, 15);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 531);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // DocAreaPanel
            // 
            this.DocAreaPanel.BackColor = System.Drawing.SystemColors.Control;
            this.DocAreaPanel.Controls.Add(this.DocFlowPanel);
            this.DocAreaPanel.Controls.Add(this.DocSearchTB);
            this.DocAreaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocAreaPanel.Location = new System.Drawing.Point(518, 15);
            this.DocAreaPanel.Name = "DocAreaPanel";
            this.DocAreaPanel.Padding = new System.Windows.Forms.Padding(6);
            this.DocAreaPanel.Size = new System.Drawing.Size(570, 531);
            this.DocAreaPanel.TabIndex = 6;
            // 
            // DocFlowPanel
            // 
            this.DocFlowPanel.AutoScroll = true;
            this.DocFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocFlowPanel.Location = new System.Drawing.Point(6, 32);
            this.DocFlowPanel.Name = "DocFlowPanel";
            this.DocFlowPanel.Size = new System.Drawing.Size(558, 493);
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
            this.TagAreaPanel.ResumeLayout(false);
            this.TagAreaPanel.PerformLayout();
            this.DocAreaPanel.ResumeLayout(false);
            this.DocAreaPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBarPanel;
        private System.Windows.Forms.TextBox TagSearchTB;
        private System.Windows.Forms.TextBox DocSearchTB;
        private System.Windows.Forms.Panel TagAreaPanel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel DocAreaPanel;
        private System.Windows.Forms.FlowLayoutPanel TagFlowPanel;
        private System.Windows.Forms.FlowLayoutPanel DocFlowPanel;

    }
}

