using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Persistance;

namespace Application.Items
{
    public class Create
    {

            public class Command: IRequest
            {
                public Item Item {get; set;}

            }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                 _context.Item_Details.Add(request.Item);
                 await _context.SaveChangesAsync();

                 return Unit.Value;

            }
        }

    }
}