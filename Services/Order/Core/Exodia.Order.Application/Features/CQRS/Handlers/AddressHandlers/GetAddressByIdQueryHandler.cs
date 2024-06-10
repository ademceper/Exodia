using Exodia.Order.Application.Features.CQRS.Queries.AddressQueries;
using Exodia.Order.Application.Features.CQRS.Results.AddressResults;
using Exodia.Order.Application.Interfaces;
using Exodia.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exodia.Order.Application.Features.CQRS.Handlers.AddressHandlers;
public class GetAddressByIdQueryHandler
{
	private readonly IRepository<Address> _repository;

	public GetAddressByIdQueryHandler(IRepository<Address> repository)
	{
		_repository = repository;
	}

	public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
	{
		var values = await _repository.GetByIdAsync(getAddressByIdQuery.Id);
		return new GetAddressByIdQueryResult { 
			UserId = values.UserId,
			City = values.City,
			District = values.District,
			Detail = values.Detail,
			Id = values.Id,
		
		};
	}
}
