using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clean_architecure_temp.Application.Certificates.Queries;
using clean_architecure_temp.Domain.Entities;
using CleanWebApi.Application.Common.Interfaces;

namespace clean_architecure_temp.Application.Certificates.Commands;
public record CreateCertificateCommand : IRequest<Guid>
{
    public string CertificateName { get; set; } = string.Empty;
    public string StudentName { get; set; } = string.Empty;
    public string SubjectName { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public string qr { get; set; } = string.Empty;
    public string CertificateType { get; set; } = string.Empty;

    public string CertificateExpirationDate { get; set; } = string.Empty;
    public string CertificateIssuer { get; set; } = string.Empty;
    public long? RegistrationNumber { get; set; }
}


public class CreateCertificateHandler : IRequestHandler<CreateCertificateCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCertificateHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Certificate()
        {
            CertificateName = request.CertificateName,
            CertificateExpirationDate = request.CertificateExpirationDate,
            CertificateIssuer = request.CertificateIssuer,
            RegistrationNumber = request.RegistrationNumber,    
            CertificateType = request.CertificateType,
            CreatedDate = request.CreatedDate,
            SubjectName = request.SubjectName,
            qr = request.qr,
            StudentName = request.StudentName

        };
        _context.Certificates.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;


    }
}
