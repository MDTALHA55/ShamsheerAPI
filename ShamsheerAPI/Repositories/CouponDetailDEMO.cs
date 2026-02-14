using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QRCoder;
using ShamsheerAPI.Models.DTO;
using System.Data;
using System.Security.Cryptography;
using static QRCoder.PayloadGenerator;

namespace ShamsheerAPI.Repositories
{
    public class CouponDetailDEMO(IConfiguration configuration) : ICouponDetailDEMO
    {
        private string connectionString = configuration.GetConnectionString("SHAM_CS");
        public JsonResult GetAll(string shamkey, Int64? id, Int64? cid, string? type)
        {
            DataTable table = new DataTable();

            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {

                using (SqlCommand command = new SqlCommand("coupon_detail_tbl_get", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters

                    command.Parameters.AddWithValue("@shamkey", shamkey);
                    command.Parameters.AddWithValue("@id", id);                    
                    command.Parameters.AddWithValue("@cid", cid);                    
                    command.Parameters.AddWithValue("@type", type);
                   
                    #endregion

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(table);
                }
            }

            return new JsonResult(table);
        }



        public string InsertCouponDetail(CouponDTO cObj)
        {
            //// var qrpath = `${c_url}/Payment_Detail.html?id=${id}&cid=${cid}`;
            DataTable table = new DataTable();
            string QrCode = "";
            if (cObj.curl !="" && cObj.cdid != 0)
            {
                string qrpath = $"{cObj.curl}/Payment_Detail.html?id={cObj.cdid}&cid={cObj.cid}";
                QrCode = GeneratePaymentQR(qrpath);
            }
            else
            {
                return "Faild";
            }


            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand command = new SqlCommand("coupon_QR_tbl_insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters
                    command.Parameters.AddWithValue("@shamkey", cObj.shamkey);
                    command.Parameters.AddWithValue("@cdid", cObj.cdid);
                    command.Parameters.AddWithValue("@coupon_id", cObj.cid);                  
                    command.Parameters.AddWithValue("@coupon_url", cObj.curl);
                    command.Parameters.AddWithValue("@coupon_qr", QrCode);
                    command.Parameters.AddWithValue("@badge_id", cObj.bid);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();


                    #endregion
                }

            }
            return "successful";
        }

        public string GeneratePaymentQR(string qrpath)
        {
            string QrCode = "";

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrpath, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeImage = qrCode.GetGraphic(20);
                string base64String = Convert.ToBase64String(qrCodeImage);
                QrCode = $"data:image/png;base64,{base64String}";


            }


            return QrCode;
        }
        public string UpdateCouponDetail(CouponDTO cObj)
        {
            DataTable table = new DataTable();

            string sqlDataSource = connectionString;

            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {

                using (SqlCommand command = new SqlCommand("coupon_detail_tbl_update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters
                    command.Parameters.AddWithValue("@shamkey", cObj.shamkey);
                    command.Parameters.AddWithValue("@id", cObj.id);
                    command.Parameters.AddWithValue("@coupon_id", cObj.coupon_id);
                    command.Parameters.AddWithValue("@coupon_amount", cObj.coupon_amount);
                    command.Parameters.AddWithValue("@coupon_count", cObj.coupon_count);                  
                    command.Parameters.AddWithValue("@coupon_url", cObj.coupon_url);
                    command.Parameters.AddWithValue("@coupon_qr", cObj.coupon_qr);
                    command.Parameters.AddWithValue("@active", cObj.active);
                    command.Parameters.AddWithValue("@expire_at", cObj.expire_at);



                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();


                    #endregion

                }
            }
            return "successful";
        }


        public string DeleteCouponDetail(string shamkey, Int64? id)
        {
            DataTable table = new DataTable();
            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand command = new SqlCommand("coupon_detail_tbl_delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters
                    command.Parameters.AddWithValue("@shamkey", shamkey);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    #endregion
                }
            }
            return "successful";



        }




        public string UpdateCouponOneData(CouponDTO cObj)
        {
            DataTable table = new DataTable();

            string sqlDataSource = connectionString;

            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {

                using (SqlCommand command = new SqlCommand("coupon_detail_tbl_one_update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters
                    command.Parameters.AddWithValue("@shamkey", cObj.shamkey);
                    command.Parameters.AddWithValue("@id", cObj.id);
                    command.Parameters.AddWithValue("@cid", cObj.cid);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();


                    #endregion

                }
            }
            return "successful";
        }

    }

}
