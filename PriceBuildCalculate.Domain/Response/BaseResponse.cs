using PriceBuildCalculate.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBuildCalculate.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public object Data { get; set; }
    }
    public interface IBaseResponse<T>
    {
        StatusCode StatusCode { get; }
        
    }


}
