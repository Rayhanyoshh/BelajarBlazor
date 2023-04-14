using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using R_CommonFrontBackAPI;
using SAB00400Common.Dtos;

namespace SAB00400Common
{
    public interface ISAB00410 : R_IServiceCRUDBase<SAB00410DTO>
    {
        SAB00410ListDTO GetAllTerritories();
        SAB00400ListDTO<SAB00410DTO> GetAllTerritoriesByRegion(int piRegionId);

        IAsyncEnumerable<SAB00410DTO> GetAllTerritoriesStream();

        IAsyncEnumerable<SAB00410DTO> GetAllTerritoriesByRegionStream();
    }
}
