using CleanArchitecture.Application.Comments.Commands.Update;
using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Cities.Commands.Update
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCommentCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Comments)
                .MinimumLength(50).WithMessage("Comments must be at least 50 characters.");

            RuleFor(v => v.CommentId).NotNull();
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Comment.AllAsync(x => x.Comments != name, cancellationToken);
        }
    }
}
