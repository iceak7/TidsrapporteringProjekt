using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TidsrapporteringProjekt.API.Services
{
    public interface ITidsrapporteringProjekt<T>
    {
        Task<T> Add(T newEntity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<T> GetSingle(int id);
    }
}
