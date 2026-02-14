

namespace ShamsheerAPI.Models.DTO
{
    public class CouponBadgeDTO
    {
        public string shamkey { get; set; }
        public Int64? regid { get; set; }
        public Int64?	id	{get;set;}
        public Int64?	cid		{get;set;}
        public Int64? cdid { get;set;} 
        public Int64? ccount { get;set;} 
        public Int64? caid { get;set;} 
        public Int64? tselect { get;set;} 
        public Int64? tleft { get;set;} 
        
        public Boolean	active			{get;set;}
        public Boolean	status			{get;set;}
        public Boolean printbit { get;set;}
        public DateTime?	created_at		{get;set;}
      



    }
}
