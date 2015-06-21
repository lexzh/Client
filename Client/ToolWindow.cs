using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsUI.Docking;

namespace Client
{
    public partial class ToolWindow : WinFormsUI.Docking.DockContent
    {
        private DockAreas m_oldDockAreas;
        private DockState m_oldDockState;
        public static MainForm myMainForm;

        public ToolWindow()
        {
            InitializeComponent();
            this.contextMenu = base.TabPageContextMenuStrip;
            this.m_oldDockAreas = base.DockAreas;
        }

        private bool IsDockStateAutoHide(DockState dockState)
        {
            if (((dockState != DockState.DockLeftAutoHide) && (dockState != DockState.DockRightAutoHide)) && ((dockState != DockState.DockTopAutoHide) && (dockState != DockState.DockBottomAutoHide)))
            {
                return false;
            }
            return true;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item2 in this.contextMenu.Items)
            {
                if (item2.Name == item.Name)
                {
                    item2.Checked = true;
                }
                else
                {
                    item2.Checked = false;
                }
            }
            string name = item.Name;
            if (name != null)
            {
                if (!(name == "MenuItemFloat"))
                {
                    if (!(name == "MenuItemUnFloat"))
                    {
                        if (!(name == "MenuItemDocument"))
                        {
                            if (!(name == "MenuItemAutoHide"))
                            {
                                if (name == "MenuItemHidden")
                                {
                                    base.IsHidden = true;
                                }
                                return;
                            }
                            if (!this.IsDockStateAutoHide(base.DockState))
                            {
                                base.DockPanel.ActiveContent.DockHandler.GiveUpFocus();
                            }
                            else
                            {
                                this.MenuItemAutoHide.Checked = false;
                                this.MenuItemUnFloat.Checked = true;
                            }
                            base.DockState = this.ToggleAutoHideState(base.DockState);
                            return;
                        }
                        base.DockAreas = this.m_oldDockAreas | DockAreas.Document;
                        base.DockState = DockState.Document;
                        base.DockAreas = DockAreas.Document | DockAreas.Float;
                        return;
                    }
                }
                else
                {
                    base.IsFloat = true;
                    return;
                }
                base.DockAreas = this.m_oldDockAreas | DockAreas.Document;
                if (this.IsDockStateAutoHide(base.DockState))
                {
                    base.DockState = this.ToggleAutoHideState(base.DockState);
                }
                base.IsFloat = false;
                if (base.DockState == DockState.Document)
                {
                    base.DockState = this.m_oldDockState;
                }
                base.DockAreas = this.m_oldDockAreas;
            }
        }

        public void SetDocument()
        {
            base.DockAreas = DockAreas.Document;
            this.MenuItemFloat.Visible = false;
            this.MenuItemUnFloat.Visible = false;
            this.MenuItemDocument.Visible = false;
            this.MenuItemAutoHide.Visible = false;
            this.MenuItemHidden.Visible = false;
        }

        private DockState ToggleAutoHideState(DockState state)
        {
            if (state == DockState.DockLeft)
            {
                return DockState.DockLeftAutoHide;
            }
            if (state == DockState.DockRight)
            {
                return DockState.DockRightAutoHide;
            }
            if (state == DockState.DockTop)
            {
                return DockState.DockTopAutoHide;
            }
            if (state == DockState.DockBottom)
            {
                return DockState.DockBottomAutoHide;
            }
            if (state == DockState.DockLeftAutoHide)
            {
                return DockState.DockLeft;
            }
            if (state == DockState.DockRightAutoHide)
            {
                return DockState.DockRight;
            }
            if (state == DockState.DockTopAutoHide)
            {
                return DockState.DockTop;
            }
            if (state == DockState.DockBottomAutoHide)
            {
                return DockState.DockBottom;
            }
            return state;
        }

        private void ToolWindow_DockStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (base.DockState != DockState.Unknown)
                {
                    this.MenuItemHidden.Checked = false;
                    this.MenuItemAutoHide.Checked = false;
                    this.MenuItemAutoHide.Enabled = true;
                    this.MenuItemFloat.Enabled = true;
                    this.MenuItemUnFloat.Enabled = true;
                    this.MenuItemDocument.Enabled = true;
                    if (base.DockState == DockState.Float)
                    {
                        this.MenuItemAutoHide.Enabled = false;
                        this.MenuItemFloat.Checked = true;
                        this.MenuItemUnFloat.Checked = false;
                        this.MenuItemDocument.Checked = false;
                    }
                    else if (base.DockState == DockState.Document)
                    {
                        this.MenuItemAutoHide.Enabled = false;
                        this.MenuItemDocument.Checked = true;
                        this.MenuItemFloat.Checked = false;
                        this.MenuItemUnFloat.Checked = false;
                    }
                    else if (this.IsDockStateAutoHide(base.DockState))
                    {
                        this.MenuItemUnFloat.Checked = false;
                        this.MenuItemAutoHide.Checked = true;
                        this.MenuItemFloat.Enabled = false;
                        this.MenuItemUnFloat.Enabled = false;
                        this.MenuItemDocument.Enabled = false;
                    }
                    else
                    {
                        if (!this.IsDockStateAutoHide(base.DockState))
                        {
                            this.MenuItemFloat.Checked = false;
                            this.MenuItemUnFloat.Checked = true;
                            this.MenuItemDocument.Checked = false;
                            this.m_oldDockState = base.DockState;
                        }
                        if (base.DockState == DockState.Hidden)
                        {
                            myMainForm.setMenuCheck(base.TabText, false);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void ToolWindow_Load(object sender, EventArgs e)
        {
            if (base.DockState == DockState.Document)
            {
                base.DockAreas = DockAreas.Document | DockAreas.Float;
            }
            else
            {
                base.DockAreas = this.m_oldDockAreas;
            }
        }
    }
}
