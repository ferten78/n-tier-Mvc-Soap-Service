using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBusiness<TEntity>
    {
        void Add(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        TEntity GetById(int ID);
        List<TEntity> GetAll();
    }
}
