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

    public partial class SetMenuCollection : FixedForm
    {
        private Dictionary<string, TreeNode> menuNode;
        private List<TreeNode> movelist;
        private Dictionary<string, TreeNode> parentNode;

        private SetMenuCollection()
        {
            this.parentNode = new Dictionary<string, TreeNode>();
            this.menuNode = new Dictionary<string, TreeNode>();
            this.movelist = new List<TreeNode>();
            this._selectNodeFullPath = "";
            this.InitializeComponent();
        }

        public SetMenuCollection(DataTable dt_menu) : this()
        {
            this.menulist_dt = dt_menu.Copy();
            DataColumn column = new DataColumn("isgroup", typeof(bool)) {
                DefaultValue = false
            };
            this.menulist_dt.Columns.Add(column);
        }

        private void addCollect()
        {
            if (this.movelist.Count != 0)
            {
                if (this.tvCollectList.Nodes["收藏夹"] == null)
                {
                    this.tvCollectList.Nodes.Add("收藏夹", "收藏夹");
                }
                this.movelist.ForEach(delegate (TreeNode no) {
                    if (Convert.ToBoolean((no.Tag as DataRow)["isgroup"]))
                    {
                        this.parentNode[(no.Tag as DataRow)["MenuName"].ToString()].Nodes.Remove(no);
                    }
                    else
                    {
                        this.tvMenuList.Nodes.Remove(no);
                    }
                    TreeNode node = no.Clone() as TreeNode;
                    this.tvCollectList.Nodes["收藏夹"].Nodes.Add(node);
                    node.Checked = false;
                });
                this.tvCollectList.Nodes["收藏夹"].Expand();
            }
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            this.movelist.Clear();
            this.getNode(this.tvMenuList.Nodes, true);
            this.addCollect();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            this.moveNode(false);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            this.moveNode(true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.movelist.Clear();
            this.getNode(this.tvCollectList.Nodes, false);
            this.movelist.ForEach(delegate (TreeNode no) {
                this.tvCollectList.Nodes["收藏夹"].Nodes.Remove(no);
                if (this.parentNode[(no.Tag as DataRow)["MenuName"].ToString()] == null)
                {
                    this.tvMenuList.Nodes.Add(no);
                }
                else
                {
                    this.parentNode[(no.Tag as DataRow)["MenuName"].ToString()].Nodes.Add(no);
                }
                no.Checked = false;
            });
            if (this.tvCollectList.Nodes[0].Nodes.Count == 0)
            {
                this.tvCollectList.Nodes.Clear();
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            string str = "";
            if ((this.tvCollectList.Nodes.Count != 0) && (this.tvCollectList.Nodes[0].Nodes.Count != 0))
            {
                foreach (TreeNode node in this.tvCollectList.Nodes[0].Nodes)
                {
                    str = str + (node.Tag as DataRow)["id"].ToString() + ",";
                }
            }
            str = str.Trim(new char[] { ',' });
            DataTable table = RemotingClient.ExecSql(string.Concat(new object[] { "exec [WebGpsClient_AddMenuCollect] N'", Variable.sUserId, "',", Variable.iModuleId, ",N'", str, "',NULL" }));
            if (((table != null) && (table.Rows.Count > 0)) && table.Rows[0][0].ToString().Equals("1"))
            {
                MessageBox.Show("设置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("设置失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

 private void getNode(TreeNodeCollection nodes, bool iscollect)
        {
            this._selectNodeFullPath = "";
            foreach (TreeNode node in nodes)
            {
                if (iscollect)
                {
                    if (Convert.ToBoolean((node.Tag as DataRow)["isgroup"]))
                    {
                        node.Checked = false;
                        this.getNode(node.Nodes, iscollect);
                    }
                    else if (node.Checked)
                    {
                        this.movelist.Add(node);
                    }
                }
                else if (node.Nodes.Count > 0)
                {
                    this.getNode(node.Nodes, iscollect);
                }
                else if (node.Checked)
                {
                    this.movelist.Add(node);
                }
            }
        }

 private void LoadCollectMenuList(DataRow[] rows, TreeNode parentNode)
        {
            foreach (DataRow row in rows)
            {
                TreeNode item = null;
                item = this.menuNode[row["MenuName"].ToString()];
                if (item != null)
                {
                    this.movelist.Add(item);
                }
            }
        }

        private void LoadMenuList(DataRow[] rows, TreeNode parentNode)
        {
            foreach (DataRow row in rows)
            {
                DataRow[] rowArray = this.menulist_dt.Select("ParentID='" + row["ID"].ToString() + "'");
                if ((row["ParentID"] != null) || (rowArray.Length != 0))
                {
                    TreeNode node = null;
                    if (parentNode == null)
                    {
                        this.tvMenuList.Nodes.Add(row["MenuName"].ToString(), row["MenuName"].ToString());
                        node = this.tvMenuList.Nodes[row["MenuName"].ToString()];
                    }
                    else
                    {
                        (parentNode.Tag as DataRow)["isgroup"] = true;
                        parentNode.Nodes.Add(row["MenuName"].ToString(), row["MenuName"].ToString());
                        node = parentNode.Nodes[row["MenuName"].ToString()];
                        this.menuNode[row["MenuName"].ToString()] = node;
                    }
                    node.Tag = row;
                    this.parentNode[row["MenuName"].ToString()] = parentNode;
                    this.LoadMenuList(rowArray, node);
                }
            }
        }

        private void moveNode(bool isup)
        {
            if ((this.tvCollectList.Nodes.Count != 0) && (this._selectNodeFullPath.Length != 0))
            {
                string[] strArray = this._selectNodeFullPath.Split(new char[] { '\\' });
                TreeNode node = null;
                foreach (string str in strArray)
                {
                    if (node == null)
                    {
                        node = this.tvCollectList.Nodes[str];
                    }
                    else
                    {
                        node = node.Nodes[str];
                    }
                }
                if (node != null)
                {
                    TreeNode parent = node.Parent;
                    int index = node.Index;
                    if (isup && (node.Index > 0))
                    {
                        node.Remove();
                        parent.Nodes.Insert(index - 1, node);
                        this.tvCollectList.SelectedNode = node;
                    }
                    else if (!isup && (node.Index < (node.Parent.Nodes.Count - 1)))
                    {
                        node.Remove();
                        parent.Nodes.Insert(index + 1, node);
                        this.tvCollectList.SelectedNode = node;
                    }
                }
            }
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            this.btnCollect.Enabled = this.btnRemove.Enabled = this.btnMoveUp.Enabled = this.btnMoveDown.Enabled = this.btnSet.Enabled = isuse;
        }

        private void SetMenuCollection_Load(object sender, EventArgs e)
        {
            this.LoadMenuList(this.menulist_dt.Select("ParentID is null", "MenuOrder"), null);
            this.SetControlEnable(false);
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate (object sender2, DoWorkEventArgs e2) {
                DataTable table = RemotingClient.ExecSql(string.Concat(new object[] { "Exec WebGpsClient_GetMenuCollect '", Variable.sUserId, "',", Variable.iModuleId }));
                if ((table != null) && (table.Rows.Count > 0))
                {
                    DataColumn column = new DataColumn("isGroup", typeof(bool)) {
                        DefaultValue = false
                    };
                    table.Columns.Add(column);
                    this.LoadCollectMenuList(table.Select("", "Sort"), null);
                }
            };
            worker.RunWorkerCompleted += delegate (object sender22, RunWorkerCompletedEventArgs e22) {
                this.addCollect();
                this.SetControlEnable(true);
            };
            worker.RunWorkerAsync();
        }

        private void SetNodeState(TreeNode node)
        {
            this.CheckAllChildNodes(node, node.Checked);
            bool flag = true;
            if (node.Parent != null)
            {
                for (int i = 0; i < node.Parent.Nodes.Count; i++)
                {
                    if (!node.Parent.Nodes[i].Checked)
                    {
                        flag = false;
                    }
                }
                node.Parent.Checked = flag;
            }
        }

        private void SetNodeState2(TreeNode node)
        {
            this.CheckAllChildNodes(node, node.Checked);
            bool flag = true;
            if (node.Parent != null)
            {
                for (int i = 0; i < node.Parent.Nodes.Count; i++)
                {
                    if (!node.Parent.Nodes[i].Checked)
                    {
                        flag = false;
                    }
                }
                TreeNode parent = node;
                while (parent.Parent != null)
                {
                    parent = parent.Parent;
                    parent.Checked = flag;
                }
                parent.Checked = flag;
            }
        }

        private void tvCollectList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this._selectNodeFullPath = e.Node.FullPath;
        }

        private void tvMenuList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                this.SetNodeState(e.Node);
            }
        }
    }
}

