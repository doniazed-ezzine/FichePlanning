using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext context;
        private DbSet<TEntity> table = null;

        #region Constructor
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            table = this.context.Set<TEntity>();
        }
        #endregion

        #region Create Funtion
        public string Add(TEntity entity)
        {
            try
            {
                table.Add(entity);
                context.SaveChanges();
                return "Added Done";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #endregion

        #region Read Function
        public TEntity Get(Expression<Func<TEntity, bool>> condition, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            try
            {
                IQueryable<TEntity> query = table;

                if (includes != null)
                {
                    query = includes(query);
                }
                if (condition != null)
                    return query.FirstOrDefault(condition);
                else
                    return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> condition, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            try
            {
                //if (includes == null) throw new ArgumentNullException(nameof(includes));
                IQueryable<TEntity> query = table;

                if (includes != null)
                {
                    query = includes(query);
                }
                if (condition != null)
                    return query.Where(condition).ToList();

                else
                    return query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
        #endregion

        #region Update Function
        public string Put(TEntity entity)
        {
            try
            {
                //table.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return "Update Done";


            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
        #endregion

        #region Remove Function
        public string Remove(Guid id)
        {
            try
            {
                TEntity entity = table.Find(id);
                if (entity == null)
                    return "Not Found";
                else
                {
                    table.Remove(entity);
                    context.SaveChanges();
                    return "Delete Done";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #endregion

    }
}
