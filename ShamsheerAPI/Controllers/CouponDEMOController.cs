using ShamsheerAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShamsheerAPI.Models.DTO;


namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponDEMOController : ControllerBase
    {
        private readonly ICouponDEMO _ab;
        

        public CouponDEMOController(ICouponDEMO ab)
        {
            _ab = ab;
            
        }


        [HttpGet]
        public JsonResult GetAll(string shamkey, Int64? id, string? type)
        {
            var result = _ab.GetAll(shamkey, id,  type);
            return result;
        }

		

		[HttpPost]
        public string InsertCoupon([FromBody]  CouponDTO cObj)
        {
            var result = _ab.InsertCoupon(cObj);
            return result;
        }

        [HttpPut]
        public string UpdateCoupon([FromBody] CouponDTO cObj)
        {
            var result = _ab.UpdateCoupon(cObj);
            return result;
        }

		[HttpDelete]
		public string DeleteCoupon(string shamkey, Int64? id)
        {
			var result = _ab.DeleteCoupon(shamkey, id);
			return result;
		}



	}
}
