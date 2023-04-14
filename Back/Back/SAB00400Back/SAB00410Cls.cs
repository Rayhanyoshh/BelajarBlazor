using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackHelper;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00400Common.Dtos;

namespace SAB00400Back
{
    public class SAB00410Cls : R_BusinessObject<SAB00410DTO>
    {
        protected override SAB00410DTO R_Display(SAB00410DTO poEntity)
        {
            var loEx = new R_Exception();
            SAB00410DTO loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Territories (NOLOCK) WHERE TerritoryID = @TerritoryID";

                var loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loCmd.AddParameter("@TerritoryID", poEntity.TerritoryID);

                var loDataTable = loDb.SqlExecQuery(loConn, loCmd, true);

                loResult = R_Utility.R_ConvertTo<SAB00410DTO>(loDataTable).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        protected override void R_Saving(SAB00410DTO poNewEntity, eCRUDMode poCRUDMode)
        {
            var loEx = new R_Exception();
            try
            {
                string lcQuery = "";
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var loCmd = loDb.GetCommand();
                if (poCRUDMode == eCRUDMode.AddMode)
                {
                    lcQuery = "INSERT INTO Territories (TerritoryID, TerritoryDescription,RegionID)";
                    lcQuery += "VALUES (@TerritoryID, @TerritoryDescription, @RegionID) ";


                    loCmd.CommandText = lcQuery;
                    loCmd.AddParameter("@TerritoryID", poNewEntity.TerritoryID);
                    loCmd.AddParameter("@TerritoryDescription", poNewEntity.TerritoryDescription);
                    loCmd.AddParameter("@RegionID", poNewEntity.RegionID);

                    var loResult = loDb.SqlExecQuery(loConn, loCmd, true);
                    //poNewEntity.TerritoryID = Convert.ToInt32(loResult.Rows[0].ItemArray[0]);

                    return;
                }

                lcQuery =  "UPDATE Territories SET TerritoryDescription = @TerritoryDescription ";
                lcQuery += "WHERE TerritoryID = @TerritoryID";


                loCmd.CommandText = lcQuery;
                loCmd.AddParameter("TerritoryID", poNewEntity.TerritoryID);
                loCmd.AddParameter("TerritoryDescription", poNewEntity.TerritoryDescription);
                loCmd.AddParameter("RegionID", poNewEntity.RegionID);
                loDb.SqlExecNonQuery(loConn, loCmd, true);

            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();

        }

        protected override void R_Deleting(SAB00410DTO poEntity)
        {
            var loEx = new R_Exception();

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "DELETE FROM Territories WHERE TerritoryID = @TerritoryID";

                var loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loCmd.AddParameter("@TerritoryID", poEntity.TerritoryID);

                loDb.SqlExecNonQuery(loConn, loCmd, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public List<SAB00410DTO> GetAllTerritories()
        {
            var loEx = new R_Exception();
            List<SAB00410DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Territories (NOLOCK) ORDER BY TerritoryID";
                loResult = loDb.SqlExecObjectQuery<SAB00410DTO>(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public List<SAB00410DTO> GetAllTerritoriesByRegion(int piRegionId)
        {
            var loEx = new R_Exception();
            var loResult = new List<SAB00410DTO>();

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Territories (NOLOCK) ";
                lcQuery += $"WHERE RegionID = {piRegionId}";
                loResult = loDb.SqlExecObjectQuery<SAB00410DTO>(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }
    }
}
