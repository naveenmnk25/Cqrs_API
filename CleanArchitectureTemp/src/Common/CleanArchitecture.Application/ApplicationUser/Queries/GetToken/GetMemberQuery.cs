using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.ApplicationUser.Queries.GetToken
{
    public class GetMemberQuery : IRequestWrapper<List<User>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class GetMemberQueryHandler : IRequestHandlerWrapper<GetMemberQuery, List<User>>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;
        private readonly IApplicationDbContext _context;
        public GetMemberQueryHandler(IIdentityService identityService, ITokenService tokenService, IApplicationDbContext context)
        {
            _identityService = identityService;
            _tokenService = tokenService;
            _context = context;
        }

        public async Task<ServiceResult<List<User>>> Handle(GetMemberQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.ToListAsync();

            if (user == null)
                return ServiceResult.Failed<List<User>>(ServiceError.ForbiddenError);


            return ServiceResult.Success(user);
        }

    }
}
