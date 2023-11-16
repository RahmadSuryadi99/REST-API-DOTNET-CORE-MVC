using System;
using System.Collections.Generic;

namespace CRUD.DataAccess.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Nama { get; set; } = null!;

    public string Deskripsi { get; set; } = null!;

    public virtual ICollection<Produk> Produks { get; set; } = new List<Produk>();
}
