using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Persistance;
using Microsoft.EntityFrameworkCore;

namespace Application.Revenues
{
    public class List
    {
        public class Query : IRequest<List<Revenue>>
        {
        }


        public class Handler : IRequestHandler<Query, List<Revenue>>
        {
             private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<List<Revenue>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Revenue_Details.ToListAsync();
            }
        }

    }
}