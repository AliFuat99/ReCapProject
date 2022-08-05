using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<List<User>> GetAll();
    }
}
