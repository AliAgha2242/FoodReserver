using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.BaseDto
{
    public class ResponseBase
    {
        public bool IsOkey { get; set; } = true;
        public string? Message { get; set; } = "Every Thing Is Okey ." ;
        public Int16 StatusCode { get; set; } =  200 ;
    }
}
