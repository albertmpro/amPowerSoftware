using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Standard;

namespace amFlowDoczBase
{
    public class WebNote: PropBase
    {
        string websiteUrl, notes;
        
        
        /// <summary>
        /// Get or set Website Url 
        /// </summary>
        public string WebsiteUrl { get => websiteUrl; set { websiteUrl = value; OnPropertyChanged("WebsiteUrl"); } }
        /// <summary>
        /// Get or set Notes taken 
        /// </summary>
        public string Notes { get => notes; set { notes = value; OnPropertyChanged("Notes"); } }
    }
}
