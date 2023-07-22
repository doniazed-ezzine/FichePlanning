using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class GetGenericQuery<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public GetGenericQuery(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            Condition = condition;
            Includes = includes;
        }
        public Expression<Func<TEntity, bool>> Condition { get; set; }
        public Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Includes { get; set; }
    }
}
