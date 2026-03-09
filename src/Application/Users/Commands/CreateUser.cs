using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qr_code.Application.Users.Commands;

public class CreateUser : IRequest<Guid>
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }
}

public class CreateUserHandler : IRequestHandler<CreateUser, Guid>
{

}

