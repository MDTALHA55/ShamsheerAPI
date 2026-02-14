using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QRCoder;
using ShamsheerAPI.Models.DTO;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Claims;
namespace ShamsheerAPI.Repositories
{
    public class CustomerUPIDetail(IConfiguration configuration) : ICustomerUPIDetail
    {
        private string connectionString = configuration.GetConnectionString("SHAM_CS");

        public JsonResult GetAll(string shamkey,string? type)
        {
            DataTable table = new DataTable();

            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {

                using (SqlCommand command = new SqlCommand("customer_upi_detail_tbl_get", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters

                    command.Parameters.AddWithValue("@shamkey", shamkey);
                    command.Parameters.AddWithValue("@type", type);
                    
                    #endregion

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(table);
                }
            }

            return new JsonResult(table);
        }


        public string InsertCustDetail(CustomerUPIDetailDTO cObj)
        {
            DataTable table = new DataTable();
            string QrCode = "";
            if (cObj.qrtype == 1 && cObj.qrtype != 0)
            {
                string paymentPayload = $"upi://pay?pa={cObj.upidetail}&pn={cObj.upiname}&am={cObj.amount}&cu=INR";
                QrCode = GeneratePaymentQR(paymentPayload);
            }
            if (cObj.qrtype == 2 && cObj.qrtype != 0)
            {
               
                QrCode = cObj.upidetail.ToString();
            }



            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand command = new SqlCommand("customer_upi_detail_tbl_insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters
                    command.Parameters.AddWithValue("@regid", cObj.regid);
                    command.Parameters.AddWithValue("@customername", cObj.customername);
                    command.Parameters.AddWithValue("@id", cObj.cdid);
                    command.Parameters.AddWithValue("@cid", cObj.cid);                  
                    command.Parameters.AddWithValue("@upiname", cObj.upiname);
                    command.Parameters.AddWithValue("@upidetail", cObj.upidetail);
                    command.Parameters.AddWithValue("@amount", cObj.amount);
                    command.Parameters.AddWithValue("@qr", QrCode);
                    command.Parameters.AddWithValue("@qrtype", cObj.qrtype);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();


                    #endregion
                }

            }
            return "successful";
        }

        public string GeneratePaymentQR(string paymentPayload)
        {
            string QrCode="";
           

            // 2. GENERATE THE QR CODE
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(paymentPayload, QRCodeGenerator.ECCLevel.Q);

                // PngByteQRCode is better for .NET Core/9 (Cross-platform compatible)
                PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeImage = qrCode.GetGraphic(20);
               
                string base64String = Convert.ToBase64String(qrCodeImage);
                 QrCode = $"data:image/png;base64,{base64String}";

               
            }

            return QrCode;
        }



        public JsonResult CustomerFillDetail(Int64 id, Int64 cid)
        {
            DataTable table = new DataTable();

            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {

                using (SqlCommand command = new SqlCommand("customer_fill_upi_detail_tbl_get", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@cid", cid);

                    #endregion

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(table);
                }
            }

            return new JsonResult(table);
        }



        public string InsertPayAdminToCust(CustomerUPIDetailDTO cObj)
        {
            DataTable table = new DataTable();
           



            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand command = new SqlCommand("customer_payment_detail_tbl_update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters
                    command.Parameters.AddWithValue("@shamkey", cObj.shamkey);

                    command.Parameters.AddWithValue("@cdid", cObj.cdid);
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
