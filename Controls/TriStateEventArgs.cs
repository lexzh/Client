namespace WinFormsUI.Controls
{
    using System;

    public class TriStateEventArgs : EventArgs
    {
        private ThreeStateTreeNode node;
        private TriState threeCheckedState;

        public TriStateEventArgs(ThreeStateTreeNode currNode, TriState currThreeCheckedState)
        {
            this.node = currNode;
            this.threeCheckedState = currThreeCheckedState;
        }

        public ThreeStateTreeNode Node
        {
            get
            {
                return this.node;
            }
        }

        public TriState ThreeCheckedState
        {
            get
            {
                return this.threeCheckedState;
            }
        }
    }
}

