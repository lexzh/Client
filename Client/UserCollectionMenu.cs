namespace Client
{
    using PublicClass;
    using Remoting;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public class UserCollectionMenu
    {
        private ContextMenuStrip _menu;
        private Dictionary<string, ToolStripMenuItem> _menuitem;

        public UserCollectionMenu(ContextMenuStrip menu, Dictionary<string, ToolStripMenuItem> menuitem)
        {
            this._menu = menu;
            this._menuitem = menuitem;
        }

        private DataTable getCollectMenuDatatable()
        {
            return RemotingClient.ExecSql(string.Concat(new object[] { "Exec WebGpsClient_GetMenuCollect '", Variable.sUserId, "',", Variable.iModuleId }));
        }

        public void LoadMenu()
        {
            DataTable table = this.getCollectMenuDatatable();
            if (((table != null) && (table.Rows.Count > 0)) && (this._menuitem != null))
            {
                if (this._menu.Items["userCollectionMenu"] == null)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem("收藏夹") {
                        Name = "userCollectionMenu"
                    };
                    this._menu.Items.Insert(0, item);
                }
                (this._menu.Items["userCollectionMenu"] as ToolStripMenuItem).DropDownItems.Clear();
                foreach (DataRow row in table.Rows)
                {
                    EventHandler handler = null;
                    ToolStripMenuItem item = (this._menuitem[row["MenuCode"].ToString().ToLower().Trim()] != null) ? this._menuitem[row["MenuCode"].ToString().ToLower().Trim()] : null;
                    if (item != null)
                    {
                        ToolStripMenuItem item2 = new ToolStripMenuItem(item.Text) {
                            Tag = item.Tag,
                            Name = item.Name
                        };
                        if (handler == null)
                        {
                            handler = (sender2, e2) => item.PerformClick();
                        }
                        item2.Click += handler;
                        (this._menu.Items["userCollectionMenu"] as ToolStripMenuItem).DropDownItems.Add(item2);
                    }
                }
            }
            else if (this._menu.Items["userCollectionMenu"] != null)
            {
                this._menu.Items.Remove(this._menu.Items["userCollectionMenu"]);
            }
        }
    }
}

