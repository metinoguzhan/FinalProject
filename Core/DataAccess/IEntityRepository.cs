using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    //generic constraint => Generic kısıt
    //class => referans tip olabilir demektir.
    //IEntity => IEntity olabilir veya IEntity implemente eden bir nesne olabilir..
    //new() => newlenebilir olmalıdır.
    public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
