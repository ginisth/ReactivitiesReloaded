using Application.Core;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class GetActivity
    {
        public class Query : IRequest<CustomResult<Activity>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, CustomResult<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<CustomResult<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity =  await _context.Activities.FindAsync(request.Id);
                return CustomResult<Activity>.Success(activity);
            }
        }
    }
}
