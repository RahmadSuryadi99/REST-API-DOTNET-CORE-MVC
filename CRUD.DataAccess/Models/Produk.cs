using System;
using System.Collections.Generic;

namespace CRUD.DataAccess.Models;

public partial class Produk
{
    public int Id { get; set; }

    public string Nama { get; set; } = null!;

    public decimal Harga { get; set; }

    public string? Deskripsi { get; set; }

    public int Category { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category CategoryNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
