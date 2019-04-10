using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using Albert.Standard.Win32;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace amWin32
{
    public sealed partial class CodeTab : DocumentControl
    {
        public CodeTab(TabControl _tab)
        {
            this.InitializeComponent();
			//Link TabItem to the TabCOntrol 
			TabItem = new DocumentTabItem($"CodeDocument{Count++}", true, this, _tab);
			//Link to the TabITem to the code eidtor 
			code.TabItem = TabItem;
        }
    }
}
