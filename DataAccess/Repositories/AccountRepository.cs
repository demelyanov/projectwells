using status.domain.Interfaces;
using status.domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace status.dataaccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly StatusDbContext _context;

        public AccountRepository(StatusDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            return _context.Users.Where(u => u.Username == username && u.Password == password).SingleOrDefault();
        }
    }
}
