using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Cities.Commands.Create
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCommentCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Comments)
                .MinimumLength(50).WithMessage("Comments must be at least 50 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified Comment already exists.")
                .NotEmpty().WithMessage("Comments is required.");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            //TODO: Control by uppercase and CultureInfo
            return await _context.Comment.AllAsync(x => x.Comments != name, cancellationToken);
        }
    }
}
