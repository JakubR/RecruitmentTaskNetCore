namespace SIENN.Services.Common
{
    public interface ICrudService<T>
    {
        T Create(T entity);
        void Delete(int id);
        T Get(int id);
        T Update(T entity);
    }
}