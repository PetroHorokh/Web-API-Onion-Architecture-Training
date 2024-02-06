using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class OwnerRepository(DbContext context) : RepositoryBase<Owner>(context), IOwnerRepository
{
}