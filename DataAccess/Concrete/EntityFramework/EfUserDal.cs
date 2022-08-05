using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework

{
    public class EfUserDal : EfEntityRepositoryBase<User, Context>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new Context())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserID
                             select new OperationClaim {OperationClaimId = operationClaim.OperationClaimId, Name = operationClaim.Name };
                             return result.ToList();
            }
        }
    }
}
