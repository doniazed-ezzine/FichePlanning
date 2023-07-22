using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class PutGenericCommand<TEntity> : IRequest<string> where TEntity : class
    {
        public PutGenericCommand(TEntity entity)
        {
            //Id = id;
            Entity = entity;
        }

        // public Guid Id { get; }
        public TEntity Entity { get; }

    }
}
