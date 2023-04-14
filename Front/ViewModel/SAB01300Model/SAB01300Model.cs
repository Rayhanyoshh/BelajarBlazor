using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using SAB01300Common;
using SAB01300Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAB01300Model
{
    public class SAB01300Model : R_BusinessObjectServiceClientBase<SAB01300DTO>, ISAB01300
    {
        private const string DEFAULT_HTTP = "R_DefaultServiceUrl";
        private const string DEFAULT_ENDPOINT = "api/SAB01300";

        public SAB01300Model(
            string pcHttpClientName = DEFAULT_HTTP,
            string pcRequestServiceEndPoint = DEFAULT_ENDPOINT,
            bool plSendWithContext = true,
            bool plSendWithToken = false) :
            base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        #region GetAllCategory
        public SAB01300ListDTO<SAB01300DTO> GetAllCategory()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SAB01300ListDTO<SAB01300DTO>> GetAllCategoryAsync()
        {
            var loEx = new R_Exception();
            SAB01300ListDTO<SAB01300DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB01300ListDTO<SAB01300DTO>>(
                    _RequestServiceEndPoint,
                    nameof(ISAB01300.GetAllCategory),
                    _SendWithContext,
                    _SendWithToken);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }
        #endregion

        #region GetAllCategoryStream
        public IAsyncEnumerable<SAB01300DTO> GetAllCategoryStream()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<SAB01300DTO>> GetAllCategoryStreamListAsync()
        {
            var loEx = new R_Exception();
            List<SAB01300DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loResult = await R_HTTPClientWrapper.R_APIRequestStreamingObject<SAB01300DTO>(
                    _RequestServiceEndPoint,
                    nameof(ISAB01300.GetAllCategoryStream),
                    _SendWithContext,
                    _SendWithToken,
                    null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        #endregion
    }
}
