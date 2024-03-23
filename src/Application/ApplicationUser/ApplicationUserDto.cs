using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanWebApi.Domain.Constants;

public class ApplicationUserDto
{
    //public virtual string? Email { get; set; }

    public virtual string? UserName { get; set; }

    public IList<string>? UserRoles { get; set; }

}
