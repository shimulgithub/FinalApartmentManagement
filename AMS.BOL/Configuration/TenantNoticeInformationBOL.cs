using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class TenantNoticeInformationBOL
    {
        public int AutoID { get; set; }
        public DateTime Date { get; set; }
        public string DateBind { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte  NoticeFile { get; set; }
        public string CreateBy { get; set; }
        public string ChangedBy { get; set; }

    }
}
