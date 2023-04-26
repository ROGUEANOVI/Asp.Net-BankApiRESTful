using Ardalis.Specification.EntityFrameworkCore;
using BankApiRESTful.Application.Interfaces;
using BankApiRESTful.Persintence.Contexts;

namespace BankApiRESTful.Persintence.Repository
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly AppDbContext _context;

        public MyRepositoryAsync(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
