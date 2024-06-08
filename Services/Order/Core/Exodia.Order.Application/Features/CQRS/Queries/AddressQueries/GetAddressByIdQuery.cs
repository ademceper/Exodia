using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exodia.Order.Application.Features.CQRS.Queries.AddressQueries;
public class GetAddressByIdQuery
{
    public Guid Id { get; set; }
    public GetAddressByIdQuery(Guid id)
    {
        Id = id;
    }
}
