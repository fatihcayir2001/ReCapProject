using Core.Utilities.Results;
using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entitites.Concerete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        public IDataResult<User> GetByEmail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);

    }
}
