using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00600Common.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB00600Model
{
    public class SAB00600ViewModel : R_ViewModel<SAB00600DTO>
    {
        private SAB00600Model _model = new SAB00600Model();

        public ObservableCollection<SAB00600DTO> CustomerList { get; set; } = new ObservableCollection<SAB00600DTO>();

        public SAB00600DTO Customer = new SAB00600DTO();

        public async Task GetCustomerList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetAllCustomerAsync();
                CustomerList = new ObservableCollection<SAB00600DTO>(loResult.Data);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetCustomerById(string customerId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00600DTO { CustomerID = customerId };
                var loResult = await _model.R_ServiceGetRecordAsync(loParam);

                Customer = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task SaveCustomer(SAB00600DTO poNewEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.R_ServiceSaveAsync(poNewEntity, peCRUDMode);

                Customer = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task DeleteCustomer(string customerId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00600DTO { CustomerID = customerId };
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
