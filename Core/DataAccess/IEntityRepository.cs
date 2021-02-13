using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<Y> where Y:class,IEntity,new()
    {
        List<Y> GetAll(Expression<Func<Y, bool>> filter = null);
        Y Get(Expression<Func<Y, bool>> filter);
        void Add(Y entity);
        void Update(Y entity);
        void Delete(Y entity);
    }
}
