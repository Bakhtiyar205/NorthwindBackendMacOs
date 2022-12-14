using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.Identity.Client;

namespace DataAccess.Abstract;

public interface IUserDal : IEntityRepository<User>
{
    List<OperationClaim> GetClaims(User user);
}