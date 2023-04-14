using System;
using System.Collections.Generic;
using System.Text;
using R_CommonFrontBackAPI;
using SAB00400Common.Dtos;

namespace SAB00400Common
{
    public interface ISAB00400 :R_IServiceCRUDBase<SAB00400DTO>
    {
        SAB00400ListDTO<SAB00400DTO> GetAllRegion();

        IAsyncEnumerable<SAB00400DTO> GetAllRegionStream();
    }
}
