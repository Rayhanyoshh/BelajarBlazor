using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using R_ContextFrontEnd;
using SAB00400Common.Dtos;

namespace SAB00400Model.ViewModels
{
    public class SAB00410ViewModel : R_ViewModel<SAB00410DTO>
    {
        private SAB00410Model _SAB00410Model = new SAB00410Model();
        public ObservableCollection<SAB00410DTO> TerritoriesList { get; set; } = new ObservableCollection<SAB00410DTO>();
        
        public SAB00410DTO Territories = new SAB00410DTO();

        private R_ContextHeader _contextHeader;
        public int _regionID;

        public async Task GetTerritoriesByRegion(int piRegionId)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB00410Model.GetAllTerritoriesByRegionAsync(piRegionId);
                TerritoriesList = new ObservableCollection<SAB00410DTO>(loResult.Data);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetTerritoriesById(string piTerritoriesId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00410DTO { TerritoryID = piTerritoriesId };
                var loResult = await _SAB00410Model.R_ServiceGetRecordAsync(loParam);

                Territories = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task SaveTerritories(SAB00410DTO poNewEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB00410Model.R_ServiceSaveAsync(poNewEntity, peCRUDMode);

                Territories = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task DeleteTerritories(string territoryId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00410DTO { TerritoryID = territoryId };
                await _SAB00410Model.R_ServiceDeleteAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
