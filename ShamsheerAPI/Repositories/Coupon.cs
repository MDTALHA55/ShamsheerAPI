using ShamsheerAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ShamsheerAPI.Repositories
{
    public class Coupon(IConfiguration configuration) : ICoupon
    {
        private string connectionString = configuration.GetConnectionString("SHAM_CS");
        public JsonResult GetAll(string shamkey, Int64? id,string? type)
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
                    command.Parameters.AddWithValue("@type", type);
                   
                    #endregion

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(table);
                }
            }

            return new JsonResult(table);
        }




        public string InsertCoupon(CouponDTO cObj)
        {
            DataTable table = new DataTable();


            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand command = new SqlCommand("coupon_detail_tbl_insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters
                    command.Parameters.AddWithValue("@shamkey", cObj.shamkey);
                    command.Parameters.AddWithValue("@coupon_amount", cObj.coupon_amount);
                    command.Parameters.AddWithValue("@coupon_count", cObj.coupon_count);
                    command.Parameters.AddWithValue("@coupon_name", cObj.coupon_name);
                    command.Parameters.AddWithValue("@coupon_url", cObj.coupon_url);
                    command.Parameters.AddWithValue("@expire_at", cObj.expire_at);
                    
                    

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();


                    #endregion
                }

            }
            return "successful";
        }

        public string UpdateCoupon(CouponDTO cObj)
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
                    command.Parameters.AddWithValue("@coupon_amount", cObj.coupon_amount);
                    command.Parameters.AddWithValue("@coupon_count", cObj.coupon_count);
                    command.Parameters.AddWithValue("@coupon_name", cObj.coupon_name);
                    command.Parameters.AddWithValue("@coupon_url", cObj.coupon_url);
                    command.Parameters.AddWithValue("@expire_at", cObj.expire_at);


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();


                    #endregion

                }
            }
            return "successful";
        }


        public string DeleteCoupon(string shamkey, Int64? id)
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


		



	}

}
