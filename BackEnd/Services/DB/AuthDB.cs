using assignment_tess.Models;
using assignment_tess.Models.Helper;
using BCrypt.Net;
using Microsoft.Data.SqlClient;
using System.Data;

namespace assignment_tess.Services.DB
{
    public class AuthDB
    {
        SqlConnection? conn;
        SqlCommand? cmd;

        string connStr = new ConfigFile().GetConnectionString("db_tess");

        public bool RegisterDB(RegisterModel userModel)
        {
            bool ret = false;

            conn = new SqlConnection(connStr);
            cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "usp_create_user";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 300;

            try
            {
                conn.Open();

                cmd.Parameters.Add(new SqlParameter("nama_depan", userModel.nama_depan ?? string.Empty));
                cmd.Parameters.Add(new SqlParameter("nama_belakang", userModel.nama_belakang ?? string.Empty));
                cmd.Parameters.Add(new SqlParameter("email", userModel.email ?? string.Empty));
                cmd.Parameters.Add(new SqlParameter("password", BCrypt.Net.BCrypt.HashPassword(userModel.password) ?? string.Empty));

                cmd.ExecuteNonQuery();
                ret = true;
            }
            catch
            {

            } finally
            {
                if (conn.State == ConnectionState.Open) 
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return ret;
        }

        public LoginModel checkPass(LoginModel loginUser)
        {
            LoginModel ret = new LoginModel();

            conn = new SqlConnection(connStr);
            cmd = new SqlCommand();
            SqlDataReader rd;

            cmd.Connection = conn;
            cmd.CommandText = "usp_read_password";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 300;

            try
            {
                conn.Open();

                cmd.Parameters.Add(new SqlParameter("@email", loginUser.email));

                rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rd.Read())
                {
                    if (rd["password"] != DBNull.Value) { ret.password = rd["password"].ToString(); }
                }
            }
            catch 
            {
                
            } 
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return ret;
        }

        public AuthDto GetUser(LoginModel loginUser, out bool error, out long userId)
        {
            error = false;
            userId = 0;

            conn = new SqlConnection(connStr);
            cmd = new SqlCommand();

            SqlDataReader reader;
            AuthDto obj = new AuthDto();

            cmd.Connection = conn;
            cmd.CommandText = "usp_read_user";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 300;

            try
            {
                conn.Open();

                cmd.Parameters.Add(new SqlParameter("@email", loginUser.email));
                cmd.Parameters.Add(new SqlParameter("@password", loginUser.password));

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    if (reader["idUser"] != DBNull.Value) { obj.idUser = (int)reader["idUser"]; }
                    if (reader["nama_depan"] != DBNull.Value) { obj.nama_depan = reader["nama_depan"].ToString(); }
                    if (reader["nama_belakang"] != DBNull.Value) { obj.nama_belakang = reader["nama_belakang"].ToString(); }
                    if (reader["email"] != DBNull.Value) { obj.email = reader["email"].ToString(); }
                }
            }
            catch (Exception x)
            {

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return obj;
        }
    }
}
