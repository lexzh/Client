namespace Client
{
    using System;
    using System.Runtime.CompilerServices;

    public class PathSegmentChangeArgs : EventArgs
    {
        public bool IsClose { get; set; }

        public bool IsSet { get; set; }
    }
}

