using System;
using System.Collections.Generic;

namespace CRUD.DataAccess.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int IdProduk { get; set; }

    public int IdUser { get; set; }

    public int Jumlah { get; set; }

    public virtual Produk IdProdukNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
