using System;
using System.Collections.Generic;
using System.Text;
using Core.Entitites.Concerete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);


    }
}
