namespace Client
{
    partial class ToolWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolWindow));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemFloat = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUnFloat = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAutoHide = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHidden = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFloat,
            this.MenuItemUnFloat,
            this.MenuItemDocument,
            this.MenuItemAutoHide,
            this.MenuItemHidden});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(149, 114);
            // 
            // MenuItemFloat
            // 
            this.MenuItemFloat.Name = "MenuItemFloat";
            this.MenuItemFloat.Size = new System.Drawing.Size(148, 22);
            this.MenuItemFloat.Text = "浮动";
            this.MenuItemFloat.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // MenuItemUnFloat
            // 
            this.MenuItemUnFloat.Checked = true;
            this.MenuItemUnFloat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemUnFloat.Name = "MenuItemUnFloat";
            this.MenuItemUnFloat.Size = new System.Drawing.Size(148, 22);
            this.MenuItemUnFloat.Text = "可停靠";
            this.MenuItemUnFloat.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // MenuItemDocument
            // 
            this.MenuItemDocument.Name = "MenuItemDocument";
            this.MenuItemDocument.Size = new System.Drawing.Size(148, 22);
            this.MenuItemDocument.Text = "选项卡式停靠";
            this.MenuItemDocument.Visible = false;
            this.MenuItemDocument.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // MenuItemAutoHide
            // 
            this.MenuItemAutoHide.Name = "MenuItemAutoHide";
            this.MenuItemAutoHide.Size = new System.Drawing.Size(148, 22);
            this.MenuItemAutoHide.Text = "自动隐藏";
            this.MenuItemAutoHide.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // MenuItemHidden
            // 
            this.MenuItemHidden.Name = "MenuItemHidden";
            this.MenuItemHidden.Size = new System.Drawing.Size(148, 22);
            this.MenuItemHidden.Text = "隐藏";
            this.MenuItemHidden.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // ToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 247);
            this.DockAreas = ((WinFormsUI.Docking.DockAreas)(((((WinFormsUI.Docking.DockAreas.Float | WinFormsUI.Docking.DockAreas.DockLeft)
                        | WinFormsUI.Docking.DockAreas.DockRight)
                        | WinFormsUI.Docking.DockAreas.DockTop)
                        | WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ToolWindow";
            this.TabPageContextMenuStrip = this.contextMenu;
            this.TabText = "ToolWindow";
            this.Text = "ToolWindow";
            this.DockStateChanged += new System.EventHandler(this.ToolWindow_DockStateChanged);
            this.Load += new System.EventHandler(this.ToolWindow_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAutoHide;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDocument;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFloat;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHidden;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUnFloat;
    }
}
