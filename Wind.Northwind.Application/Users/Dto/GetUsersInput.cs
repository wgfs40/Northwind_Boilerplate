using Abp.Runtime.Validation;
using Abp.Application.Services.Dto;
using Wind.Northwind.Dto;

namespace Wind.Northwind.Users.Dto
{
    public class GetUsersInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Name,Surname";
            }
        }
    }

    
}



