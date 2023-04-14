using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB01300Common.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB01300Model.ViewModels
{
    public class SAB01310ViewModel : R_ViewModel<SAB01310DTO>
    {
        private SAB01310Model _SAB01310Model = new SAB01310Model();

        public ObservableCollection<SAB01310DTO> ProductList { get; set; } = new ObservableCollection<SAB01310DTO>();

        public SAB01310DTO Product = new SAB01310DTO();

        public async Task GetProductByCategory(int piCategoryId)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB01310Model.GetAllProductByCategoryAsync(piCategoryId);
                ProductList = new ObservableCollection<SAB01310DTO>(loResult.Data);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetProductById(int piProductId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB01310DTO { ProductID = piProductId };
                var loResult = await _SAB01310Model.R_ServiceGetRecordAsync(loParam);

                Product = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task SaveProduct(SAB01310DTO poNewEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB01310Model.R_ServiceSaveAsync(poNewEntity, peCRUDMode);

                Product = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task DeleteProduct(int productId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB01310DTO { ProductID = productId };
                await _SAB01310Model.R_ServiceDeleteAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
