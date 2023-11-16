using System;
using System.Collections.Generic;

namespace CRUD.DataAccess.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdProduk { get; set; }

    public decimal Harga { get; set; }

    public int Jumlah { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Produk IdProdukNavigation { get; set; } = null!;
}
