using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exodia.Order.Domain.Entities;
public class Address
{
	public Guid Id { get; set; }
	public string UserId { get; set; }
	public string District { get; set; }
	public string City { get; set; }
	public string Detail { get; set; }
}
