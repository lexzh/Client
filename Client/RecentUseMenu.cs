namespace Client
{
    using Properties;
    using PublicClass;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class RecentUseMenu
    {
        private Dictionary<string, ToolStripMenuItem> _allowUseMenu;
        private int _maxRecentMenuCount = 15;
        private ContextMenuStrip _menu;
        private EventHandler _menuEvent;
        private RecentUseMenuCollection _menulist;
        private const string GrantType = "1";

        public RecentUseMenu(ContextMenuStrip menu, EventHandler menuEvent, Dictionary<string, ToolStripMenuItem> allowUseMenu)
        {
            this._menu = menu;
            this._menuEvent = menuEvent;
            this._allowUseMenu = allowUseMenu;
            this._menulist = new RecentUseMenuCollection();
            this.ReadMenu();
        }

        public void AddMenu(string menuKey, string menuText)
        {
            menuKey = menuKey.Trim().ToLower();
            if (this._menulist[menuKey] == null)
            {
                RecentUseMenuCollection item = new RecentUseMenuCollection {
                    UseCount = 1,
                    UseTime = DateTime.Now,
                    MenuKey = menuKey,
                    MenuText = menuText
                };
                this._menulist.Add(item);
            }
            else if (this._menulist[menuKey].UseCount < 2147483637)
            {
                this._menulist[menuKey].UseCount++;
                this._menulist[menuKey].UseTime = DateTime.Now;
            }
            else
            {
                int num = this._maxRecentMenuCount;
                for (int i = 0; i < this._menulist.Count; i++)
                {
                    this._menulist[i].UseCount = num;
                    num--;
                    if (i >= 15)
                    {
                        this._menulist.Remove(this._menulist[i]);
                    }
                }
            }
            this._menulist.Sort();
            this.LoadMenu();
        }

        public void LoadMenu()
        {
            if ((this._menulist.Count > 0) && (this._menu.Items["RecentUseMenu"] == null))
            {
                ToolStripMenuItem item = new ToolStripMenuItem("最近使用") {
                    Name = "RecentUseMenu"
                };
                this._menu.Items.Insert(0, item);
            }
            if (this._menu.Items["RecentUseMenu"] != null)
            {
                ToolStripMenuItem temp = this._menu.Items["RecentUseMenu"] as ToolStripMenuItem;
                foreach (RecentUseMenuCollection menus in this._menulist)
                {
                    ToolStripMenuItem item2 = null;
                    if (temp.DropDownItems.ContainsKey(menus.MenuKey))
                    {
                        item2 = temp.DropDownItems[menus.MenuKey] as ToolStripMenuItem;
                    }
                    else
                    {
                        item2 = new ToolStripMenuItem(menus.MenuText) {
                            Name = menus.MenuKey
                        };
                        item2.Click += this._menuEvent;
                        item2.Tag = menus.MenuKey;
                    }
                    temp.DropDownItems.Add(item2);
                }
                List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();
                for (int i = this._maxRecentMenuCount; i < temp.DropDownItems.Count; i++)
                {
                    list.Add(temp.DropDownItems[i] as ToolStripMenuItem);
                }
                list.ForEach(item => temp.DropDownItems.Remove(item));
                list = null;
            }
        }

        private void ReadMenu()
        {
            if (Settings.Default.RecentUseMenu.Trim().Length > 0)
            {
                try
                {
                    Dictionary<string, string> dictionary = SerializableHelper.DeSerialize<Dictionary<string, string>>(Settings.Default.RecentUseMenu);
                    if ((dictionary != null) && dictionary.ContainsKey(Variable.sUserId))
                    {
                        Action<RecentUseMenuCollection> action = null;
                        string fi = dictionary[Variable.sUserId];
                        RecentUseMenuCollection temp = SerializableHelper.DeSerialize<RecentUseMenuCollection>(fi);
                        if (temp != null)
                        {
                            if ((this._allowUseMenu == null) || (this._allowUseMenu.Count == 0))
                            {
                                temp.Clear();
                            }
                            else
                            {
                                List<RecentUseMenuCollection> list = new List<RecentUseMenuCollection>();
                                foreach (RecentUseMenuCollection menus in temp)
                                {
                                    if (!this._allowUseMenu.ContainsKey(menus.MenuKey.ToLower() + "1"))
                                    {
                                        list.Add(menus);
                                    }
                                }
                                if (action == null)
                                {
                                    action = obj => temp.Remove(obj);
                                }
                                list.ForEach(action);
                            }
                            this._menulist = temp;
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public void SaveMenu()
        {
            if (this._menulist != null)
            {
                Dictionary<string, string> t = null;
                if (Settings.Default.RecentUseMenu.Trim().Length > 0)
                {
                    try
                    {
                        t = SerializableHelper.DeSerialize<Dictionary<string, string>>(Settings.Default.RecentUseMenu);
                    }
                    catch
                    {
                    }
                }
                if (t == null)
                {
                    t = new Dictionary<string, string>();
                }
                t[Variable.sUserId] = SerializableHelper.SerializeToString<RecentUseMenuCollection>(this._menulist);
                Settings.Default.RecentUseMenu = SerializableHelper.SerializeToString<Dictionary<string, string>>(t);
                Settings.Default.Save();
            }
        }

        public void SetMenuEnable(string menukey, bool isEnable)
        {
            if (this._menu.Items["RecentUseMenu"] != null)
            {
                ToolStripItem[] itemArray = (this._menu.Items["RecentUseMenu"] as ToolStripMenuItem).DropDownItems.Find(menukey, true);
                if ((itemArray != null) && (itemArray.Length > 0))
                {
                    itemArray[0].Enabled = isEnable;
                }
            }
        }
    }
}

