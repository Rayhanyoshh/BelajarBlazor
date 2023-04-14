using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using SAB00100Common;
using SAB00100Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAB00200Model
{
    public class SAB00200Model : R_BusinessObjectServiceClientBase<SAB00100DTO>, ISAB00100
    {
        private const string DEFAULT_HTTP = "R_DefaultServiceUrl";
        private const string DEFAULT_ENDPOINT = "api/SAB00100";

        public SAB00200Model(
            string pcHttpClientName = DEFAULT_HTTP,
            string pcRequestServiceEndPoint = DEFAULT_ENDPOINT,
            bool plSendWithContext = true,
            bool plSendWithToken = false) :
            base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        public SAB00100ListEmployeeDTO GetAllEmployee()
        {
            throw new System.NotImplementedException();
        }

        public SAB00100ListEmployeeOriginalDTO GetAllEmployeeOriginal()
        {
            throw new System.NotImplementedException();
        }

        public IAsyncEnumerable<SAB00100DTO> GetEmployeeListStream()
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
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
    }
}
