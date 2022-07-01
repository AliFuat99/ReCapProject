using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework

{
    public class EfUserDal : EfEntityRepositoryBase<User, Context>, IUserDal
    {
        public List<UserDetailDto> GetUserDetailDto()
        {
            using (Context context = new Context())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserID equals c.CustomerID
                             select new UserDetailDto { UserId = u.UserID, FirstName = u.UserFirstName, LastName = u.UserLastName, CompanyName = c.CompanyName };
                return result.ToList();
            }
        }
    }
}
