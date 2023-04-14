using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorClientHelper;
using Microsoft.AspNetCore.Components;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Base;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using R_ContextFrontEnd;
using SAB00400Common;
using SAB00400Common.Dtos;
using SAB00400Model.ViewModels;

namespace SAB00400Front
{
    public partial class SAB00400 : R_Page
    {
        private SAB00400ViewModel RegionViewModel = new SAB00400ViewModel();
        private R_Grid<SAB00400DTO> _gridRegiondRef;
        private R_ConductorGrid _conGridRegionRef;

        private SAB00410ViewModel TerritoryViewModel = new SAB00410ViewModel();
        private R_Conductor _conductorTerritoryRef;
        private R_Grid<SAB00410DTO> _gridTerritoryRef;

        [Inject] private  IClientHelper _clientHelper { get; set; }
        [Inject] private R_ContextHeader _contextHeader { get; set; }

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await _gridRegiondRef.R_RefreshGrid(null);
                //var lcCompanyId = _clientHelper.CompanyId;
                //var lcUserId = _clientHelper.UserId;
                //var lcLang = _clientHelper.CultureUI.TwoLetterISOLanguageName;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        private async Task GridRegion_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await RegionViewModel.GetRegionList();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        #region Conductor Region
        private async Task Grid_Display(R_DisplayEventArgs eventArgs)
        {
            if (eventArgs.ConductorMode == R_eConductorMode.Normal)
            {
                var loParam = (SAB00400DTO)eventArgs.Data;
                
                await _gridTerritoryRef.R_RefreshGrid(loParam);
            }
        }

        private async Task Grid_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB00400DTO)eventArgs.Data;
                await RegionViewModel.GetRegion(loParam.RegionID);

                eventArgs.Result = RegionViewModel.Region;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await RegionViewModel.SaveRegion((SAB00400DTO)eventArgs.Data, (eCRUDMode)eventArgs.ConductorMode);
                eventArgs.Result = RegionViewModel.Region;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loData = (SAB00400DTO)eventArgs.Data;
                await RegionViewModel.DeleteRegion(loData.RegionID);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        #endregion


        #region Conductor Territory
        private async Task GridTerritory_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var liParam = ((SAB00400DTO)eventArgs.Parameter).RegionID;
                _contextHeader.R_Context.R_SetStreamingContext(ContextConstant.REGION_ID, liParam);
                await TerritoryViewModel.GetTerritoriesByRegion(liParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        private async Task ConductorTerritory_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB00410DTO)eventArgs.Data;
                await TerritoryViewModel.GetTerritoriesById(loParam.TerritoryID);

                eventArgs.Result = TerritoryViewModel.Territories;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_ServiceSaveTerritory(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await TerritoryViewModel.SaveTerritories((SAB00410DTO)eventArgs.Data, (eCRUDMode)eventArgs.ConductorMode);
                eventArgs.Result = RegionViewModel.Region;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_ServiceDeleteTerritory(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loData = (SAB00410DTO)eventArgs.Data;
                await TerritoryViewModel.DeleteTerritories(loData.TerritoryID);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        #endregion
    }
}
