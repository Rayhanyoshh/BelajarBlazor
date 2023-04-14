using System.Collections.Generic;
using System.Threading.Tasks;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;

namespace SAB00100Common
{
    public interface ISAB00100 : R_IServiceCRUDBase<SAB00100DTO>
    {
        SAB00100ListEmployeeDTO GetAllEmployee();
        SAB00100ListEmployeeOriginalDTO GetAllEmployeeOriginal();
        IAsyncEnumerable<SAB00100DTO> GetEmployeeListStream();
    }
}
