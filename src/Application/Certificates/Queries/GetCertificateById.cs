﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanWebApi.Application.Common.Interfaces;


namespace clean_architecure_temp.Application.Certificates.Queries;

public record GetCertificateByIdQuery : IRequest<CertificateDto>{
    public Guid Id { get; set; }

};

public class GetCertificateByIdHandler : IRequestHandler<GetCertificateByIdQuery, CertificateDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCertificateByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<CertificateDto> Handle(GetCertificateByIdQuery request, CancellationToken cancellationToken)
    {
           var certificate = await _context.Certificates.Where(a => a.Id == request.Id).ProjectTo<CertificateDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        if (certificate == null)
        {
            throw new Exception("Certificate not found");
        }
        return certificate;

    }
}
