using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistance;

namespace Application.Expenses
{
    public class Delete
    {
         public class Command : IRequest
        {
            public Int32 Id {get; set;}

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
                    var expense = await _context.Expense_Details.FindAsync(request.Id);

                    _context.Remove(expense);

                    await _context.SaveChangesAsync();

                    return Unit.Value;

            }
        }
    }
}