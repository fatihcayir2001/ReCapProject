using Core.DataAccess;
using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entitites.Concerete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
