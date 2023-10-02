using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace DevFramework.Core.DataAccess.NHihabernate
{
    public class NhEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        NHibernateHelper _nhibernateHelper;

        public NhEntityRepositoryBase(NHibernateHelper nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper;
        }

        public TEntity Add(TEntity entity)
        {
            using (var sessions = _nhibernateHelper.OpenSession())
            {
                sessions.Save(entity);
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var sessions = _nhibernateHelper.OpenSession())
            {
                sessions.Delete(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var sessions = _nhibernateHelper.OpenSession())
            {
                return sessions.Query<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var sessions = _nhibernateHelper.OpenSession())
            {
                return filter == null ? sessions.Query<TEntity>().ToList() : sessions.Query<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var sessions = _nhibernateHelper.OpenSession())
            {
                sessions.Update(entity);
                return entity;
            }
        }
    }
}
