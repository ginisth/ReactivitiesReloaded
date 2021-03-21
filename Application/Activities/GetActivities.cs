using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class GetActivities
    {
        public class Query : IRequest<CustomResult<List<Activity>>> { }

        public class Handler : IRequestHandler<Query, CustomResult<List<Activity>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<CustomResult<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return CustomResult<List<Activity>>.Success(await _context.Activities.ToListAsync());
            }
        }
    }
}
