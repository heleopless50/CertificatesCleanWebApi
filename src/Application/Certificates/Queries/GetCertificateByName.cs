using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanWebApi.Application.Common.Interfaces;


namespace clean_architecure_temp.Application.Certificates.Queries;

public record GetCertificateByNameQuery : IRequest<CertificateDto>{
    public string StudentName { get; set; } = "";

};

public class GetCertificateByNameHandler : IRequestHandler<GetCertificateByNameQuery, CertificateDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCertificateByNameHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<CertificateDto> Handle(GetCertificateByNameQuery request, CancellationToken cancellationToken)
    {
           var certificate = await _context.Certificates.Where(a => a.StudentName.Contains(request.StudentName) || a.RegistrationNumber == a.StudentName ).ProjectTo<CertificateDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        if (certificate == null)
        {
            throw new Exception("Certificate not found");
        }
        return certificate;

    }
}
