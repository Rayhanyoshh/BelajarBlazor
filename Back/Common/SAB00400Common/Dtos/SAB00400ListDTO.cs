using System;
using System.Collections.Generic;
using System.Text;
using R_APICommonDTO;

namespace SAB00400Common.Dtos
{
    public class SAB00400ListDTO<T> : R_APIResultBaseDTO
    {
        public List<T> Data { get; set; }
    }
}
