
using CleanWebApi.Application.Common.Interfaces;
using CleanWebApi.Domain.Constants;


namespace clean_architecure_temp.Application.Users.Queries;

public record GetApplicationUserWithRolesQuery : IRequest<ApplicationUserDto>
{
};

public class GetApplicationUserWithRolesHandler : IRequestHandler<GetApplicationUserWithRolesQuery, ApplicationUserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;
    private readonly IUser _user;

    public GetApplicationUserWithRolesHandler(IApplicationDbContext context, IMapper mapper,IIdentityService identity,IUser user)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
        _user = user;
    }
    public async Task<ApplicationUserDto> Handle(GetApplicationUserWithRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
                var userId = _user.Id;
            if(userId != null)
            {
                var userRoles = await _identity.GetUserRolesAsync(userId);
                var userName = await _identity.GetUserNameAsync(userId);
                
                return new ApplicationUserDto
                {
                    UserName = userName, 
                    UserRoles = userRoles

                 };
            }
            return new();
        }
        catch (Exception ex)
        {
           throw new Exception("problem", ex);
        }


    }
}
