using ShamsheerAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShamsheerAPI.Models.DTO;


namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponDetailController : ControllerBase
    {
        private readonly ICouponDetail _ab;
        

        public CouponDetailController(ICouponDetail ab)
        {
            _ab = ab;
            
        }


        [HttpGet]
        public JsonResult GetAll(string shamkey, Int64? id, Int64? cid, string? type)
        {
            var result = _ab.GetAll(shamkey, id,cid,  type);
            return result;
        }

		

		[HttpPost]
        public string InsertCouponDetail([FromBody]  CouponDTO cObj)
        {
            var result = _ab.InsertCouponDetail(cObj);
            return result;
        }

        [HttpPut]
        public string UpdateCouponDetail([FromBody] CouponDTO cObj)
        {
            var result = _ab.UpdateCouponDetail(cObj);
            return result;
        }

		[HttpDelete]
		public string DeleteCouponDetail(string shamkey, Int64? id)
        {
			var result = _ab.DeleteCouponDetail(shamkey, id);
			return result;
		}

        [HttpPut("OneData")]
        public string UpdateCouponOneData([FromBody] CouponDTO cObj)
        {
            var result = _ab.UpdateCouponOneData(cObj);
            return result;
        }

    }
}
