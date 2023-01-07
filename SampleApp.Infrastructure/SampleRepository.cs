using Infrastructure.RepositoryPattern;
using Microsoft.EntityFrameworkCore;

namespace SampleApp.Infrastructure
{
    public class SampleRepository<T> : BaseRepository<T> where T : class
    {
        public SampleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}