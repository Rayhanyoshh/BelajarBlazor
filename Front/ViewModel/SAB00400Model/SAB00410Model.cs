using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using SAB00400Common;
using SAB00400Common.Dtos;

namespace SAB00400Model
{
    public class SAB00410Model : R_BusinessObjectServiceClientBase<SAB00410DTO>, ISAB00410
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB00410";

        public SAB00410Model(string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = false)
            : base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }


        public SAB00410ListDTO GetAllTerritories()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00400ListDTO<SAB00410DTO>> GetAllTerritoriesAsync()
        {
            var loEx = new R_Exception();
            SAB00400ListDTO<SAB00410DTO> loRtn = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<SAB00400ListDTO<SAB00410DTO>>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00410.GetAllTerritories),
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


        #region GetAllTerritoriesByRegion

        public SAB00400ListDTO<SAB00410DTO> GetAllTerritoriesByRegion(int piRegionId)
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00400ListDTO<SAB00410DTO>> GetAllTerritoriesByRegionAsync(int piRegionId)
        {
            var loEx = new R_Exception();
            SAB00400ListDTO<SAB00410DTO> loRtn = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<SAB00400ListDTO<SAB00410DTO>, int>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00410.GetAllTerritoriesByRegion),
                    piRegionId,
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

        #endregion

        #region MyRegion

        public IAsyncEnumerable<SAB00410DTO> GetAllTerritoriesStream()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SAB00410DTO>> GetAllTerritoriesStreamAsync()
        {
            var loEx = new R_Exception();
            List<SAB00410DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loResult = await R_HTTPClientWrapper.R_APIRequestStreamingObject<SAB00410DTO>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00410.GetAllTerritoriesStream),
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

        #region GetAllTerritoriesByRegionStream

        public IAsyncEnumerable<SAB00410DTO> GetAllTerritoriesByRegionStream()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SAB00410DTO>> GetAllTerritoriesByRegionStreamAsync()
        {
            var loEx = new R_Exception();
            List<SAB00410DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loResult = await R_HTTPClientWrapper.R_APIRequestStreamingObject<SAB00410DTO>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00410.GetAllTerritoriesByRegionStream),
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
