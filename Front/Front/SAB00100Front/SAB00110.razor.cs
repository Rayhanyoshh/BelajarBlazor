using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Controls.MessageBox;
using R_BlazorFrontEnd.Exceptions;
using SAB00100Common.DTOs;
using SAB00100Model;

namespace SAB00100Front
{
    public partial class SAB00110
    {
        private SAB00110ViewModel _viewModel = new SAB00110ViewModel();
        private R_Grid<SAB00100GridDTO> GridRef;
        protected override async Task R_Init_From_Master(Object poParameter)
        {
            var loEx = new R_Exception();
            try
            {
                await GridRef.R_RefreshGrid(null);
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task R_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                await _viewModel.GetAllEmployeeAsync();
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task Button_OnClickAsync()
        {
            var loData = GridRef.GetCurrentData();
            await this.Close(true, loData);
        }

        
    }
}
