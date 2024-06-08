using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exodia.Order.Application.Features.CQRS.Commands.AddressCommands;
public class DeleteAddressCommand
{
    public Guid Id { get; set; }

	public DeleteAddressCommand(Guid id)
	{
		Id = id;
	}
}
