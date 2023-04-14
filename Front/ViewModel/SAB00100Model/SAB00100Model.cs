using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using R_CommonFrontBackAPI;
using SAB00100Common;
using SAB00100Common.DTOs;

namespace SAB00100Model
{
    public class SAB00100Model : R_BusinessObjectServiceClientBase<SAB00100DTO>, ISAB00100
    {
        private const string DEFAULT_HTTP = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB00100";

        public SAB00100Model(
            string pcHttpClientName = DEFAULT_HTTP,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = true) :
            base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        public SAB00100ListEmployeeDTO GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00100ListEmployeeDTO> GetAllEmployeeAsnyc()
        {
            R_Exception loEx = new R_Exception();
            SAB00100ListEmployeeDTO loRtn = null;
            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<SAB00100ListEmployeeDTO>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00100.GetAllEmployee),
                    _SendWithContext,
                    _SendWithToken);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
            return loRtn;
        }


        public SAB00100ListEmployeeOriginalDTO GetAllEmployeeOriginal()
        {
            throw new NotImplementedException();
        }
        public async Task<SAB00100ListEmployeeOriginalDTO> GetAllEmployeeOriginalAsync()
        {
            var loEx = new R_Exception();
            SAB00100ListEmployeeOriginalDTO loRtn = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<SAB00100ListEmployeeOriginalDTO>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00100.GetAllEmployeeOriginal),
                    _SendWithContext,
                    _SendWithToken);

            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();
            return loRtn;
        }


        public IAsyncEnumerable<SAB00100DTO> GetEmployeeListStream()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00100ListEmployeeOriginalDTO> GetEmployeeOriginalListStream()
        {
            var loEx = new R_Exception();
            SAB00100ListEmployeeOriginalDTO loRtn = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<SAB00100ListEmployeeOriginalDTO>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00100.GetAllEmployee),
                    _SendWithContext,
                    _SendWithToken);

            }
            catch (Exception e)
            {
                loEx.Add(e);
            }
            loEx.ThrowExceptionIfErrors();
            return loRtn;
        }
    }
}
