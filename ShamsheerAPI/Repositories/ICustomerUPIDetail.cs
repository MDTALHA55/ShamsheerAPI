using ShamsheerAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ShamsheerAPI.Repositories
{
    public interface ICustomerUPIDetail
    {
        JsonResult GetAll(string shamkey,  string? type);
        
        string InsertCustDetail(CustomerUPIDetailDTO cObj);

        JsonResult CustomerFillDetail(Int64 id, Int64 cid);

        string InsertPayAdminToCust(CustomerUPIDetailDTO cObj);
    }
}
