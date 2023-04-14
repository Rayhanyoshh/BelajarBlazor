using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00400Common.Dtos;

namespace SAB00400Model.ViewModels
{
    public class SAB00400ViewModel : R_ViewModel<SAB00400DTO>
    {
        private SAB00400Model _SAB00400Model = new SAB00400Model();
        public ObservableCollection<SAB00400DTO> RegionList { get; set; } = new ObservableCollection<SAB00400DTO>();

        public SAB00400DTO Region = new SAB00400DTO();

        public async Task GetRegionList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB00400Model.GetAllRegionStreamAsync();
                RegionList = new ObservableCollection<SAB00400DTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetRegion(int piRegionId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00400DTO { RegionID = piRegionId };
                var loResult = await _SAB00400Model.R_ServiceGetRecordAsync(loParam);

                Region = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task SaveRegion(SAB00400DTO poNewEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB00400Model.R_ServiceSaveAsync(poNewEntity, peCRUDMode);

                Region = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task DeleteRegion(int regionID)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00400DTO { RegionID = regionID };
                await _SAB00400Model.R_ServiceDeleteAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
