using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.Categories
{
    public class Edit
    {

        public class Command: IRequest
        {
            public Category Category {get; set; }


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

               var category = await _context.Category_Details.FindAsync(request.Category.Cat_Id);

                //activity.Title = request.Activity.Title ?? activity.Title;
                _mapper.Map(request.Category, category);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }


    }
}