using ShamsheerAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ShamsheerAPI.Repositories
{
    public class CouponBadge(IConfiguration configuration) : ICouponBadge
    {
        private string connectionString = configuration.GetConnectionString("SHAM_CS");
        public JsonResult GetAll(string shamkey)
        {
            DataTable table = new DataTable();

            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {

                using (SqlCommand command = new SqlCommand("coupon_badge_tbl_get", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters

                    command.Parameters.AddWithValue("@shamkey", shamkey);                                        
                    
                    #endregion

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(table);
                }
            }

            return new JsonResult(table);
        }

        public JsonResult GetBadgePrint(string shamkey, Int64 id, Int64 bid)
        {
            DataTable table = new DataTable();

            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {

                using (SqlCommand command = new SqlCommand("coupon_QR_tbl_print_get", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters

                    command.Parameters.AddWithValue("@shamkey", shamkey);
                    command.Parameters.AddWithValue("@cid", id);
                    command.Parameters.AddWithValue("@bid", bid);

                    #endregion

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(table);
                }
            }

            return new JsonResult(table);
        }

        public string InsertCouponBadge(CouponBadgeDTO cObj)
        {
            DataTable table = new DataTable();


            string sqlDataSource = connectionString;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand command = new SqlCommand("coupon_badge_tbl_insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    #region parameters
                    command.Parameters.AddWithValue("@shamkey", cObj.shamkey);
                    command.Parameters.AddWithValue("@coupon_id", cObj.cid);
                    command.Parameters.AddWithValue("@totalactive", cObj.tselect);
                    command.Parameters.AddWithValue("@totalinactive", cObj.tleft);   
                    SqlDataAdapter da=new SqlDataAdapter(command);
                    da.Fill(table);
                    if(table.Rows.Count > 0)
                    {
                        return table.Rows[0]["id"].ToString();
                    }
                    else
                    {
                        return "Faild";
                    }

                    //connection.Open();
                    //command.ExecuteNonQuery();
                    //connection.Close();


                    #endregion
                }

            }
            //return "successful";
        }

        

        

    }

}
