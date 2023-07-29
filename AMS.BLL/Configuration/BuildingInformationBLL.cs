using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
    public class BuildingInformationBLL
    {
        public BuildingInformationDAL BuildingInformationDAL { get; set; }

        public BuildingInformationBLL()
        {
            BuildingInformationDAL = new BuildingInformationDAL();
        }

     
        public int BuildingInforrmation_Add(BuildingInformationBOL  _BuildingInformation)
        {
            try
            {
                return BuildingInformationDAL.Add(_BuildingInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int BuildingInforrmation_Update(BuildingInformationBOL _BuildingInformation)
        {
            try
            {
                return BuildingInformationDAL.Update(_BuildingInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BuildingInforrmation__GetDataForGV()
        {
            try
            {
                return BuildingInformationDAL.GetDataForGV();
            }
            catch
            {
                return null;
            }
        }

        public int BuildingInforrmation_Delete(BuildingInformationBOL _BuildingInformation)
        {
            try
            {
                return BuildingInformationDAL.Delete(_BuildingInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BuildingInforrmation_GetById(BuildingInformationBOL _BuildingInformation)
        {
            try
            {
                return BuildingInformationDAL.GetById(_BuildingInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
  
    }
}
