using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareBlog.Core.Entity;

namespace SoftwareBlog.Core.DataAccess.EntityFramework
{
   public class EfQueryableRepository<T>:IQueryableRepository<T>
   where T: class,IEntity,new()
   {
       private DbContext _context;
       private IDbSet<T> _entities;

       public EfQueryableRepository(DbContext context)
       {
           _context = context;
       }


       public IQueryable<T> Table => this._entities;

       protected virtual IDbSet<T> Entities
       {
           get { return _entities ?? (_entities = _context.Set<T>()); }
           #region YazımTuru
            //    if (_entities==null)
            //{
            //    _entities = _context.Set<T>();
            //}

            //return _entities; 
            #endregion

        }
   }
}
