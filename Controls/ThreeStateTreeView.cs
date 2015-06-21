namespace WinFormsUI.Controls
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using WinFormsUI.Properties;

    public partial class ThreeStateTreeView : TreeView
    {
        public bool AllowCheck;
        public Hashtable areaNodeHashTable = new Hashtable();
        public Hashtable hasAreaPath = new Hashtable();
        public Hashtable hasCarPath = new Hashtable();
        private ImageList imageList = new ImageList();
        private bool isMulSelect = true;
        private ArrayList m_coll = new ArrayList();

        public event EventHandler<TriStateEventArgs> AfterThiStateChanged;

        public event TreeNodeChangedHandle TreeNodeChanged;

        public ThreeStateTreeView()
        {
            this.imageList.ImageSize = new Size(16, 16);
            this.imageList.Images.Add(Resources.Checked0, Color.White);
            this.imageList.Images.Add(Resources.Checked1, Color.White);
            this.imageList.Images.Add(Resources.Checked2, Color.White);
            this.imageList.Images.Add(Resources.Checked3, Color.White);
        }

        public void AddAreaNodeHashTable(ThreeStateTreeNode myNode)
        {
            if (myNode != null)
            {
                if (myNode.Parent == null)
                {
                    if (!this.areaNodeHashTable.ContainsKey(myNode.Name))
                    {
                        this.areaNodeHashTable.Add(myNode.Name, myNode);
                    }
                }
                else if (myNode.Parent.IsExpanded)
                {
                    if (!this.areaNodeHashTable.ContainsKey(myNode.Name))
                    {
                        this.areaNodeHashTable.Add(myNode.Name, myNode);
                        do
                        {
                            myNode = (ThreeStateTreeNode) myNode.Parent;
                            this.AddAreaNodeHashTable(myNode);
                        }
                        while (myNode.Parent != null);
                    }
                }
                else
                {
                    do
                    {
                        myNode = (ThreeStateTreeNode) myNode.Parent;
                        this.AddAreaNodeHashTable(myNode);
                    }
                    while (myNode.Parent != null);
                }
            }
        }

        public void CheckChang(ThreeStateTreeNode currNode)
        {
            this.AllowCheck = true;
            currNode.Checked = !currNode.Checked;
            this.AllowCheck = false;
            if (currNode.Checked)
            {
                currNode.CheckState = TriState.Checked;
            }
            else
            {
                currNode.CheckState = TriState.Unchecked;
            }
            foreach (ThreeStateTreeNode node in currNode.Nodes)
            {
                this.SetNodeTriState(node);
            }
            this.RecursiveSetNodeTriState(currNode);
        }

        public void DelAreaNodeHashTable(ThreeStateTreeNode myNode)
        {
            if (this.areaNodeHashTable.ContainsKey(myNode.Name))
            {
                this.areaNodeHashTable.Remove(myNode.Name);
            }
        }

        public ThreeStateTreeNode getAreaById(string sAreaId)
        {
            try
            {
                return (this.hasAreaPath[sAreaId] as ThreeStateTreeNode);
            }
            catch
            {
                return null;
            }
        }

        public ThreeStateTreeNode getCar(ThreeStateTreeNode tnNode, string sSearchType, string sSearchValue)
        {
            ThreeStateTreeNode node;
            if (tnNode == null)
            {
                node = base.Nodes[0] as ThreeStateTreeNode;
            }
            else
            {
                node = this.getNextNode(tnNode);
            }
            ThreeStateTreeNode node2 = node;
            do
            {
                string carId = "";
                string str2 = sSearchType;
                if (str2 != null)
                {
                    if (!(str2 == "CarNum"))
                    {
                        if (str2 == "CarId")
                        {
                            carId = node.CarId;
                        }
                        else if (str2 == "SimNum")
                        {
                            carId = node.SimNum;
                        }
                    }
                    else
                    {
                        carId = node.CarNum;
                    }
                }
                if (carId.IndexOf(sSearchValue) >= 0)
                {
                    return node;
                }
                node = this.getNextNode(node);
            }
            while (node2 != node);
            return null;
        }

        public ThreeStateTreeNode getNextNode(ThreeStateTreeNode tnNode)
        {
            if (base.Nodes.Count == 0)
            {
                return null;
            }
            ThreeStateTreeNode nextVisibleNode = tnNode.NextVisibleNode as ThreeStateTreeNode;
            if (nextVisibleNode == null)
            {
                nextVisibleNode = base.Nodes[0] as ThreeStateTreeNode;
            }
            return nextVisibleNode;
        }

        public ThreeStateTreeNode getNodeById(string sCarId)
        {
            try
            {
                return (this.hasCarPath[sCarId] as ThreeStateTreeNode);
            }
            catch
            {
                return null;
            }
        }

        public ThreeStateTreeNode getNodeByPath(string sFullPath)
        {
            try
            {
                string[] strArray = sFullPath.Split(new char[] { '\\' });
                TreeNode node = base.Nodes[strArray[0]];
                for (int i = 1; i < strArray.Length; i++)
                {
                    node = node.Nodes[strArray[i]];
                }
                return (node as ThreeStateTreeNode);
            }
            catch
            {
                return null;
            }
        }

        private void HighlightNode(TreeNode node)
        {
            node.BackColor = SystemColors.Highlight;
            node.ForeColor = SystemColors.HighlightText;
        }

        public virtual void Initialize()
        {
            base.Sorted = false;
            base.ShowRootLines = false;
            base.Indent = 15;
            base.ItemHeight = 18;
        }

 private void LowlightNode(TreeNode node)
        {
            node.BackColor = this.BackColor;
            node.ForeColor = SystemColors.ControlText;
        }

        private void MulSelectNode(TreeNode node, bool mustSelect)
        {
            this.MulSelected = true;
            if (this.m_coll.Contains(node) && !mustSelect)
            {
                this.m_coll.Remove(node);
                this.LowlightNode(node);
                this.SetCurrentNode((TreeNode) this.m_coll[this.m_coll.Count - 1]);
            }
            else
            {
                this.m_coll.Add(node);
                if (this.m_coll.Count == 1)
                {
                    IntPtr lparam = (node == null) ? IntPtr.Zero : node.Handle;
                    this.SendMessage(4363, 9, lparam);
                }
                else
                {
                    if (this.m_coll.Count == 2)
                    {
                        this.HighlightNode(this.m_coll[0] as TreeNode);
                    }
                    this.HighlightNode(node);
                }
                this.SetCurrentNode(node);
            }
        }

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            base.OnAfterCheck(e);
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            if ((this.MulSelected && (base.SelectedNode != this.currentNode)) && ((this.currentNode != null) && (this.currentNode.TreeView != null)))
            {
                IntPtr lparam = (this.currentNode == null) ? IntPtr.Zero : this.currentNode.Handle;
                this.SendMessage(4363, 9, lparam);
            }
            base.OnAfterSelect(e);
        }

        protected virtual void OnAfterTriStateChanged(TriStateEventArgs e)
        {
            if (this.AfterThiStateChanged != null)
            {
                this.AfterThiStateChanged(this, e);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.SetStateImageList();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            try
            {
                TreeNode nodeAt = base.GetNodeAt(e.X, e.Y);
                if (nodeAt != null)
                {
                    if (this.isMulSelect)
                    {
                        if ((this.m_coll.Count != 1) || (this.m_coll[0] != nodeAt))
                        {
                            if ((Control.ModifierKeys & Keys.Control) != Keys.None)
                            {
                                this.MulSelectNode(nodeAt, e.Button == MouseButtons.Right);
                            }
                            else if ((Control.ModifierKeys & Keys.Shift) != Keys.None)
                            {
                                this.ShiftMulSelectNode(nodeAt, e.Button == MouseButtons.Right);
                            }
                            else
                            {
                                this.SingleSelectNode(nodeAt);
                            }
                        }
                    }
                    else
                    {
                        this.SetCurrentNode(nodeAt);
                    }
                }
            }
            catch
            {
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (this.m_coll.Count > 1))
            {
                base.SelectedNode = null;
                base.OnMouseUp(e);
            }
            else
            {
                if (((base.SelectedNode != this.currentNode) && (this.currentNode != null)) && (this.currentNode.TreeView != null))
                {
                    IntPtr lparam = (this.currentNode == null) ? IntPtr.Zero : this.currentNode.Handle;
                    this.SendMessage(4363, 9, lparam);
                }
                base.OnMouseUp(e);
            }
        }

        public void RecursiveSetNodeTriState(ThreeStateTreeNode node)
        {
            this.SimapleSetNodeTriState(node);
            if (node.Parent != null)
            {
                this.RecursiveSetNodeTriState((ThreeStateTreeNode) node.Parent);
            }
        }

        public void SelectNode(TreeNode node)
        {
            this.SingleSelectNode(node);
            this.HighlightNode(node);
            this.MulSelected = true;
        }

        internal IntPtr SendMessage(int msg, int wparam, IntPtr lparam)
        {
            return SendMessage(new HandleRef(this, base.Handle), msg, (IntPtr) wparam, lparam);
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public void SetCurrentNode(TreeNode node)
        {
            if (this.currentNode != node)
            {
                this.currentNode = node;
                if (this.TreeNodeChanged != null)
                {
                    this.TreeNodeChanged(this.currentNode, EventArgs.Empty);
                }
            }
        }

        public void setMulSelectNodes(TreeNode node)
        {
            this.MulSelectNode(node, true);
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode node2 in node.Nodes)
                {
                    this.setMulSelectNodes(node2);
                }
            }
        }

        public void SetNodeTriState(ThreeStateTreeNode currNode)
        {
            currNode.CheckState = ((ThreeStateTreeNode) currNode.Parent).CheckState;
            if (currNode.Nodes.Count > 0)
            {
                foreach (ThreeStateTreeNode node in currNode.Nodes)
                {
                    node.CheckState = currNode.CheckState;
                    this.SetNodeTriState(node);
                }
            }
        }

        public void SetSelectedNodes(ThreeStateTreeNode myNode)
        {
            this.m_coll.Clear();
            this.m_coll.Add(myNode);
        }

        public void setSelectNode(TreeNode node)
        {
            if (this.MulSelected)
            {
                foreach (TreeNode node2 in this.SelectedNodes)
                {
                    this.LowlightNode(node2);
                }
            }
            this.MulSelected = false;
            this.SelectedNodes.Clear();
            this.SelectedNodes.Add(node);
            this.SetCurrentNode(node);
            base.SelectedNode = node;
        }

        public void SetStateImageList()
        {
            WinFormsUI.Controls.NativeMethods.SendMessage(new HandleRef(this, base.Handle), 4361, 2, (int) this.imageList.Handle);
        }

        private void ShiftMulSelectNode(TreeNode node, bool mustSelect)
        {
            this.MulSelected = true;
            if (this.m_coll.Contains(node) && !mustSelect)
            {
                this.m_coll.Remove(node);
                this.LowlightNode(node);
                this.SetCurrentNode((TreeNode) this.m_coll[this.m_coll.Count - 1]);
            }
            else if (node.Parent == this.currentNode.Parent)
            {
                TreeNode item = node;
                for (int i = Math.Abs((int) (this.currentNode.Index - node.Index)); i > 0; i--)
                {
                    if (!this.m_coll.Contains(item))
                    {
                        this.m_coll.Add(item);
                        if (this.m_coll.Count == 1)
                        {
                            IntPtr lparam = (item == null) ? IntPtr.Zero : node.Handle;
                            this.SendMessage(4363, 9, lparam);
                        }
                        else
                        {
                            this.HighlightNode(item);
                        }
                    }
                    item = (this.currentNode.Index > node.Index) ? item.NextNode : item.PrevNode;
                }
                this.HighlightNode(this.m_coll[0] as TreeNode);
                this.SetCurrentNode(node);
            }
        }

        public void SimapleSetNodeTriState(ThreeStateTreeNode currNode)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int count = currNode.Nodes.Count;
            if (currNode.Nodes.Count > 0)
            {
                foreach (ThreeStateTreeNode node in currNode.Nodes)
                {
                    if (node.Checked)
                    {
                        num2++;
                    }
                    else if (!node.Checked)
                    {
                        num3++;
                    }
                    if (node.CheckState == TriState.Indeterminate)
                    {
                        num++;
                        break;
                    }
                }
            }
            if ((num > 0) || ((num2 > 0) && (num3 > 0)))
            {
                currNode.CheckState = TriState.Indeterminate;
            }
            else if ((num2 > 0) && (num3 == 0))
            {
                currNode.CheckState = TriState.Checked;
            }
            else if ((num2 == 0) && (num3 > 0))
            {
                currNode.CheckState = TriState.Unchecked;
            }
        }

        public void SingleSelectNode(TreeNode node)
        {
            if (!this.m_coll.Contains(node))
            {
                if (this.MulSelected)
                {
                    foreach (TreeNode node2 in this.SelectedNodes)
                    {
                        this.LowlightNode(node2);
                    }
                }
                this.MulSelected = false;
                this.SelectedNodes.Clear();
                this.SelectedNodes.Add(node);
                this.SetCurrentNode(node);
            }
        }

        internal void TreeViewAfterTriStateUpdate(ThreeStateTreeNode node)
        {
            TriStateEventArgs e = new TriStateEventArgs(node, node.CheckState);
            this.OnAfterTriStateChanged(e);
        }

        public TreeNode CurrentNode
        {
            get
            {
                return this.currentNode;
            }
        }

        public bool IsMulSelect
        {
            get
            {
                return this.isMulSelect;
            }
            set
            {
                this.isMulSelect = value;
            }
        }

        public ArrayList SelectedNodes
        {
            get
            {
                return this.m_coll;
            }
        }
    }
}

