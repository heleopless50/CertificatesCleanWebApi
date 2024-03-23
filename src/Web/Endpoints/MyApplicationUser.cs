
using Serilog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using clean_architecure_temp.Application.Users.Queries;
namespace clean_architecure_temp.Web.Endpoints;


[EnableCors("CorsPolicy")]
public class MyApplicationUser : EndpointGroupBase
{
  

    public override void Map(WebApplication app)
    {
        app.MapGroup(this).RequireAuthorization()
            //.MapGet(GetApplicationUsers)
            .MapPost(GetApplicationUserWithRoles)
           //.MapGet(GetApplicationUserByName, "{studentName:alpha}")
           //.MapGet(GetApplicationUserByRegistrationNumber, "{regNumber:alpha}")
           //.MapPost(CreateApplicationUser)
           //.MapPut(UpdateApplicationUser, "{id}")
           // .MapDelete(DeleteApplicationUser, "{id}");
           ;
    }


   // [Authorize]
  /*  public Task<List<ApplicationUserDto>> GetApplicationUsers(ISender sender, [AsParameters] GetApplicationUsersQuery query)
    {
        var _logger = new LoggerConfiguration().CreateLogger();
       
        _logger.Error("fist step");
        return sender.Send(query);
    }*/

    public Task<ApplicationUserDto> GetApplicationUserWithRoles(ISender sender, [AsParameters] GetApplicationUserWithRolesQuery query)
    {
        return sender.Send(query);
    }

    /*
    [HttpGet("/api/ApplicationUsers/byName/{studentName:alpha}")]
    public Task<ApplicationUserDto> GetApplicationUserByName(ISender sender, [AsParameters] GetApplicationUserByNameQuery query)
    {
        return sender.Send(query);
    }
    */
    /*
    
    public Task<ApplicationUserDto> GetApplicationUserByRegistrationNumber(ISender sender, [AsParameters] GetApplicationUserByRegisterationNumberQuery query)
    {
        return sender.Send(query);
    }
    */

    //[Authorize]
    /*
    [Authorize(Roles = "TrainingCenterManager")]
    public Task<Guid> CreateApplicationUser(ISender sender, CreateApplicationUserCommand command)
    {
        return sender.Send(command);
    }

   // [Authorize]
    public async Task<IResult> UpdateApplicationUser(ISender sender, Guid id, UpdateApplicationUserCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }


    //[Authorize]
    public async Task<IResult> DeleteApplicationUser(ISender sender, Guid id)
    {
        await sender.Send(new DeleteApplicationUserCommand(id));
        return Results.NoContent();
    }*/
}
