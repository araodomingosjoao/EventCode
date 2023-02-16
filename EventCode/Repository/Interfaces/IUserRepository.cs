using EventCode.Models.Entities;
using System;
using System.Collections.Generic;

namespace EventCode.Repository.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User GetById(Guid id);
        void Create(User user);
        bool SaveChanges();
    }
}
