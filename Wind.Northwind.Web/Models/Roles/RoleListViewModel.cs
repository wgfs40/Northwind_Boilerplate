using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace Wind.Northwind.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public List<ComboboxItemDto> Permissions { get; set; }
    }
}