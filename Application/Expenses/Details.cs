using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.Expenses
{
    public class Details
    {
          public class Query: IRequest<Expense>
        {
            public Int32 Id {get; set;}

        }

        public class Handler : IRequestHandler<Query, Expense>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Expense> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Expense_Details.FindAsync(request.Id);
            }
        }
    }
}