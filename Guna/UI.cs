using System.ComponentModel;
using System.Windows.Forms;

namespace Guna
{
    internal class UI
    {
        internal class WinForms
        {
            internal class GunaElipse
            {
                private IContainer components;

                public GunaElipse(IContainer components)
                {
                    this.components = components;
                }

                public int Radius { get; internal set; }
                public Panel TargetControl { get; internal set; }

                internal class UI
                {
                    internal class WinForms
                    {
                        internal class GunaElipse : Guna.UI.WinForms.GunaElipse
                        {
                            private IContainer components;

                            public GunaElipse(IContainer components)
                            {
                                this.components = components;
                            }
                        }
                    }
                }
            }
        }
    }
}