using clean_architecure_temp.Application.Certificates.Queries;
using clean_architecure_temp.Application.Certificates.Commands;
using Serilog;
namespace clean_architecure_temp.Web.Endpoints;

public class Certificates : EndpointGroupBase
{
  

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
           //.RequireAuthorization()
            .MapGet(GetCertificates)
            .MapGet(GetCertificateById,"{id}")
            .MapPost(CreateCertificate)
            .MapPut(UpdateCertificate, "{id}")
            .MapDelete(DeleteCertificate, "{id}");
    }

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

    public Task<Guid> CreateCertificate(ISender sender, CreateCertificateCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateCertificate(ISender sender, Guid id, UpdateCertificateCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteCertificate(ISender sender, Guid id)
    {
        await sender.Send(new DeleteCertificateCommand(id));
        return Results.NoContent();
    }
}
