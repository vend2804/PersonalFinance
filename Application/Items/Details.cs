using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Persistance;

namespace Application.Items
{
    public class Details
    {
        public class Query: IRequest<Item>
        {
            public Int32 Id {get; set;}

        }

        public class Handler : IRequestHandler<Query, Item>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Item> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Item_Details.FindAsync(request.Id);
            }
        }

    }
}