using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using IKFTEST.Models;

namespace IKFTEST.Models
{

   
    public class DbOparation
    {
        public ConnectionString conString = new ConnectionString();

        internal void Insert(User obj)
        {
            try
            {

                SqlConnection SqlCon = new SqlConnection(conString.connString);
                SqlCommand cmd = new SqlCommand("sp_insert", SqlCon);
                SqlCon.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@DOB", obj.DOB);
                cmd.Parameters.AddWithValue("@Designation", obj.Designation);
                cmd.Parameters.AddWithValue("@Skills", obj.Skills);
                cmd.ExecuteNonQuery();

                



            }
            catch (Exception ex)
            {


            }
        }





        internal List<User> getAll()
        {
            List<User> objlist = new List<User>();
            try
            {
                SqlConnection SqlCon = new SqlConnection(conString.connString);
                SqlCon.Open();
                SqlCommand Sqlcmd = new SqlCommand("select * from tbl_User", SqlCon);

                SqlDataReader readar = Sqlcmd.ExecuteReader();

                while (readar.Read())
                {
                    try
                    {
                        User obj = new User();
                        obj.id = readar["Id"].ToString();
                        obj.Name= readar["Name"].ToString();
                        obj.DOB = readar["DOB"].ToString();
                        obj.Designation = readar["Designation"].ToString();
                        obj.Skills = readar["Skills"].ToString();
                        objlist.Add(obj);
                    }
                    catch (Exception objEx)
                    {

                    }

                }
            }

            catch (Exception objEx)
            {

            }
            return objlist;
        }




        internal void Update(User obj)
        {
            try
            {
                //  Product obj = new Product();
                SqlConnection SqlCon = new SqlConnection(conString.connString);
                SqlCommand cmd = new SqlCommand("sp_Update", SqlCon);
                SqlCon.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", obj.id);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@DOB", obj.DOB);
                cmd.Parameters.AddWithValue("@Designation", obj.Designation);
                cmd.Parameters.AddWithValue("@Skills", obj.Skills);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {


            }

        }

        public bool Delete(string id)
        {
            SqlConnection SqlCon = new SqlConnection(conString.connString);
            SqlCon.Open();
            SqlCommand cmd = new SqlCommand("sp_Delete", SqlCon);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            SqlCon.Open();
            int i = cmd.ExecuteNonQuery();
            SqlCon.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }



        public User GetById(String id)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString.connString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("sp_getbyid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
               
                SqlDataReader reader = cmd.ExecuteReader();


                User user = new User();
                while (reader.Read())
                {
                    user.id =  reader["ID"].ToString();

                    user.Name = reader["Name"].ToString();
                    user.DOB = reader["DOB"].ToString();
                    user.Designation = reader["Designation"].ToString();
                    user.Skills = reader["Skills"].ToString();
                    
                    

                }
                con.Close();
                return user;
            }
            catch (Exception ex)
            {

            }
            return null;
        }




    }
}