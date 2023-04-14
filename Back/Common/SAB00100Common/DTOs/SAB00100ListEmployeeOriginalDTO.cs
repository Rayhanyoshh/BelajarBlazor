using R_APICommonDTO;
using System.Collections.Generic;

namespace SAB00100Common.DTOs
{
    public class SAB00100ListEmployeeOriginalDTO : R_APIResultBaseDTO
    {
        public List<SAB00100DTO> Data { get; set; }
    }
}
