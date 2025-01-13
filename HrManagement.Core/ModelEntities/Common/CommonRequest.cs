using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagement.Core.ModelEntities.Common
{
    public class CommonRequest
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedTs { get; set; }=DateTime.UtcNow;
        public string UpdatedBy { get; set; }
        public DateTime UpdatedTs { get; set; } = DateTime.UtcNow;
        public string DeletedBy { get; set; }
        public DateTime DeletedTs { get; set; } = DateTime.UtcNow;
    }
}
