using EventCode.Context;
using EventCode.Models.Entities;
using EventCode.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventCode.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
        }

    }
}
