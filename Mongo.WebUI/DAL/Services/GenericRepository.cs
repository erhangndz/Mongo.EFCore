using Mongo.WebUI.Context;
using MongoDB.Bson;

namespace Mongo.WebUI.DAL.Services
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly MongoContext _context;

        public GenericRepository(MongoContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(ObjectId id)
        {
            var value = GetById(id);
            _context.Remove(value);
            _context.SaveChanges();
        }

        public T GetById(ObjectId id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
          _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
