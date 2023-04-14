using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_BusinessObjectFront;
using GSM00200Common.DTO;
using GSM00200Common.Interfaces;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;

namespace GSM00200
{
    public class GSM00200Model : R_BusinessObjectServiceClientBase<GSM00200DTO>,IGSM00200
    {
        public GSM00200Model(string pcHttpClientName, string pcRequestServiceEndPoint, bool plSendWithContext = true, bool plSendWithToken = true) : base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        public GSM00200ListDTO<GSM00200DTO> GetTableHDList()
        {
            var loEx = new R_Exception();
            GSM00200ListDTO<GSM00200DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loResult = new();
                    R_HTTPClientWrapper.R_APIRequestObject<GSM00200ListDTO<GSM00200DTO>>(
                        _RequestServiceEndPoint,
                        nameof(GSM00200Model.GetTableHDList),
                        _SendWithContext,
                        _SendWithToken);

            }
            catch (Exception e)
            {
                loEx.Add(e);
            }

            loEx.ThrowExceptionIfErrors();
            return loResult;
        }
    }
}
