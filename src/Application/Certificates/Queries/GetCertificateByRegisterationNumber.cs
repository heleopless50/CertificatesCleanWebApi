using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanWebApi.Application.Common.Interfaces;


namespace clean_architecure_temp.Application.Certificates.Queries;

public record GetCertificateByRegisterationNumberQuery : IRequest<CertificateDto>{
    public string? RegisterationNumber { get; set; }

};

public class GetCertificateByRegisterationNumbereHandler : IRequestHandler<GetCertificateByRegisterationNumberQuery, CertificateDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCertificateByRegisterationNumbereHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<CertificateDto> Handle(GetCertificateByRegisterationNumberQuery request, CancellationToken cancellationToken)
    {
        try
        {

           var certificate = await _context.Certificates.Where(a => a.RegistrationNumber == request.RegisterationNumber).ProjectTo<CertificateDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        if (certificate == null)
        {
            throw new Exception("Certificate not found");
        }
        return certificate;

        }catch (Exception ex)
        {
            throw new Exception("problem2", ex);
        }

    }
}
