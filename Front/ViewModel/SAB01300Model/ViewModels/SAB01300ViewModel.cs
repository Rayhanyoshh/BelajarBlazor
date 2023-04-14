using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB01300Common.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB01300Model.ViewModels
{
    public class SAB01300ViewModel : R_ViewModel<SAB01300DTO>
    {
        private SAB01300Model _SAB01300Model = new SAB01300Model();

        public ObservableCollection<SAB01300DTO> CategoryList { get; set; } = new ObservableCollection<SAB01300DTO>();

        public SAB01300DTO Category = new SAB01300DTO();

        public async Task GetCategoryList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB01300Model.GetAllCategoryStreamListAsync();
                CategoryList = new ObservableCollection<SAB01300DTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetCategory(int piCategoryId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB01300DTO { CategoryID = piCategoryId };
                var loResult = await _SAB01300Model.R_ServiceGetRecordAsync(loParam);

                Category = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task SaveCategory(SAB01300DTO poNewEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB01300Model.R_ServiceSaveAsync(poNewEntity, peCRUDMode);

                Category = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task DeleteCategory(int categoryId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB01300DTO { CategoryID = categoryId };
                await _SAB01300Model.R_ServiceDeleteAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
