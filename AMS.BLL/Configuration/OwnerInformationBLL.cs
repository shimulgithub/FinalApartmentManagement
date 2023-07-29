using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
    public class OwnerInformationBLL
    {
        public OwnerInformationDAL OwnerInformationDAL { get; set; }

        public OwnerInformationBLL()
        {
            OwnerInformationDAL = new OwnerInformationDAL();
        }


        public int OwnerInforrmation_Add(OwnerInformationBOL _OwnerInformation)
        {
            try
            {
                return OwnerInformationDAL.Add(_OwnerInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int OwnerUnitInforrmation_Add(OwnerInformationBOL _OwnerInformation)
        {
            try
            {
                return OwnerInformationDAL.OwnerUnitAdd(_OwnerInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int OwnerUnitInforrmation_Update(OwnerInformationBOL _OwnerInformation)
        {
            try
            {
                return OwnerInformationDAL.Update(_OwnerInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable OwnerInforrmation__GetDataForGV()
        {
            try
            {
                return OwnerInformationDAL.GetDataForGV();
            }
            catch
            {
                return null;
            }
        }

        public int OwnerInforrmation_Delete(OwnerInformationBOL _OwnerInformation)
        {
            try
            {
                return OwnerInformationDAL.Delete(_OwnerInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OwnerInformationBOL OwnerInformation_GetById(OwnerInformationBOL _OwnerInformation)
        {
            try
            {
                return OwnerInformationDAL.GetById(_OwnerInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
  
    }
}
