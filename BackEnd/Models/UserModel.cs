using static assignment_tess.Models.Helper.GenericValidation;
using System.ComponentModel.DataAnnotations;

namespace assignment_tess.Models
{
    public class UserModel : RegisterModel
    {
        public int idUser { get; set; }

    }
    public class RegisterModel : LoginModel
    {
        [Required(ErrorMessage = "{0} Harus Diisi")]
        public string nama_depan { get; set; }

        [Required(ErrorMessage = "{0} Harus Diisi")]
        public string nama_belakang { get; set; }
    }
    public class LoginModel : emailModel
    {
        [Required(ErrorMessage = "{0} Harus Diisi")]
        [MinLength(8, ErrorMessage = "{0} Minimal {1} Karakter")]
        public string password { get; set; }
    }
    public class PermissionModel : LoginModel
    {
        public string? hakAkses { get; set; }
        public string? jabatan { get; set; }
    }
    public class emailModel
    {
        [Required(ErrorMessage = "{0} Harus Diisi")]
        [FormatEmail]
        public string email { get; set; }
    }

    public class Token
    {
        public string? token { get; set; }
    }
}
