using MongoDB.Bson;

namespace Mongo.WebUI.DAL.Services
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(ObjectId id);
        void Update(T entity);
        T GetById(ObjectId id);
        List<T> GetList();

    }
}
