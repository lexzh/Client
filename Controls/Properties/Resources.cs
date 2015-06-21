namespace WinFormsUI.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), CompilerGenerated]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        internal static Bitmap Checked0
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Checked0", resourceCulture);
            }
        }

        internal static Bitmap Checked1
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Checked1", resourceCulture);
            }
        }

        internal static Bitmap Checked2
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Checked2", resourceCulture);
            }
        }

        internal static Bitmap Checked3
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Checked3", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("WinFormsUI.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }
    }
}

