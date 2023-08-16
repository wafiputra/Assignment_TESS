using assignment_tess.Models;
using assignment_tess.Models.Helper;
using assignment_tess.Services.DB;
using BCrypt.Net;
using System.ComponentModel.DataAnnotations;

namespace assignment_tess.Services
{
    public class AuthService
    {

        public ResponseHandler RegisterService(RegisterModel registerModel)
        {
            ResponseHandler msg = new ResponseHandler();
            MetaData msgDetail = new MetaData();

            try
            {
                ValidationContext context = new ValidationContext(registerModel, null, null);
                List<ValidationResult> result = new List<ValidationResult>();
                bool valid = Validator.TryValidateObject(registerModel, context, result, true);

                if (!valid)
                {
                    bool insert = new AuthDB().RegisterDB(registerModel);
                    if (insert)
                    {
                        msgDetail.code = 200;
                        msgDetail.message = "Registrasi Berhasil";
                    }
                }
                else
                {
                    msgDetail.code = 403;
                    msgDetail.message = "Registrasi Gagal";
                }
            }
            catch (Exception ex)
            {

            }
            msg.metaData = msgDetail;

            return msg;
        }

        public ResponseHandler LoginService(LoginModel loginModel)
        {
            AuthDto loginUser = new AuthDto();
            ResponseHandler msg = new ResponseHandler();
            MetaData msgDetail = new MetaData();
            msg.metaData = msgDetail;

            try
            {
                bool error;
                long userId;

                LoginModel checkPwd = new AuthDB().checkPass(loginModel);

                if (checkPwd != null)
                {
                    if (!BCrypt.Net.BCrypt.Verify(loginModel.password, checkPwd.password))
                    {
                        msgDetail.message = "Password Tidak sesuai.";
                        msgDetail.code = 202;
                    }
                    else
                    {
                        LoginModel loginData = new LoginModel { email = loginModel.email, password = checkPwd.password };
                        loginUser = new AuthDB().GetUser(loginData, out error, out userId);

                        if (!error)
                        {
                            string token = new JWTHandler().CreateToken(loginUser, out string err);

                            if (string.IsNullOrEmpty(token))
                            {
                                msgDetail.message = err;
                                msgDetail.code = 400;
                            }
                            else
                            {
                                Token response = new Token { token = token };
                                msgDetail.message = "Login Sukses.";
                                msgDetail.code = 200;
                                msg.response = response;
                            }
                        }
                        else
                        {
                            msgDetail.message = "Email/Password tidak sesuai.";
                            msgDetail.code = 201;
                            msg.metaData = msgDetail;
                            msg.response = null;
                        }
                    }
                }
            }
            catch (Exception x)
            {

            }

            return msg;
        }
    }
}
