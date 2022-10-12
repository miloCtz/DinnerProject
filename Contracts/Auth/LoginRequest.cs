using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Auth
{
    public record class LoginRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password)
    {
    }
}
