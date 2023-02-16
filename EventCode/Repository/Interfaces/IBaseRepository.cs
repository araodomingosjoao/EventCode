namespace EventCode.Repository.Interfaces
{
    public interface IBaseRepository
    {
        public void Get<T> (T entity) where T : class;
        public void GetById<T> (T entity) where T : class;
        public void Create<T> (T entity) where T : class;
        public void Update<T> (T entity) where T : class;
        public void Delete<T> (T entity) where T : class;
        public bool SaveChanges();
    }
}
