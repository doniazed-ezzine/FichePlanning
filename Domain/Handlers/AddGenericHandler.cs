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
    public class AddGenericHandler<TEntity> : IRequestHandler<AddGenericCommand<TEntity>, string> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> Repository;

        public AddGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }

        public Task<string> Handle(AddGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Add(request.Entity);
            return Task.FromResult(result);
        }
    }
}
