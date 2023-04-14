using BlazorClientHelper;
using Microsoft.AspNetCore.Components;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Base;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Controls.MessageBox;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;
using SAB00200Model;

namespace SAB00200Front
{
    public partial class SAB00200 : R_Page
    {
        private SAB00200ViewModel _ViewModel = new();

        private R_ConductorGrid _empConductor;

        private R_Grid<SAB00100DTO> _gridRef;

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await _gridRef.R_RefreshGrid(null);

            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        private async Task Grid_R_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await _ViewModel.GetAllEmployeeAsync();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB00100DTO)eventArgs.Data;
                await _ViewModel.GetEmployeeAsync(loParam.EmployeeID);

                eventArgs.Result = _ViewModel.EmployeeList;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private void Grid_BeforeEdit(R_BeforeEditEventArgs eventArgs)
        {
        }

        private void Grid_BeforeCancel(R_BeforeCancelEventArgs eventArgs)
        {
        }

        private void Grid_BeforeAdd(R_BeforeAddEventArgs eventArgs)
        {

        }

        private void Grid_AfterAdd(R_AfterAddEventArgs eventArgs)
        {
        }

        private void Grid_Validation(R_ValidationEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loData = (SAB00100DTO)eventArgs.Data;

                if (string.IsNullOrWhiteSpace(loData.FirstName))
                    loEx.Add("001", "FirstName cannot be null.");
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            eventArgs.Cancel = loEx.HasError;

            loEx.ThrowExceptionIfErrors();
        }

        private void Grid_Saving(R_SavingEventArgs eventArgs)
        {
            if (eventArgs.ConductorMode == R_eConductorMode.Add)
            {
                var loData = (SAB00100DTO)eventArgs.Data;
                loData.Address = "Depok";
            }
        }

        private async Task Grid_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await _ViewModel.R_SaveEmployeeAsync(
                    (SAB00100DTO)eventArgs.Data,
                    (eCRUDMode)eventArgs.ConductorMode);

                eventArgs.Result = _ViewModel.EmployeeList;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_AfterSave(R_AfterSaveEventArgs eventArgs)
        {
            await R_MessageBox.Show("Success", "Success", R_eMessageBoxButtonType.OK);
        }

        private void Grid_BeforeDelete(R_BeforeDeleteEventArgs eventArgs)
        {
            //TODO VALIDATION
            //eventArgs.Cancel = true;
        }

        private async Task Grid_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loData = (SAB00100DTO)eventArgs.Data;
                await _ViewModel.DeleteEmployeeAsync(loData.EmployeeID);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_AfterDelete()
        {
            await R_MessageBox.Show("Success", "Success Delete", R_eMessageBoxButtonType.OK);
        }

        #region CHECK
        private void R_Display(R_DisplayEventArgs eventArgs)
        {

        }
        private void R_CheckAdd(R_CheckAddEventArgs eventArgs)
        {
            //TODO VALIDATION
            //eventArgs.Allow = false;
        }
        private void R_CheckEdit(R_CheckEditEventArgs eventArgs)
        {

        }
        private void R_CheckDelete(R_CheckDeleteEventArgs eventArgs)
        {

        }
        #endregion


        #region CHECK GRID
        private void R_CheckGridAdd(R_CheckGridEventArgs eventArgs)
        {
            //TODO VALIDATION
            //eventArgs.Allow = false;
        }
        private void R_CheckGridEdit(R_CheckGridEventArgs EventArgs)
        {

        }
        private void R_CheckGridDelete(R_CheckGridEventArgs eventArgs)
        {

        }
        #endregion

    }
}
