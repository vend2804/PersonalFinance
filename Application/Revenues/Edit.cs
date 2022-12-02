using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.Revenues
{
    public class Edit
    {
         public class Command: IRequest
        {
            public Revenue Revenue {get; set; }


        }
        public class Handler : IRequestHandler<Command>
        {
             private readonly DataContext _context;
             private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper )
            {
               _mapper= mapper;
                _context = context;


            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

               var revenue = await _context.Revenue_Details.FindAsync(request.Revenue.Rev_Id);

                //activity.Title = request.Activity.Title ?? activity.Title;
                _mapper.Map(request.Revenue, revenue);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }

    }
}