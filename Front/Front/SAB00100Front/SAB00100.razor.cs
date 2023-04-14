using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Controls.MessageBox;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;
using SAB00100Model;

namespace SAB00100Front
{
    public partial class SAB00100
    {
        private  SAB00100ViewModel _viewModel = new SAB00100ViewModel();
        private R_Conductor conductorRef;

        private R_Grid<SAB00100DTO> _gridRef;

        protected override async Task R_Init_From_Master(Object poParameter)
        {
            var loEx = new R_Exception();
            try
            {
                await _gridRef.R_RefreshGrid(null);
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task R_ServiceGetListRecordAsync(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                await _viewModel.GetEmployeeListAsync();
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();
        }
        #region find
        public void R_Before_Open_Find(R_BeforeOpenFindEventArgs eventArgs)
        {
            eventArgs.TargetPageType = typeof(SAB00110);
        }

        public async Task R_After_Open_Findasync(R_AfterOpenFindEventArgs eventArgs)
        {
            var loData = eventArgs.Result;
            await conductorRef.R_GetEntity(loData);
        }
        #endregion


        #region Conductor
        public async Task R_ServiceGetRecordAsync(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loData = R_FrontUtility.ConvertObjectToObject<SAB00100DTO>(eventArgs.Data);
                await _viewModel.GetEmployeeById(loData.EmployeeID);
                eventArgs.Result = _viewModel.Employee;
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();
        }
  

        public void R_Validation(R_ValidationEventArgs eventArgs)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                _viewModel.SaveValidation((SAB00100DTO)eventArgs.Data);
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }

            eventArgs.Cancel = loEx.HasError;
            loEx.ThrowExceptionIfErrors();
        }

        public async Task R_ServiceSaveAsync(R_ServiceSaveEventArgs eventArgs)
        {
            R_Exception loEx = new R_Exception();
            try
            {
               await _viewModel.SaveEmployeeAsync((SAB00100DTO)eventArgs.Data, (eCRUDMode)eventArgs.ConductorMode);
               eventArgs.Result = _viewModel.Employee;
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();
        }

        private async Task R_AfterSaveAsync()
        {
            await R_MessageBox.Show(
                "",
                "Save Success",
                R_eMessageBoxButtonType.OK);
        }

        private void R_AfterAdd(R_AfterAddEventArgs eventArgs)
        {
            var loDefault = new SAB00100DTO
            {
                Address = "Sentul",
                City = "Bogor",
                Country = "Indonesia"
            };
            eventArgs.Data = loDefault;
        }

        private async Task R_ServiceDeleteAsync(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                await _viewModel.DeleteEmployee((SAB00100DTO)eventArgs.Data);
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_R_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await _viewModel.GetEmployeeListAsync();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        private void R_ConvertToGridEntity(R_ConvertToGridEntityEventArgs eventArgs)
        {
            eventArgs.GridData = R_FrontUtility.ConvertObjectToObject<SAB00100DTO>(eventArgs.Data);
        }
        #endregion
    }
}
