using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wind.Northwind.Permissions.Dto
{
    public class FlatPermissionWithLevelDto : PermissionListDto
    {
        public int Level { get; set; }
    }
}
