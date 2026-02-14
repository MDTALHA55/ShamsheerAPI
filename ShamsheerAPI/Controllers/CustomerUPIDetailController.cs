using ShamsheerAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShamsheerAPI.Models.DTO;


namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerUPIDetailController : ControllerBase
    {
        private readonly ICustomerUPIDetail _ab;
        

        public CustomerUPIDetailController(ICustomerUPIDetail ab)
        {
            _ab = ab;
            
        }


        [HttpGet]
        public JsonResult GetAll(string shamkey,  string? type)
        {
            var result = _ab.GetAll(shamkey,  type);
            return result;
        }

        [HttpPost]
        public string InsertCustDetail([FromBody] CustomerUPIDetailDTO cObj)
        {
            var result = _ab.InsertCustDetail(cObj);
            return result;
        }


        [HttpGet("GetCAID")]
        public JsonResult CustomerFillDetail(Int64 id, Int64 cid)
        {
            var result = _ab.CustomerFillDetail(id, cid);
            return result;
        }

        [HttpPut("Payment")]
        public string InsertPayAdminToCust([FromBody] CustomerUPIDetailDTO cObj)
        {
            var result = _ab.InsertPayAdminToCust(cObj);
            return result;
        }

    }
}
