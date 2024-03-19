using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanWebApi.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clean_architecure_temp.Application.Certificates.Commands;


public record DeleteCertificateCommand(Guid Id):IRequest;

public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCertificateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
    {

        var entity = await _context.Certificates
    .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Certificates.Remove(entity);

        //entity.AddDomainEvent(new StudentDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
