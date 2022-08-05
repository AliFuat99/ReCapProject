using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            if (user.UserFirstName.Length < 2 && user.UserLastName.Length < 2)
            {
                return new ErrorResult(Messages.UserInvalid);
            }

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.UserEmail == email);

        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        } 


        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
