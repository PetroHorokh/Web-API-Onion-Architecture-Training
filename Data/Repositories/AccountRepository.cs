using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class AccountRepository(DbContext context) : RepositoryBase<Account>(context), IAccountRepository
{
}