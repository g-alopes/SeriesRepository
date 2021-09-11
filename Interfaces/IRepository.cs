using System.Collections.Generic;

namespace GL.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();       
        void Insert(T serie);        
        void Delete(int id);        
        void Update(int id, T serie);
        int NextId();
    }
}