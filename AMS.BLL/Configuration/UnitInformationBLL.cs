using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
    public class UnitInformationBLL
    {
        public UnitInformationDAL UnitInformationDAL { get; set; }

        public UnitInformationBLL()
        {
            UnitInformationDAL = new UnitInformationDAL();
        }


        public int UnitInforrmation_Add(UnitInformationBOL _UnitInformation)
        {
            try
            {
                return UnitInformationDAL.Add(_UnitInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UnitInforrmation_Update(UnitInformationBOL _UnitInformation)
        {
            try
            {
                return UnitInformationDAL.Update(_UnitInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable UnitInforrmation__GetDataForGV()
        {
            try
            {
                return UnitInformationDAL.GetDataForGV();
            }
            catch
            {
                return null;
            }
        }

        public int UnitInforrmation_Delete(UnitInformationBOL _UnitInformation)
        {
            try
            {
                return UnitInformationDAL.Delete(_UnitInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UnitInformationBOL UnitInforrmation_GetById(UnitInformationBOL _UnitInformation)
        {
            try
            {
                return UnitInformationDAL.GetById(_UnitInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
  
    }
}
