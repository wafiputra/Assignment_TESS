using System.ComponentModel.DataAnnotations;

namespace assignment_tess.Models
{
    public class AuthDto
    {
        [Required(ErrorMessage = "{0} Harus Diisi")]
        public int idUser { get; set; }

        [Required(ErrorMessage = "{0} Harus Diisi")]
        public string nama_depan { get; set; }

        [Required(ErrorMessage = "{0} Harus Diisi")]
        public string nama_belakang { get; set; }

        [Required(ErrorMessage = "{0} Harus Diisi")]
        public string email { get; set; }
    }
}
