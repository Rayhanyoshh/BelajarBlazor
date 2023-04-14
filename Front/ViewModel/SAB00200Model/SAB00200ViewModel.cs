using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB00200Model
{
    public class SAB00200ViewModel : R_ViewModel<SAB00100DTO>
    {
        private SAB00200Model _model = new SAB00200Model();

        public ObservableCollection<SAB00100DTO> EmployeeList = new ObservableCollection<SAB00100DTO>();
        public SAB00100DTO Employee = new SAB00100DTO();

        public async Task GetAllEmployeeAsync()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetAllEmployeeOriginalAsync();

                EmployeeList = new ObservableCollection<SAB00100DTO>(loResult.Data);
            }
            catch (System.Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        public async Task GetEmployeeAsync(int pnEmployeeId)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var loParam = new SAB00100DTO() { EmployeeID = pnEmployeeId };
                var loResult = await _model.R_ServiceGetRecordAsync(loParam);
                Employee = loResult;
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public void SaveValidation(SAB00100DTO poEntity)
        {
            //var loEx = new R_Exception();
            //try
            //{
            //    if (string.IsNullOrWhiteSpace(poEntity.FirstName))
            //    {
            //        var loErr = R_FrontUtility.R_GetError(typeof(Resources_Dummy_Class), "PS001");
            //        loEx.Add(loErr);
            //    }
            //    if (string.IsNullOrWhiteSpace(poEntity.Address))
            //    {
            //        var loErr = R_FrontUtility.R_GetError(typeof(Resources_Dummy_Class), "PS003");
            //        loEx.Add(loErr);
            //    }
            //}
            //catch (Exception e)
            //{
            //    loEx.Add(e);
            //}
            //loEx.ThrowExceptionIfErrors();

        }

        public async Task R_SaveEmployeeAsync(SAB00100DTO poEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();
            try
            {
                var loResult = await _model.R_ServiceSaveAsync(poEntity, peCRUDMode);
                Employee = loResult;
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();

        }

        public async Task DeleteEmployeeAsync(int poEntity)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = new SAB00100DTO() { EmployeeID = poEntity };
                await _model.R_ServiceDeleteAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
    }
}
