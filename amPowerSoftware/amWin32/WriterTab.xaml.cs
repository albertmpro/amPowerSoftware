using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using Albert.Standard.Win32;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace amWin32
{
    public sealed partial class WriterTab : DocumentControl
    {
        public WriterTab(TabControl _tab)
        {
            this.InitializeComponent();
			// Create a New Tab ITem 
			TabItem = new DocumentTabItem($"WriterDocument{Count++}", true, this, _tab);
			writer.TabItem = TabItem;
			


		}
    }
}
