using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
    public class FloorInformationBLL
    {
        public FloorInformationDAL FloorInformationDAL { get; set; }

        public FloorInformationBLL()
        {
            FloorInformationDAL = new FloorInformationDAL();
        }


        public int FloorInforrmation_Add(FloorInformationBOL _FloorInformation)
        {
            try
            {
                return FloorInformationDAL.Add(_FloorInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int FloorInforrmation_Update(FloorInformationBOL _FloorInformation)
        {
            try
            {
                return FloorInformationDAL.Update(_FloorInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable FloorInforrmation__GetDataForGV()
        {
            try
            {
                return FloorInformationDAL.GetDataForGV();
            }
            catch
            {
                return null;
            }
        }

        public int FloorInforrmation_Delete(FloorInformationBOL _FloorInformation)
        {
            try
            {
                return FloorInformationDAL.Delete(_FloorInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FloorInformationBOL FloorInforrmation_GetById(FloorInformationBOL _FloorInformation)
        {
            try
            {
                return FloorInformationDAL.GetById(_FloorInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
  
    }
}
