namespace Client
{
    partial class Map
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            this.picLoadMap = new System.Windows.Forms.PictureBox();
            this.ctxMenuMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuClearAllCar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClearAlarmRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClearImage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuZoomToMapCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.wbMap = new WinFormsUI.Controls.GisMap();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadMap)).BeginInit();
            this.ctxMenuMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLoadMap
            // 
            this.picLoadMap.Image = ((System.Drawing.Image)(resources.GetObject("picLoadMap.Image")));
            this.picLoadMap.Location = new System.Drawing.Point(280, 231);
            this.picLoadMap.Name = "picLoadMap";
            this.picLoadMap.Size = new System.Drawing.Size(167, 34);
            this.picLoadMap.TabIndex = 2;
            this.picLoadMap.TabStop = false;
            // 
            // ctxMenuMap
            // 
            this.ctxMenuMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuClearAllCar,
            this.MenuClearAlarmRegion,
            this.MenuDelPoint,
            this.MenuClearImage,
            this.MenuAddPoint,
            this.MenuZoomToMapCenter});
            this.ctxMenuMap.Name = "ctxMenuMap";
            this.ctxMenuMap.Size = new System.Drawing.Size(173, 136);
            // 
            // MenuClearAllCar
            // 
            this.MenuClearAllCar.Name = "MenuClearAllCar";
            this.MenuClearAllCar.Size = new System.Drawing.Size(172, 22);
            this.MenuClearAllCar.Text = "清除所有车辆";
            this.MenuClearAllCar.ToolTipText = "清除所有车辆";
            // 
            // MenuClearAlarmRegion
            // 
            this.MenuClearAlarmRegion.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.MenuClearAlarmRegion.Name = "MenuClearAlarmRegion";
            this.MenuClearAlarmRegion.Size = new System.Drawing.Size(172, 22);
            this.MenuClearAlarmRegion.Text = "清除报警范围";
            this.MenuClearAlarmRegion.ToolTipText = "清除报警范围";
            // 
            // MenuDelPoint
            // 
            this.MenuDelPoint.Name = "MenuDelPoint";
            this.MenuDelPoint.Size = new System.Drawing.Size(172, 22);
            this.MenuDelPoint.Text = "删除单个地图标注";
            this.MenuDelPoint.ToolTipText = "删除单个地图标注";
            // 
            // MenuClearImage
            // 
            this.MenuClearImage.Name = "MenuClearImage";
            this.MenuClearImage.Size = new System.Drawing.Size(172, 22);
            this.MenuClearImage.Text = "删除指示图标";
            this.MenuClearImage.ToolTipText = "删除指示图标";
            // 
            // MenuAddPoint
            // 
            this.MenuAddPoint.Name = "MenuAddPoint";
            this.MenuAddPoint.Size = new System.Drawing.Size(172, 22);
            this.MenuAddPoint.Text = "添加标注";
            this.MenuAddPoint.ToolTipText = "添加标注";
            // 
            // MenuZoomToMapCenter
            // 
            this.MenuZoomToMapCenter.Name = "MenuZoomToMapCenter";
            this.MenuZoomToMapCenter.Size = new System.Drawing.Size(172, 22);
            this.MenuZoomToMapCenter.Text = "跳转到标志点";
            // 
            // wbMap
            // 
            this.wbMap.ContextMenuStrip = this.ctxMenuMap;
            this.wbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMap.IsWebBrowserContextMenuEnabled = false;
            this.wbMap.Location = new System.Drawing.Point(0, 0);
            this.wbMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMap.Name = "wbMap";
            this.wbMap.ScrollBarsEnabled = false;
            this.wbMap.Size = new System.Drawing.Size(726, 496);
            this.wbMap.TabIndex = 3;
            this.wbMap.Tag = "9999";
            this.wbMap.Url = new System.Uri("", System.UriKind.Relative);
            this.wbMap.WebBrowserShortcutsEnabled = false;
            this.wbMap.MapSelectedCarEvent += new System.Windows.Forms.HtmlElementEventHandler(this.wbMap_MapSelectedCarEvent);
            this.wbMap.MapEndSelectSpace += new System.Windows.Forms.HtmlElementEventHandler(this.wbMap_EndSelectSpace);
            this.wbMap.MapDirectionEvent += new System.Windows.Forms.HtmlElementEventHandler(this.wbMap_MapDirectionEvent);
            this.wbMap.MapMouseUp += new System.Windows.Forms.HtmlElementEventHandler(this.wbMap_MouseUp);
            this.wbMap.MapMouseMove += new System.Windows.Forms.HtmlElementEventHandler(this.wbMap_MouseMove);
            this.wbMap.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbMap_DocumentCompleted);
            this.wbMap.MapSpatialEvent += new System.Windows.Forms.HtmlElementEventHandler(this.wbMap_MapSpatialEvent);
            this.MenuClearAllCar.Click += new System.EventHandler(this.MenuClearAllCar_Click);
            this.MenuClearAlarmRegion.Click += new System.EventHandler(this.MenuClearAlarmRegion_Click);
            this.MenuDelPoint.Click += new System.EventHandler(this.MenuDelPoint_Click);
            this.MenuClearImage.Click += new System.EventHandler(this.MenuClearImage_Click);
            this.MenuAddPoint.Click += new System.EventHandler(this.MenuAddPoint_Click);
            this.MenuZoomToMapCenter.Click += new System.EventHandler(this.MenuZoomToMapCenter_Click);
            base.Load += new System.EventHandler(this.Map_Load);
            base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Map_FormClosed);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(726, 496);
            this.Controls.Add(this.picLoadMap);
            this.Controls.Add(this.wbMap);
            this.Name = "Map";
            ((System.ComponentModel.ISupportInitialize)(this.picLoadMap)).EndInit();
            this.ctxMenuMap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLoadMap;
        private System.Windows.Forms.ContextMenuStrip ctxMenuMap;
        private System.Windows.Forms.ToolStripMenuItem MenuClearAllCar;
        private System.Windows.Forms.ToolStripMenuItem MenuClearAlarmRegion;
        private System.Windows.Forms.ToolStripMenuItem MenuDelPoint;
        private System.Windows.Forms.ToolStripMenuItem MenuClearImage;
        private System.Windows.Forms.ToolStripMenuItem MenuAddPoint;
        private System.Windows.Forms.ToolStripMenuItem MenuZoomToMapCenter;
        public WinFormsUI.Controls.GisMap wbMap;
    }
}
