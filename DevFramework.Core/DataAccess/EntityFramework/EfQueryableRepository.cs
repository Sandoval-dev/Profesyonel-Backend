using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;

        public EfQueryableRepository(DbContext context, IQueryable<T> table)
        {
            _context = context;
            Table = table;
        }

        public IQueryable<T> Table { get; }

        protected virtual IDbSet<T> Entities
        {
            get 
            { 
                if (_entities == null)
                {
                    _entities=_context.Set<T>();
                }
                return _entities;
            }
        }
    }
}
