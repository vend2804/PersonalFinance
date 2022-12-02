using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.Revenues
{
    public class Details
    {
         public class Query: IRequest<Revenue>
        {
            public Int32 Id {get; set;}

        }

        public class Handler : IRequestHandler<Query, Revenue>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Revenue> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Revenue_Details.FindAsync(request.Id);
            }
        }
    }
}