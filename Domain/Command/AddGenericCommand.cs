using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class AddGenericCommand<TEntity> : IRequest<string> where TEntity : class
    {
        public TEntity Entity { get; }
        public AddGenericCommand(TEntity entity)
        {
            Entity = entity;
        }

    }
}
