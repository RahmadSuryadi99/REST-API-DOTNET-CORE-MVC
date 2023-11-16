using System;
using System.Collections.Generic;

namespace CRUD.DataAccess.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nama { get; set; } = null!;

    public string Alamat { get; set; } = null!;

    public DateTime TglLahir { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
