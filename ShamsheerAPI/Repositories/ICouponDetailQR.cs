using ShamsheerAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ShamsheerAPI.Repositories
{
    public interface ICouponDetailQR
    {
        JsonResult GetAll(string shamkey, Int64? id);
       
        string InsertCouponDetail(CouponDTO cObj);
        string UpdateCouponDetail(CouponDTO cObj);
        string DeleteCouponDetail(string shamkey, Int64? id);


        string UpdateCouponOneData(CouponDTO cObj);

    }
}
