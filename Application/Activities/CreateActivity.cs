using Application.Core;
using Domain;
using FluentValidation;
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
    public class CreateActivity
    {
        public class Command : IRequest<CustomResult<Unit>>
        {
            public Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }

        public class Handler : IRequestHandler<Command, CustomResult<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<CustomResult<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return CustomResult<Unit>.Failure("Failed to create activity");

                return CustomResult<Unit>.Success(Unit.Value);
            }
        }
    }
}
