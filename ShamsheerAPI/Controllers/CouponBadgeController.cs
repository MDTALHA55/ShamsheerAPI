using ShamsheerAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShamsheerAPI.Models.DTO;


namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponBadgeController : ControllerBase
    {
        private readonly ICouponBadge _ab;
        

        public CouponBadgeController(ICouponBadge ab)
        {
            _ab = ab;
            
        }


        [HttpGet]
        public JsonResult GetAll(string shamkey)
        {
            var result = _ab.GetAll(shamkey);
            return result;
        }

        [HttpGet("BadgePrint")]
        public JsonResult GetBadgePrint(string shamkey,Int64 id,Int64 bid)
        {
            var result = _ab.GetBadgePrint(shamkey,id,bid);
            return result;
        }



        [HttpPost]
        public string InsertCouponBadge([FromBody] CouponBadgeDTO cObj)
        {
            var result = _ab.InsertCouponBadge(cObj);
            return result;
        }


     


    }
}
