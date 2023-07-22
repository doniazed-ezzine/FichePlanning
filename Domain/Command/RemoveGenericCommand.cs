using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class RemoveGenericCommand<T> : IRequest<string> where T : class
    {
        public RemoveGenericCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
