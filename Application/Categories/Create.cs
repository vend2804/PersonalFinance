using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.Categories
{
    public class Create
    {

            public class Command: IRequest
            {
                public Category Category {get; set;}

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
                 _context.Category_Details.Add(request.Category);
                 await _context.SaveChangesAsync();

                 return Unit.Value;

            }
        }

    }
}