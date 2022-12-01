using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.Categories
{
    public class Details
    {
        public class Query: IRequest<Category>
        {
            public Int32 Id {get; set;}

        }

        public class Handler : IRequestHandler<Query, Category>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Category> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Category_Details.FindAsync(request.Id);
            }
        }

    }
}