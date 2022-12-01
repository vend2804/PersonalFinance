using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Persistance;
using AutoMapper;

namespace Application.Items
{
    public class Edit
    {

        public class Command: IRequest
        {
            public Item Item {get; set; }


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

               var item = await _context.Item_Details.FindAsync(request.Item.Item_Id);

                //activity.Title = request.Activity.Title ?? activity.Title;
                _mapper.Map(request.Item, item);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }

    }
}