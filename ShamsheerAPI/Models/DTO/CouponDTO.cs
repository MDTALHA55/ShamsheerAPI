

namespace ShamsheerAPI.Models.DTO
{
    public class CouponDTO
    {

        public string shamkey { get; set; }

        public Int64? id { get; set; }
        public Int64? coupon_id { get; set; }
        public Int64? reg_id { get; set; }
        public decimal coupon_amount { get; set; }
        public Int64? coupon_count { get; set; }
        public string? coupon_name { get; set; }
        public Boolean active { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_at { get; set; }



        public Int64? coupon_detail_id { get; set; }
        
        
        public string? coupon_url { get; set; }
        
        public DateTime? expire_at { get; set; }





























    }
}
