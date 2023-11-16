using System.ComponentModel.DataAnnotations;

namespace CRUD.ViewModel
{
    public class UserVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="tidak boleh kosong")]
        public string Nama { get; set; } 


        [Required(ErrorMessage ="tidak boleh kosong")]
        public string Alamat { get; set; } 

        [Required(ErrorMessage ="tidak boleh kosong")]
        public DateTime TglLahir { get; set; }
    }
}