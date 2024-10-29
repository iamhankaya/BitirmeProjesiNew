using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
