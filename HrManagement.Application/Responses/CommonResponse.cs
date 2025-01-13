using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagement.Application.Responses
{
    public class CommonResponse
    {
        public bool Success { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
