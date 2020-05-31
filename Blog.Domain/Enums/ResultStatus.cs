using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Domains.Enums
{
    public enum ResultStatus
    {
        Success=1,
        EmailExist=2,
        UserNameExist=3,
        NotFound=4,
        Error=5

    }
}
