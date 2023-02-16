using EventCode.Context;
using EventCode.Repository.Interfaces;

namespace EventCode.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly MySQLContext _context;

        public BaseRepository(MySQLContext context) 
        {
            _context = context;
        }
        public void Create<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Get<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void GetById<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
         }

    }
}
