using ShamsheerAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ShamsheerAPI.Repositories
{
    public interface ICouponBadge
    {
        JsonResult GetAll(string shamkey);
        JsonResult GetBadgePrint(string shamkey, Int64 id, Int64 bid);

        string InsertCouponBadge(CouponBadgeDTO cObj);


    }
    
}
