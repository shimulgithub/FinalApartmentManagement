using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class BuildingInformationBOL
    {


        public int AutoID { get; set; }
        public string BuildingName { get; set; }
        public string OwnerName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string SecGaurdNo { get; set; }
        public string SecretaryNo { get; set; }
        public string Address { get; set; }
        public string RajukReference { get; set; }
        public string Year { get; set; }
       
        public byte   BuildingImage { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhoneNo { get; set; }
        public string CompanyAddress { get; set; }
        //public byte BuildingRules { get; set; }
       
        public string CreateBy { get; set; }
        

    }
}
