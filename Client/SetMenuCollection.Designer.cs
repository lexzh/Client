namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    partial class SetMenuCollection
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

       
        private void InitializeComponent()
        {
            this.grbMenuList = new GroupBox();
            this.tvMenuList = new TreeView();
            this.grbCollectList = new GroupBox();
            this.tvCollectList = new TreeView();
            this.btnCollect = new Button();
            this.btnRemove = new Button();
            this.btnSet = new Button();
            this.panel1 = new Panel();
            this.btnMoveDown = new Button();
            this.btnMoveUp = new Button();
            this.pnlWait = new Panel();
            this.pbPicWait = new PictureBox();
            this.lblWaitText = new Label();
            this.grbMenuList.SuspendLayout();
            this.grbCollectList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlWait.SuspendLayout();
            ((ISupportInitialize) this.pbPicWait).BeginInit();
            base.SuspendLayout();
            this.grbMenuList.Controls.Add(this.tvMenuList);
            this.grbMenuList.Location = new Point(16, 12);
            this.grbMenuList.Name = "grbMenuList";
            this.grbMenuList.Size = new Size(252, 400);
            this.grbMenuList.TabIndex = 0;
            this.grbMenuList.TabStop = false;
            this.grbMenuList.Text = "菜单列表";
            this.tvMenuList.CheckBoxes = true;
            this.tvMenuList.Dock = DockStyle.Fill;
            this.tvMenuList.Location = new Point(3, 17);
            this.tvMenuList.Name = "tvMenuList";
            this.tvMenuList.Size = new Size(246, 380);
            this.tvMenuList.TabIndex = 0;
            this.tvMenuList.AfterCheck += new TreeViewEventHandler(this.tvMenuList_AfterCheck);
            this.grbCollectList.Controls.Add(this.tvCollectList);
            this.grbCollectList.Location = new Point(356, 12);
            this.grbCollectList.Name = "grbCollectList";
            this.grbCollectList.Size = new Size(252, 400);
            this.grbCollectList.TabIndex = 1;
            this.grbCollectList.TabStop = false;
            this.grbCollectList.Text = "收藏夹";
            this.tvCollectList.CheckBoxes = true;
            this.tvCollectList.Dock = DockStyle.Fill;
            this.tvCollectList.Location = new Point(3, 17);
            this.tvCollectList.Name = "tvCollectList";
            this.tvCollectList.Size = new Size(246, 380);
            this.tvCollectList.TabIndex = 1;
            this.tvCollectList.AfterCheck += new TreeViewEventHandler(this.tvMenuList_AfterCheck);
            this.tvCollectList.AfterSelect += new TreeViewEventHandler(this.tvCollectList_AfterSelect);
            this.btnCollect.Location = new Point(275, 147);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new Size(75, 23);
            this.btnCollect.TabIndex = 2;
            this.btnCollect.Text = "收藏>>";
            this.btnCollect.UseVisualStyleBackColor = true;
            this.btnCollect.Click += new EventHandler(this.btnCollect_Click);
            this.btnRemove.Location = new Point(274, 216);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "<<移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
            this.btnSet.Location = new Point(312, 7);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new Size(75, 23);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "设置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new EventHandler(this.btnSet_Click);
            this.panel1.Controls.Add(this.pnlWait);
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(0, 418);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(699, 36);
            this.panel1.TabIndex = 5;
            this.btnMoveDown.Location = new Point(612, 216);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new Size(75, 23);
            this.btnMoveDown.TabIndex = 7;
            this.btnMoveDown.Text = "下移";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new EventHandler(this.btnMoveDown_Click);
            this.btnMoveUp.Location = new Point(613, 147);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new Size(75, 23);
            this.btnMoveUp.TabIndex = 6;
            this.btnMoveUp.Text = "上移";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new EventHandler(this.btnMoveUp_Click);
            this.pnlWait.Controls.Add(this.pbPicWait);
            this.pnlWait.Controls.Add(this.lblWaitText);
            this.pnlWait.Location = new Point(16, 7);
            this.pnlWait.Name = "pnlWait";
            this.pnlWait.Size = new Size(129, 22);
            this.pnlWait.TabIndex = 15;
            this.pnlWait.Tag = "9999";
            this.pbPicWait.BackColor = Color.Transparent;
            this.pbPicWait.Image = Resources.loading;
            this.pbPicWait.InitialImage = null;
            this.pbPicWait.Location = new Point(3, 3);
            this.pbPicWait.Name = "pbPicWait";
            this.pbPicWait.Size = new Size(16, 16);
            this.pbPicWait.TabIndex = 11;
            this.pbPicWait.TabStop = false;
            this.pbPicWait.Tag = "9999";
            this.pbPicWait.Visible = false;
            this.lblWaitText.AutoSize = true;
            this.lblWaitText.Location = new Point(22, 5);
            this.lblWaitText.Name = "lblWaitText";
            this.lblWaitText.Size = new Size(89, 12);
            this.lblWaitText.TabIndex = 9;
            this.lblWaitText.Text = "正在加载中....";
            this.lblWaitText.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(699, 454);
            base.Controls.Add(this.btnMoveDown);
            base.Controls.Add(this.btnMoveUp);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.btnRemove);
            base.Controls.Add(this.btnCollect);
            base.Controls.Add(this.grbCollectList);
            base.Controls.Add(this.grbMenuList);
            base.Name = "SetMenuCollection";
            this.Text = "MenuCollection";
            base.Load += new EventHandler(this.SetMenuCollection_Load);
            this.grbMenuList.ResumeLayout(false);
            this.grbCollectList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlWait.ResumeLayout(false);
            this.pnlWait.PerformLayout();
            ((ISupportInitialize) this.pbPicWait).EndInit();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private string _selectNodeFullPath;
        private Button btnCollect;
        private Button btnMoveDown;
        private Button btnMoveUp;
        private Button btnRemove;
        private Button btnSet;
        private GroupBox grbCollectList;
        private GroupBox grbMenuList;
        private Label lblWaitText;
        private DataTable menulist_dt;
        private Panel panel1;
        private PictureBox pbPicWait;
        private Panel pnlWait;
        private TreeView tvCollectList;
        private TreeView tvMenuList;
    }
}