using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Persistance;
using Microsoft.EntityFrameworkCore;

namespace Application.Items
{
    public class List
    {
        public class Query : IRequest<List<Item>>
        {
        }


        public class Handler : IRequestHandler<Query, List<Item>>
        {
             private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<List<Item>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Item_Details.ToListAsync();
            }
        }

    }
}