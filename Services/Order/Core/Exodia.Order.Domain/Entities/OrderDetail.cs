using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exodia.Order.Domain.Entities;
public class OrderDetail
{
    public Guid Id { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductDecimal { get; set; }
    public int ProductAmount { get; set; }
    public decimal ProductDecimalPrice { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}
