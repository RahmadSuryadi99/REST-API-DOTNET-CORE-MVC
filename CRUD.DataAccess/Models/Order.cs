using System;
using System.Collections.Generic;

namespace CRUD.DataAccess.Models;

public partial class Order
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
