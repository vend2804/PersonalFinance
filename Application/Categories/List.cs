using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories
{
    public class List
    {
        public class Query : IRequest<List<Category>>
        {
        }


        public class Handler : IRequestHandler<Query, List<Category>>
        {
             private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<List<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Category_Details.ToListAsync();
            }
        }

    }
}