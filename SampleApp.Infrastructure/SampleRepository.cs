using Infrastructure;
using Infrastructure.RepositoryPattern;
using Microsoft.EntityFrameworkCore;

namespace SampleApp.Infrastructure
{
    public class SampleRepository<T> : BaseRepository<T> where T : class
    {
        public SampleRepository(SampleContext dbContext) : base(dbContext)
        {
        }
    }
}