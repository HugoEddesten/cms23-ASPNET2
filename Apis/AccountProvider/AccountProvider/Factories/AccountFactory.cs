using AccountProvider.Entities;
using AccountProvider.Models;

namespace AccountProvider.Factories;

public class AccountFactory
{
    public static AccountEntity Create(AccountModel model)
    {
        var entity = new AccountEntity
        {
            UserId = model.UserId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };
        return entity;
    }
}
