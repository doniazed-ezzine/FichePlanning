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
    public class GetListGenericQuery<TEntity> : IRequest<IEnumerable<TEntity>> where TEntity : class
    {
        public GetListGenericQuery(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            CancellationToken cancellationToken = default)
        {
            Condition = condition;
            Includes = includes;
        }
        public Expression<Func<TEntity, bool>> Condition { get; set; }
        public Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Includes { get; set; }
    }
}
