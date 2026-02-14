

namespace ShamsheerAPI.Models.DTO
{
    public class CustomerUPIDetailDTO
    {

        public Int64? regid { get; set; }
        public Int64?	cust_id	{get;set;}
        public Int64?	cid		{get;set;}
        public Int64? cdid { get;set;} //cdid
        public string? shamkey { get;set;}
        public string?	upiname		{get;set;}
        public string? customername { get;set;}
        public string?	upidetail		{get;set;}
        public decimal	amount			{get;set;}
        public string?	qr				{get;set;}
        public int qrtype { get;set;}
        public string?	status			{get;set;}
        public string?	created_at		{get;set;}
        public string?	payment_at		{get;set;}



    }
}
