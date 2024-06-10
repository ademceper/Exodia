using Exodia.Order.Application.Features.CQRS.Commands.AddressCommands;
using Exodia.Order.Application.Interfaces;
using Exodia.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exodia.Order.Application.Features.CQRS.Handlers.AddressHandlers;
public class CreateAddressCommandHandler
{
	private readonly IRepository<Address> _repository;
    public CreateAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateAddressCommand createAddressCommand)
    {
        await _repository.CreateAsync(new Address
        {
            City = createAddressCommand.City,
            Detail = createAddressCommand.Detail,
            District = createAddressCommand.District,
            UserId = createAddressCommand.UserId
        });
    }

}
