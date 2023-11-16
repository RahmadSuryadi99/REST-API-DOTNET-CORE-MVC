using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.ViewModel
{
    public class ProdukVM
    {
        public int Id { get; set; }

        public string Nama { get; set; }

        public decimal Harga { get; set; }

        public string? Deskripsi { get; set; }

        public int Category { get; set; }
    }
}
