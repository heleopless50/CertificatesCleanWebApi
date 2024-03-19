using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanWebApi.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog;


namespace clean_architecure_temp.Application.Certificates.Queries;

public record GetCertificatesQuery : IRequest<List<CertificateDto>>{

};

public class GetCertificatesHandler : IRequestHandler<GetCertificatesQuery, List<CertificateDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCertificatesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    public async Task<List<CertificateDto>> Handle(GetCertificatesQuery request, CancellationToken cancellationToken)
    {
        var _logger = new LoggerConfiguration().CreateLogger();
        _logger.Error("second step");
        _logger.Error(_context.Certificates.ToQueryString());


        return await _context.Certificates
            .ProjectTo<CertificateDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

    }
}
