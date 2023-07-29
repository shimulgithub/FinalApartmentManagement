using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public   class MenuHead
    {


        public int MainModuleMenuHeadID { get; set; }
        public string MainModuleMenuHeadName { get; set; }
        public int MainModuleMenuHeadPriority { get; set; }
        public string MainModuleMenuHeadIcone { get; set; }
        public int? MainModuleMenuHeadIsActive { get; set; }

        public bool? CanView { get; set; }

        public int PageId { get; set; }
        public string PageName { get; set; }
        public bool? IsActive { get; set; }
        public int Priority { get; set; }
        public bool? CanViewIsActive { get; set; }
    }
}
