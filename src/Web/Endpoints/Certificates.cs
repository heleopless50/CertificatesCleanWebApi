using clean_architecure_temp.Application.Certificates.Queries;
using clean_architecure_temp.Application.Certificates.Commands;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
namespace clean_architecure_temp.Web.Endpoints;


[EnableCors("CorsPolicy")]
public class Certificates : EndpointGroupBase
{
  

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)            
            .MapGet(GetCertificates)
            .MapGet(GetCertificateById,"{id}")
            //.MapGet(GetCertificateByName, "{studentName:alpha}")
             //.MapGet(GetCertificateByRegistrationNumber, "{regNumber:alpha}")
            .MapPost(CreateCertificate)
            .MapPut(UpdateCertificate, "{id}")
            .MapDelete(DeleteCertificate, "{id}");
    }


   // [Authorize]
    public Task<List<CertificateDto>> GetCertificates(ISender sender, [AsParameters] GetCertificatesQuery query)
    {
        var _logger = new LoggerConfiguration().CreateLogger();
       
        _logger.Error("fist step");
        return sender.Send(query);
    }

    public Task<CertificateDto> GetCertificateById(ISender sender, [AsParameters] GetCertificateByIdQuery query)
    {
        return sender.Send(query);
    }

    /*
    [HttpGet("/api/certificates/byName/{studentName:alpha}")]
    public Task<CertificateDto> GetCertificateByName(ISender sender, [AsParameters] GetCertificateByNameQuery query)
    {
        return sender.Send(query);
    }
    */
    /*
    
    public Task<CertificateDto> GetCertificateByRegistrationNumber(ISender sender, [AsParameters] GetCertificateByRegisterationNumberQuery query)
    {
        return sender.Send(query);
    }
    */

    //[Authorize]
    public Task<Guid> CreateCertificate(ISender sender, CreateCertificateCommand command)
    {
        return sender.Send(command);
    }

   // [Authorize]
    public async Task<IResult> UpdateCertificate(ISender sender, Guid id, UpdateCertificateCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }


    //[Authorize]
    public async Task<IResult> DeleteCertificate(ISender sender, Guid id)
    {
        await sender.Send(new DeleteCertificateCommand(id));
        return Results.NoContent();
    }
}
