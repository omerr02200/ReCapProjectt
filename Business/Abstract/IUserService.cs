using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IEntityRepositoryService<User>
    {
        IDataResult <List<OperationClaim>> GetClaims(User user);
        IDataResult <User> GetByMail(string email);
    }
}
