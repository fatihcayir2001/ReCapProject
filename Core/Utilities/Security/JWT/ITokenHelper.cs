using System;
using System.Collections.Generic;
using System.Text;
using Core.Entitites.Concerete;
using Core.Utilities.Results;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    

    }
}
