using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity //Esta es una restricción de tipo para el parámetro de tipo T.
                                                         //La restricción where T : BaseEntity significa que T debe ser
                                                         //un tipo que herede de BaseEntity o debe ser BaseEntity misma.
                                                         //Esto asegura que solo las clases que derivan de BaseEntity pueden
                                                         //ser utilizadas con esta interfaz. 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
