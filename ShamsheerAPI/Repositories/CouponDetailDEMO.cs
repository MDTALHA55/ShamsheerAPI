using ShamsheerAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

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

                using (SqlCommand command = new SqlCommand("coupon_detail_tbl_getDEMO", connection))
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
            DataTable table = new DataTable();


            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand command = new SqlCommand("coupon_QR_tbl_insertDEMO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters
                    command.Parameters.AddWithValue("@shamkey", cObj.shamkey);
                    command.Parameters.AddWithValue("@cdid", cObj.cdid);
                    command.Parameters.AddWithValue("@cid", cObj.cid);
                  
                    command.Parameters.AddWithValue("@coupon_url", cObj.coupon_url);
                    command.Parameters.AddWithValue("@coupon_qr", cObj.coupon_qr);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();


                    #endregion
                }

            }
            return "successful";
        }

        public string UpdateCouponDetail(CouponDTO cObj)
        {
            DataTable table = new DataTable();

            string sqlDataSource = connectionString;

            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {

                using (SqlCommand command = new SqlCommand("coupon_detail_tbl_updateDEMO", connection))
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
                using (SqlCommand command = new SqlCommand("coupon_detail_tbl_deleteDEMO", connection))
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
