using Domain.Command;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class RemoveGenericHandler<TEntity> : IRequestHandler<RemoveGenericCommand<TEntity>, string> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> Repository;
        public RemoveGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }
        public Task<string> Handle(Command.RemoveGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Remove(request.Id);
            return Task.FromResult(result);
        }
    }
}
