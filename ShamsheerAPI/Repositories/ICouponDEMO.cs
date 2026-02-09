using ShamsheerAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ShamsheerAPI.Repositories
{
    public interface ICouponDEMO
    {
        JsonResult GetAll(string shamkey, Int64? id, string? type);
       
        string InsertCoupon(CouponDTO cObj);
        string UpdateCoupon(CouponDTO cObj);
        string DeleteCoupon(string shamkey, Int64? id);


        

	}
}
