using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_architecure_temp.Domain.Entities;
public class Certificate
{
    [Key]
    public Guid Id { get; set; }
    public string CertificateName { get; set; } = string.Empty;
    public string StudentName { get; set; } = string.Empty;
    public string SubjectName { get; set; }= string.Empty;
    public DateTime CreatedDate { get; set; }= DateTime.Now;

    public string qr { get; set; } = string.Empty;
    public string CertificateType { get; set; } = string.Empty ;

    public string CertificateExpirationDate { get; set;} = string.Empty;
    public string CertificateIssuer { get; set; } = string.Empty;
    public string? RegistrationNumber { get; set; }

}
