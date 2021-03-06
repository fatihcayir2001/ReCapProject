using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entitites.Concerete;

namespace DataAccess.Concerete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarProjectContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                                                join userOperationClaim in context.UserOperationClaims
                                                on operationClaim.Id equals userOperationClaim.OperationClaimId
                                                where userOperationClaim.UserId == user.Id
                                                select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
